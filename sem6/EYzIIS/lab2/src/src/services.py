import pathlib
from typing import (
    Dict, 
    Tuple,
    Optional, 
    Callable,
)
from functools import reduce

from spacy import Language
from spacy.tokens import Token, Span
from sqlalchemy.orm import Session
from sqlalchemy import (
    select, 
    Select, 
    or_, 
    func
)

from .schemas import *
from .models import *


class AnalizeService:
    def __init__(
        self,
        session: Session,
        nlp: Language,
        pos_tag_map: Dict[str, str],
    ):
        self.session = session
        self.nlp = nlp
        self.pos_tag_map = pos_tag_map
        self._text: Optional[Text] = None
        self._sentence: Optional[Sentence] = None
        
    def analize(
        self,
        *documents: DocumentModel,
    ):
        for document in documents:
            self._add_text_to_database(document)
            self._process_text(document)

    def _add_text_to_database(self, document: DocumentModel) -> None:
        text = Text(
            title=document.title,
            num_words=document.num_words,
        )
        self.session.add(text)
        self.session.commit()
        self._text = text
    
    def _process_text(self, document: DocumentModel) -> None:
        text = pathlib.Path(document.file).read_text()
        doc = self.nlp(text)
        for sent in doc.sents:
            self._process_sentence(sent)

    def _add_sentence_to_database(self, sent: Span) -> Sentence:
        sentence = Sentence(
            text_id=self._text.id,
            content=sent.text.lower()
        )
        self.session.add(sentence)
        self.session.commit()
        return sentence
    
    def _process_sentence(self, sent: Span) -> None:
        self._sentence = self._add_sentence_to_database(sent)
        for token in sent:
            if not token.text.isalpha():
                continue
            self._add_word_form_to_database(token)
        self.session.commit()

    def _add_word_form_to_database(self, token: Token) -> WordForm:
        word_form = WordForm(
            word=token.text.lower(),
            lemma=token.lemma_,
            pos=self.pos_tag_map[token.pos_],
            dep=token.dep_,
            sentence_id=self._sentence.id
        )
        self.session.add(word_form)
        return word_form


class SearchService:
    def __init__(
        self,
        session: Session,
        select_transform: Callable[[Select], Select]
    ):
        self.session = session
        self.select_transform = select_transform

    def search(
        self,
        query: str,
    ) -> SearchResult:
        stmt = self._get_stmt(query)

        count_stmt = select(func.count()).select_from(stmt.subquery())
        count = self.session.execute(count_stmt).scalar_one()
        
        stmt = self.select_transform(self._get_stmt(query))
        result = self.session.execute(stmt).all()
        word_forms=[
            WordFormModel(
                id=wf.id,
                word=wf.word,
                lemma=wf.lemma,
                pos=wf.pos,
                dep=wf.dep,
                document_title=title,
            )
            for wf, title in result
        ]
        return SearchResult(
            word_forms=word_forms,
            count=count
        )
    
    def _get_stmt(self, query: str) -> Select:
        return (
            select(WordForm, Text.title)
            .where(
                or_(
                    WordForm.word.like(f'%{query}%'),
                    WordForm.lemma.like(f'%{query}%'),
                )
            )
            .join(Sentence, WordForm.sentence_id == Sentence.id)
            .join(Sentence.text)
        )


class FilteredSearchService(SearchService):
    def __init__(self, session, select_transform):
        super().__init__(session, select_transform)
        self._pos: Optional[str] = None

    def search(self, query, pos: Optional[str] = None):
        self._pos = pos
        return super().search(query)
    
    def _get_stmt(self, query):
        if self._pos is not None:
            return super()._get_stmt(query).where(WordForm.pos == self._pos)
        return super()._get_stmt(query)
    

class SentenceFilteredSearchService(FilteredSearchService):
    def search(self, query, pos = None):
        if ' ' in query:
            return self._search_phrase(query)
        result = super().search(query, pos)
        stmt = self.select_transform(self._get_sentence_stmt(query))
        sentences_result = self.session.execute(stmt).all()
        return SentenceSearchResult(
            word_forms=result.word_forms,
            count=result.count,
            sentences=[
                SentenceModel(
                    id=sent.id,
                    content=sent.content,
                    document_title=title
                )
                for sent, title in sentences_result
            ]
        )
    
    def _search_phrase(self, query) -> SentenceSearchResult:
        stmt = self.select_transform(self._get_sentence_stmt(query))

        count_stmt = select(func.count()).select_from(stmt.subquery())
        count = self.session.execute(count_stmt).scalar_one()

        result = self.session.execute(stmt).all()
        return SentenceSearchResult(
            word_forms=[],
            count=count,
            sentences=[
                SentenceModel(
                    id=sent.id,
                    content=sent.content,
                    document_title=title
                )
                for sent, title in result
            ]
        )
    
    def _get_sentence_stmt(self, query: str) -> Select:
        return (
            select(Sentence, Text.title)
            .where(
                Sentence.content.regexp_match(fr'.*(^| ){query}(\.|,| ).*'),
            )
            .join(Text)
        )