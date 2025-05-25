#include <iostream>

#include <sc-memory/sc_memory.hpp>
#include <sc-memory/sc_stream.hpp>
#include <sc-memory/sc_template_search.cpp>

#include <sc-agents-common/utils/IteratorUtils.hpp>
#include <sc-agents-common/utils/AgentUtils.hpp>

#include "IsomorphicAgent.hpp"

using namespace std;
using namespace utils;

namespace isomorphicModule
{
SC_AGENT_IMPLEMENTATION(IsomorphicAgent)
{
  SC_LOG_DEBUG("IsomorphicAgent: started");
  ScAddr actionNode = otherAddr;

  graphs = IteratorUtils::getAllWithType()

  ScAddrVector answerElements;
  try
  {
  }
  catch (exception & exc)
  {
    SC_LOG_ERROR("IsomorphicSearchAgent: " << exc.what());
    utils::AgentUtils::finishAgentWork(&m_memoryCtx, actionNode, false);
    return SC_RESULT_ERROR;
  }

  utils::AgentUtils::finishAgentWork(ms_context.get(), actionNode, answerElements, true);
  SC_LOG_DEBUG("IsomorphicAgent: finished");
  return SC_RESULT_OK;
}

}  // namespace isomorphicModule
