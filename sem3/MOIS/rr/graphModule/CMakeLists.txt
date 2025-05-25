file(GLOB_RECURSE SOURCES "*.cpp" "*.hpp")

include_directories(${CMAKE_CURRENT_LIST_DIR} ${CMAKE_CURRENT_LIST_DIR}/generated ${SC_MEMORY_SRC} ${SC_KPM_SRC})

add_library (myModule SHARED ${SOURCES} ${HEADERS})
target_link_libraries(myModule sc-memory sc-agents-common)

sc_codegen_ex(myModule ${CMAKE_CURRENT_LIST_DIR} ${CMAKE_CURRENT_LIST_DIR}/generated)
