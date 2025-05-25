#pragma once

#include <sc-memory/kpm/sc_agent.hpp>

#include "keynodes/keynodes.hpp"
#include "myAgent.generated.hpp"

using namespace std;

namespace myModule
{
  class MyAgent : public ScAgent
  {
    SC_CLASS(Agent, Event(Keynodes::question_find_bridges, ScEvent::Type::AddOutputEdge))
    SC_GENERATED_BODY()

    ScAddr param;
    ScAddrVector passed;
    ScAddrVector answer;
    int timer = 0;
    map<ScAddr::HashType, int> tin;
    map<ScAddr::HashType, int> fup;
    ScAddr tree;

    void find_bridges();
    void compute_tin(ScAddr node, ScAddr parent);
    void compute_fup(ScAddr node, ScAddr parent);
  };
}