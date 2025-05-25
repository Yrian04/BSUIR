#pragma once

#include <sc-memory/kpm/sc_agent.hpp>

#include "keynodes.hpp"

#include <map>
#include "lineGraphAgent.generated.hpp"

namespace agentsModule
{   
    
class LineGraphAgent : public ScAgent
{
  SC_CLASS(Agent, Event(Keynodes::question_find_linegraph, ScEvent::Type::AddOutputEdge))
  SC_GENERATED_BODY()

  ScAddrVector globalProcessed;
  ScAddr graph;
  std::map<ScAddr::HashType, ScAddr> rel;

};

}