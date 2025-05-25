#include "agentsModule.hpp"
#include "keynodes.hpp"
#include "lineGraphAgent.hpp"

using namespace agentsModule;

SC_IMPLEMENT_MODULE(AgentsModule)

sc_result AgentsModule::InitializeImpl()
{   
  if(!Keynodes::InitGlobal())
    return SC_RESULT_ERROR;
  SC_AGENT_REGISTER(LineGraphAgent)

  return SC_RESULT_OK;
}

sc_result AgentsModule::ShutdownImpl()
{
  SC_AGENT_UNREGISTER(LineGraphAgent)
  
  return SC_RESULT_OK;
}