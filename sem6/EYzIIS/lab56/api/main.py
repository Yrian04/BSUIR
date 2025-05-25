import os

from fastapi import FastAPI
from pydantic_models import QueryInput, QueryResponse
from langchain_utils import get_rag_chain
from db_utils import insert_application_logs, get_chat_history, remove_log_record
from chroma_utils import index_document_to_chroma
import uuid
import logging

logging.basicConfig(filename='app.log', level=logging.INFO)

_, _, docs = next(os.walk('docs'))
for i, doc in enumerate(docs):
    index_document_to_chroma(os.path.join('docs', doc), i)
    logging.info("Load doc: %s", doc)
    print(f"Load doc {doc}")


app = FastAPI()

@app.post("/chat", response_model=QueryResponse)
def chat(query_input: QueryInput):
    session_id = query_input.session_id or str(uuid.uuid4())
    logging.info(f"Session ID: {session_id}, User Query: {query_input.question}, , Model: {query_input.model.value}")
    
    chat_history = get_chat_history(session_id)
    rag_chain = get_rag_chain(query_input.model.value)
    answer = rag_chain.invoke({
        "input": query_input.question,
        "chat_history": chat_history
    })['answer']

    message_id = insert_application_logs(session_id, query_input.question, answer, query_input.model.value)
    logging.info(f"Session ID: {session_id}, AI Response: {answer}")
    return QueryResponse(answer=answer, session_id=session_id, model=query_input.model, message_id=message_id)

@app.post("/remove_message/{message_id}")
def chat(message_id: int):
    result = remove_log_record(message_id)
    logging.info("Removing message %s. Result: %s", str(message_id), str(result))
    return {'result': result}
