file(GLOB_RECURSE SOURCES "*.cpp" "*.hpp")

# set(SOURCES
#   "agentsModule.cpp"
#   "agentsModuleApiAi.cpp"
# )
# set(HEADERS
#   "agentsModule.hpp"
#   "agentsModuleApiAi.hpp"
# )

include_directories(${CMAKE_CURRENT_LIST_DIR} ${SC_MEMORY_SRC} ${SC_KPM_SRC})

add_library (agentsModule SHARED ${SOURCES})
target_link_libraries(agentsModule sc-memory sc-agents-common)

sc_codegen_ex(agentsModule ${CMAKE_CURRENT_LIST_DIR} ${CMAKE_CURRENT_LIST_DIR}/generated)