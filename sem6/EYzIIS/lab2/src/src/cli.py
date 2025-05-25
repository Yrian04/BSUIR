import argparse
import json

import spacy

from src.schemas import DocumentModel
from src.services import AnalizeService
from src.database import SessionLocal
from src.config import settings
from src.database import engine
from src.models import Base

Base.metadata.create_all(bind=engine)

parser = argparse.ArgumentParser(
    description="Util for analize documents"
)
parser.add_argument(
    '-i', 
    '--input',
    type=argparse.FileType(),
    nargs='+', 
    help='json files with description of documents'
)

args = parser.parse_args()

documents: list[DocumentModel] = []
for file in args.input:
    doc_dict = json.load(file)
    documents.append(DocumentModel(**doc_dict))

try: 
    session = SessionLocal()
    nlp = spacy.load('en_core_web_sm')
    analize_service = AnalizeService(session, nlp, settings.get_pos_tag_map())
    analize_service.analize(*documents)
finally:
    session.close()
