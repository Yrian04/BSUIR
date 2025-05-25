#pragma once

#include <sc-memory/kpm/sc_agent.hpp>

#include "keynodes/keynodes.hpp"
#include "IsomorphicAgent.generated.hpp"

namespace isomorphicModule
{
class IsomorphicAgent : public ScAgent
{
  SC_CLASS(Agent, Event(Keynodes::question_find_isomorphic, ScEvent::Type::AddOutputEdge))
  SC_GENERATED_BODY()

  ScAddrVector graphs;
};

}  // namespace isomorphicModule
