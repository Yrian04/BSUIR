#pragma once

#include <sc-memory/kpm/sc_agent.hpp>

#include "keynodes/keynodes.hpp"
#include "IsFunctionalAgent.generated.hpp"

namespace functionalModule
{
class IsFunctionalAgent : public ScAgent
{
  SC_CLASS(Agent, Event(Keynodes::question_is_functional, ScEvent::Type::AddOutputEdge))
  SC_GENERATED_BODY()

  ScAddr graph;
};

}  // namespace functionalModule
