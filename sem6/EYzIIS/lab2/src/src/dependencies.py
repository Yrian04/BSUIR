from sqlalchemy.orm import Session

from src.database import SessionLocal


def get_session():
    db = SessionLocal()
    try:
        return db
    finally:
        db.close()