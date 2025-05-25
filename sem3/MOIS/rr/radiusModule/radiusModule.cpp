/*
* This source file is part of an OSTIS project. For the latest info, see http://ostis.net
* Distributed under the MIT License
* (See accompanying file COPYING.MIT or copy at http://opensource.org/licenses/MIT)
*/

#include "radiusModule.hpp"
#include "keynodes/keynodes.hpp"

#include "agents/FindRadiusAgent.hpp"

using namespace radiusModule;

SC_IMPLEMENT_MODULE(RadiusModule)

sc_result RadiusModule::InitializeImpl()
{
  if (!radiusModule::Keynodes::InitGlobal())
    return SC_RESULT_ERROR;

  SC_AGENT_REGISTER(FindRadiusAgent)

  return SC_RESULT_OK;
}

sc_result RadiusModule::ShutdownImpl()
{
  SC_AGENT_UNREGISTER(FindRadiusAgent)

  return SC_RESULT_OK;
}
