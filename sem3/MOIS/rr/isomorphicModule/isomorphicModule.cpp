/*
* This source file is part of an OSTIS project. For the latest info, see http://ostis.net
* Distributed under the MIT License
* (See accompanying file COPYING.MIT or copy at http://opensource.org/licenses/MIT)
*/

#include "isomorphicModule.hpp"
#include "keynodes/keynodes.hpp"
#include "agents/IsomorphicAgent.hpp"

using namespace isomorphicModule;

SC_IMPLEMENT_MODULE(IsomorphicModule)

sc_result IsomorphicModule::InitializeImpl()
{
  if (!isomorphicModule::Keynodes::InitGlobal())
    return SC_RESULT_ERROR;

  SC_AGENT_REGISTER(IsomorphicAgent)

  return SC_RESULT_OK;
}

sc_result IsomorphicModule::ShutdownImpl()
{
  SC_AGENT_UNREGISTER(IsomorphicAgent)

  return SC_RESULT_OK;
}
