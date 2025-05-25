#include "myModule.hpp"
#include "keynodes/keynodes.hpp"
#include "agents/myAgent.hpp"

using namespace myModule;

SC_IMPLEMENT_MODULE(MyModule)

sc_result MyModule::InitializeImpl()
{

  if (!myModule::Keynodes::InitGlobal())
    return SC_RESULT_ERROR;

  SC_AGENT_REGISTER(MyAgent)

  return SC_RESULT_OK;
}

sc_result MyModule::ShutdownImpl()
{
  SC_AGENT_UNREGISTER(MyAgent)

  return SC_RESULT_OK;
}