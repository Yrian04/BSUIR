import streamlit as st
from api_utils import get_api_response, remove_message
import time

def display_chat_interface():
    # Chat interface
    for idx, message in enumerate(st.session_state.messages):
        with st.chat_message(message['role']):
            st.markdown(message["content"])
            if message['role'] == 'assistant' and st.button("🗑️", key=f"delete_{idx}", help="Delete this message"):
                # Удаляем сообщение по индексу
                st.session_state.messages.pop(idx)
                st.session_state.messages.pop(idx-1)
                remove_message(message['id'])
                # Перезапускаем приложение для обновления интерфейса
                st.rerun()

    if prompt := st.chat_input("Query:"):
        st.session_state.messages.append({"role": "user", "content": prompt})
        with st.chat_message("user"):
            st.markdown(prompt)

        with st.spinner("Generating response..."):
            start = time.time()
            response = get_api_response(prompt, st.session_state.session_id, st.session_state.model)
            t = time.time() - start

            if response:
                st.session_state.session_id = response.get('session_id')
                st.session_state.messages.append({"id": response['message_id'], "role": "assistant", "content": response['answer']})
                
                with st.chat_message("assistant"):
                    st.markdown(response['answer'])
                with st.container():
                    st.metric('time', t,)
            else:
                st.error("Failed to get a response from the API. Please try again.")
