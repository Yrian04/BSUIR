#include <iostream>

#include <sc-memory/sc_memory.hpp>
#include <sc-memory/sc_stream.hpp>
#include <sc-memory/sc_template_search.cpp>

#include <sc-agents-common/utils/IteratorUtils.hpp>
#include <sc-agents-common/utils/AgentUtils.hpp>

#include <queue>
#include <map>

#include "FindRadiusAgent.hpp"

using namespace std;
using namespace utils;

namespace radiusModule
{
SC_AGENT_IMPLEMENTATION(FindRadiusAgent)
{
  SC_LOG_DEBUG("FindRadiusAgent: started");
  graph = IteratorUtils::getFirstFromSet(&m_memoryCtx, otherAddr);
  ScAddrVector answer;
  answer.push_back(graph);
  answer.push_back(Keynodes::nrel_radius_of_graph);

  int radius = INT32_MAX;

  auto it3 = m_memoryCtx.Iterator3(graph, ScType::EdgeAccessConstPosPerm, ScType::Node);
  while (it3->Next())
  {
    ScAddr node = it3->Get(2);

    SC_LOG_DEBUG("FindRadiusAgent: processed node " << m_memoryCtx.HelperGetSystemIdtf(node));

    radius = min(radius, eccentricity(node));
  }

  ScAddr rNode = m_memoryCtx.HelperFindBySystemIdtf(to_string(radius));
  if (!rNode.IsValid())
  {
    rNode = m_memoryCtx.CreateNode(ScType::NodeConst);
    m_memoryCtx.HelperSetSystemIdtf(to_string(radius), rNode);
  }
  answer.push_back(rNode);

  ScAddr rel = m_memoryCtx.CreateEdge(ScType::EdgeDCommonConst, graph, rNode);
  answer.push_back(rel);

  ScAddr rel_access = m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, Keynodes::nrel_radius_of_graph, rel);
  answer.push_back(rel_access);

  utils::AgentUtils::finishAgentWork(&m_memoryCtx, otherAddr, answer, true);
  SC_LOG_DEBUG("FindRadiusAgent: finished");
  return SC_RESULT_OK;
}

void FindRadiusAgent::bfs(ScAddrMap<int> &distances, ScAddr root)
{
  distances.clear();
  distances[root.Hash()] = 0;

  queue<ScAddr> queue;
  queue.push(root);

  ScAddr current;
  while (!queue.empty())
  {
    current = queue.front();
    queue.pop();

    SC_LOG_DEBUG("FindRadiusAgent:     bfs processed node " << m_memoryCtx.HelperGetSystemIdtf(current));

    ScIterator5Ptr it5 = m_memoryCtx.Iterator5(current, ScType::EdgeDCommonConst, ScType::NodeConst, ScType::EdgeAccessConstPosPerm, graph);
    while (it5->Next())
    {
      ScAddr child = it5->Get(2);

      SC_LOG_DEBUG("FindRadiusAgent:         child " << m_memoryCtx.HelperGetSystemIdtf(child));

      if ((find_if(distances.begin(), distances.end(), [child](pair<ScAddr::HashType, int> x){ return x.first == child.Hash(); }) == distances.end()))
      {
        distances[child.Hash()] = distances[current.Hash()] + 1;
        queue.push(child);

       SC_LOG_DEBUG("FindRadiusAgent:         " << m_memoryCtx.HelperGetSystemIdtf(child) << " is passed; distance is " << to_string(distances[child.Hash()]));  
      }
    }
  }
}

int FindRadiusAgent::eccentricity(ScAddr node)
{
  ScAddrMap<int> distances;

  int e = 0;

  bfs(distances, node);

  for (auto p : distances)
  {
    e = max(e, p.second);
  }

  SC_LOG_DEBUG("FindRadiusAgent: eccentricity of " << m_memoryCtx.HelperGetSystemIdtf(node) << " is " << e);

  return e;
}

}  // namespace exampleModule
