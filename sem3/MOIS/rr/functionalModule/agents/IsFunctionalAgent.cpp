#include <iostream>

#include <sc-memory/sc_memory.hpp>
#include <sc-memory/sc_stream.hpp>
#include <sc-memory/sc_template_search.cpp>

#include <sc-agents-common/utils/IteratorUtils.hpp>
#include <sc-agents-common/utils/AgentUtils.hpp>

#include "IsFunctionalAgent.hpp"

#include <map>

using namespace std;
using namespace utils;

namespace functionalModule
{
SC_AGENT_IMPLEMENTATION(IsFunctionalAgent)
{
  SC_LOG_DEBUG("IsFunctionalAgent: started");
  graph = IteratorUtils::getFirstFromSet(&m_memoryCtx, otherAddr);
  ScAddrVector answer;
  answer.push_back(graph);
  answer.push_back(Keynodes::functional_graph);
  answer.push_back(Keynodes::counterfunctional_graph);


  map<ScAddr::HashType, int> in;
  map<ScAddr::HashType, int> out;

  auto it3 = m_memoryCtx.Iterator3(graph, ScType::EdgeAccessConstPosPerm, ScType::NodeConst);
  while (it3->Next())
  {
    ScAddr node = it3->Get(2);

    in[node.Hash()] = 0;
    out[node.Hash()] = 0;
  }

  it3 = m_memoryCtx.Iterator3(graph, ScType::EdgeAccessConstPosPerm, ScType::EdgeDCommonConst);
  while (it3->Next())
  {
    ScAddr edge = it3->Get(2);
    ScAddr source = m_memoryCtx.GetEdgeSource(edge);
    ScAddr target = m_memoryCtx.GetEdgeTarget(edge);

    SC_LOG_DEBUG("IsFunctionalAgent: processed edge between " << source.Hash() << " and " << target.Hash());

    in[target.Hash()]++;
    out[source.Hash()]++;
  }

  bool isFunc = true;
  for(auto p : in)
  {
    isFunc &= p.second == 1;
    SC_LOG_DEBUG("IsFunctionalAgent: in[" << p.first << "] = " << p.second);
  }
  
  bool isCounter = true;
  for(auto p : out)
  {
    isCounter &= p.second == 1;
    SC_LOG_DEBUG("IsFunctionalAgent: out[" << p.first << "] = " << p.second);
  }

  if(isFunc)
  {
    SC_LOG_DEBUG("IsFunctionalAgent: graph is functional");
    ScAddr edge = m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, Keynodes::functional_graph, graph);
    answer.push_back(edge);
  }
  else
  {
    SC_LOG_DEBUG("IsFunctionalAgent: graph is not functional");
    ScAddr edge = m_memoryCtx.CreateEdge(ScType::EdgeAccessConstNegPerm, Keynodes::functional_graph, graph);
    answer.push_back(edge);
  }


  if(isCounter)
  {
    SC_LOG_DEBUG("IsFunctionalAgent: graph is counterfunctional");
    ScAddr edge = m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, Keynodes::counterfunctional_graph, graph);
    answer.push_back(edge);
  }
  else
  {
    SC_LOG_DEBUG("IsFunctionalAgent: graph is not counterfunctional");
    ScAddr edge = m_memoryCtx.CreateEdge(ScType::EdgeAccessConstNegPerm, Keynodes::counterfunctional_graph, graph);
    answer.push_back(edge);
  }

  utils::AgentUtils::finishAgentWork(&m_memoryCtx, otherAddr, answer, true);
  SC_LOG_DEBUG("IsFunctionalAgent: finished");
  return SC_RESULT_OK;
}

}  // namespace functionalModule
