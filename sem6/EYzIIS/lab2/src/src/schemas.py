from os import PathLike
from typing import List

from pydantic import BaseModel


class CustomModel(BaseModel):
    pass


class DocumentModel(BaseModel):
    title: str
    num_words: int
    file: PathLike


class WordFormModel(CustomModel):
    id: int
    word: str
    lemma: str
    pos: str
    dep: str
    document_title: str


class SentenceModel(CustomModel):
    id: int
    content: str
    document_title: str


class SearchResult(CustomModel):
    word_forms: List[WordFormModel]
    count: int


class SentenceSearchResult(CustomModel):
    word_forms: List[WordFormModel]
    count: int
    sentences: List[SentenceModel]
