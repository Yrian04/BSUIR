from typing import List
from sqlalchemy import ForeignKey
from sqlalchemy.orm import (
    mapped_column,
    Mapped, 
    relationship, 
    DeclarativeBase,
)


class Base(DeclarativeBase):
    pass


class WordForm(Base):
    __tablename__ = 'word_form'
    id: Mapped[int] = mapped_column(primary_key=True, nullable=False)
    word: Mapped[str] = mapped_column(nullable=False)
    lemma: Mapped[str] = mapped_column(nullable=False)
    pos: Mapped[str] = mapped_column(nullable=False)
    dep: Mapped[str] = mapped_column(nullable=False)
    
    sentence_id: Mapped[int] = mapped_column(ForeignKey("sentence.id"))


class Text(Base):
    __tablename__ = 'text'
    id: Mapped[int] = mapped_column(primary_key=True, nullable=False)
    title: Mapped[str] = mapped_column(nullable=False)
    num_words: Mapped[int] = mapped_column(nullable=False)

    sentences: Mapped[List["Sentence"]] = relationship()


class Sentence(Base):
    __tablename__ = 'sentence'
    id: Mapped[int] = mapped_column(primary_key=True, nullable=False)
    content: Mapped[str] = mapped_column(nullable=False)
    
    text: Mapped["Text"] = relationship()
    text_id: Mapped[int] = mapped_column(ForeignKey("text.id"))
    word_forms: Mapped[List["WordForm"]] = relationship()
