#pragma once

#include <sc-memory/kpm/sc_agent.hpp>

#include "keynodes/keynodes.hpp"
#include "FindRadiusAgent.generated.hpp"

using namespace std;

namespace radiusModule
{
class FindRadiusAgent : public ScAgent
{
  SC_CLASS(Agent, Event(Keynodes::question_find_radius, ScEvent::Type::AddOutputEdge))
  SC_GENERATED_BODY()

  template <typename T>
  using ScAddrMap = map<ScAddr::HashType, T>;

  ScAddr graph;

  void bfs(ScAddrMap<int>& distances, ScAddr root);

  int eccentricity(ScAddr node);
};
}  // namespace exampleModule
