from timeit import timeit
from pprint import pprint

n = 1000
setup = '''
from src.database import SessionLocal
from src.services import FilteredSearchService
session = SessionLocal()
search_service = FilteredSearchService(
    session,
    lambda s: (
        s.limit(20)
    )
)
'''
code = "search_service.search('support')"

t = timeit(code, setup, number=n) / n
pprint(t*1000)
