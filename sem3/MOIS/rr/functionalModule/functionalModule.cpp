/*
* This source file is part of an OSTIS project. For the latest info, see http://ostis.net
* Distributed under the MIT License
* (See accompanying file COPYING.MIT or copy at http://opensource.org/licenses/MIT)
*/

#include "functionalModule.hpp"
#include "keynodes/keynodes.hpp"

#include "agents/IsFunctionalAgent.hpp"

using namespace functionalModule;

SC_IMPLEMENT_MODULE(FunctionalModule)

sc_result FunctionalModule::InitializeImpl()
{
  if (!functionalModule::Keynodes::InitGlobal())
    return SC_RESULT_ERROR;

  SC_AGENT_REGISTER(IsFunctionalAgent)

  return SC_RESULT_OK;
}

sc_result FunctionalModule::ShutdownImpl()
{
  SC_AGENT_UNREGISTER(IsFunctionalAgent)

  return SC_RESULT_OK;
}
