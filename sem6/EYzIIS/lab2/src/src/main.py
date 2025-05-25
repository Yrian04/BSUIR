from src.gui import ManagerApp
from src.services import SentenceFilteredSearchService
from src.database import SessionLocal


def main():
    try:
        session = SessionLocal()
        search_service = SentenceFilteredSearchService(
            session,
            lambda s: (
                s.limit(20)
            )
        )
        app = ManagerApp(
            search_service
        )
        app.run()
    finally:
        session.close()


if __name__ == "__main__":
    main()
