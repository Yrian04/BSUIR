#include <iostream>

#include <sc-memory/sc_memory.hpp>
#include <sc-memory/sc_stream.hpp>
#include <sc-memory/sc_template_search.cpp>

#include <sc-agents-common/utils/IteratorUtils.hpp>
#include <sc-agents-common/utils/AgentUtils.hpp>

#include "lineGraphAgent.hpp"
#include <algorithm>

using namespace std;
using namespace utils;

namespace agentsModule
{

SC_AGENT_IMPLEMENTATION(LineGraphAgent)
{
  SC_LOG_DEBUG("LineGraphAgent: started");

  graph = IteratorUtils::getFirstFromSet(&m_memoryCtx, otherAddr);

  ScAddr lineGraph = m_memoryCtx.CreateNode(ScType::NodeConstStruct);
  m_memoryCtx.HelperSetSystemIdtf("line graph of " + m_memoryCtx.HelperGetSystemIdtf(graph) + to_string(lineGraph.Hash()), lineGraph);

  ScIterator3Ptr tr = m_memoryCtx.Iterator3(graph, ScType::EdgeAccessConstPosPerm, ScType::NodeConst);

  while (tr->Next())
  {
    ScAddr node = tr->Get(2);
    SC_LOG_DEBUG("LineGraphAgent: processed node " + m_memoryCtx.HelperGetSystemIdtf(node));
    ScAddrVector processed;
    ScIterator5Ptr it5 = m_memoryCtx.Iterator5(node, ScType::EdgeUCommonConst, ScType::NodeConst, ScType::EdgeAccessConstPosPerm, graph);
    while (it5->Next())
    {
      ScAddr edge = it5->Get(1);
      SC_LOG_DEBUG("LineGraphAgent:     processed edge between " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeSource(edge)) + " and " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeTarget(edge)));
      ScAddr edgeNode;
      if (find(globalProcessed.begin(),globalProcessed.end(),edge) == globalProcessed.end())
      {
        SC_LOG_DEBUG("LineGraphAgent:     It isn't in global passed");
        edgeNode = m_memoryCtx.CreateNode(ScType::NodeConst);
        m_memoryCtx.HelperSetSystemIdtf(m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeSource(edge)) + " " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeTarget(edge)), edgeNode);
        rel[edge.Hash()] = edgeNode;
        m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, lineGraph, edgeNode);
        globalProcessed.push_back(edge);
      }
      else 
      {
        SC_LOG_DEBUG("LineGraphAgent:     It is in global passed");
        edgeNode = rel[edge.Hash()];
      }
      for (ScAddr neighbour : processed)
      {
        SC_LOG_DEBUG("LineGraphAgent:     connected it with neighbour " +m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeSource(neighbour)) + " " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeTarget(neighbour)));
        ScAddr neighbourEdge = m_memoryCtx.CreateEdge(ScType::EdgeUCommonConst, edgeNode, rel[neighbour.Hash()]);
        m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, lineGraph, neighbourEdge);
      }
      processed.push_back(edge);
      SC_LOG_DEBUG("LineGraphAgent: end processed edge between "  + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeSource(edge)) + " and " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeTarget(edge)));
    }
    it5 = m_memoryCtx.Iterator5(ScType::NodeConst, ScType::EdgeUCommonConst, node, ScType::EdgeAccessConstPosPerm, graph);
    while (it5->Next())
    {
      ScAddr edge = it5->Get(1);
      SC_LOG_DEBUG("LineGraphAgent:     processed edge between " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeSource(edge)) + " and " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeTarget(edge)));
      ScAddr edgeNode;
      if (find(globalProcessed.begin(),globalProcessed.end(),edge) == globalProcessed.end())
      {
        SC_LOG_DEBUG("LineGraphAgent:     It isn't in global passed");
        edgeNode = m_memoryCtx.CreateNode(ScType::NodeConst);
        m_memoryCtx.HelperSetSystemIdtf(m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeSource(edge)) + " " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeTarget(edge)), edgeNode);
        rel[edge.Hash()] = edgeNode;
        m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, lineGraph, edgeNode);
        globalProcessed.push_back(edge);
      }
      else 
      {
        SC_LOG_DEBUG("LineGraphAgent:     It is in global passed");
        edgeNode = rel[edge.Hash()];
      }
      for (ScAddr neighbour : processed)
      {
        SC_LOG_DEBUG("LineGraphAgent:     connected it with neighbour " +m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeSource(neighbour)) + " " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeTarget(neighbour)));
        ScAddr neighbourEdge = m_memoryCtx.CreateEdge(ScType::EdgeUCommonConst, edgeNode, rel[neighbour.Hash()]);
        m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, lineGraph, neighbourEdge);
      }
      processed.push_back(edge);
      SC_LOG_DEBUG("LineGraphAgent: end processed edge between "  + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeSource(edge)) + " and " + m_memoryCtx.HelperGetSystemIdtf(m_memoryCtx.GetEdgeTarget(edge)));
    }
  }

  ScAddrVector answer;
  answer.push_back(lineGraph);
 
  AgentUtils::finishAgentWork(&m_memoryCtx, otherAddr, answer);
  SC_LOG_DEBUG("LineGraphAgent: finished");
  return SC_RESULT_OK;
}

}