#include <sc-agents-common/utils/GenerationUtils.hpp>
#include <sc-agents-common/utils/AgentUtils.hpp>
#include <sc-agents-common/utils/IteratorUtils.hpp>
#include <sc-agents-common/utils/CommonUtils.hpp>

#include <map>
#include <algorithm>

#include "myAgent.hpp"

using namespace std;
using namespace utils;

namespace myModule
{
SC_AGENT_IMPLEMENTATION(MyAgent)
{
  SC_LOG_DEBUG("MyAgent: started");

  timer = 0;
  fup.clear();
  tin.clear();
  passed.clear();
  answer.clear();
  
  param = IteratorUtils::getFirstFromSet(&m_memoryCtx, otherAddr);
  if (!param.IsValid())
    return SC_RESULT_ERROR_INVALID_PARAMS;
  
  // if (m_memoryCtx.GetElementType(param) == ScType::NodeConstStruct){
  //   SC_LOG_ERROR("My agent: invalid parameter");
  //   return SC_RESULT_ERROR_INVALID_PARAMS;
  // }
  
  SC_LOG_DEBUG("MyAgent: create tree node");
  tree = m_memoryCtx.CreateNode(ScType::NodeConstStruct);
  if (!m_memoryCtx.HelperSetSystemIdtf("tree" + to_string(tree.Hash()), tree))
    SC_LOG_DEBUG("Tree was not named");
  //answer.push_back(Keynodes::rrel_bridge);
  answer.push_back(tree);
  //answer.push_back(param);

  ScIterator3Ptr iterator3 = m_memoryCtx.Iterator3(param, ScType::EdgeAccessConstPosPerm, ScType::NodeConst);
  iterator3->Next();
  ScAddr root = iterator3->Get(2);
  SC_LOG_DEBUG("myAgent: root of dfs is " + m_memoryCtx.HelperGetSystemIdtf(root));
  m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, tree, root);

  SC_LOG_DEBUG("MyAgent: start compute tin");

  compute_tin(root, param);

  SC_LOG_DEBUG("MyAgent: end compute tin");
  SC_LOG_DEBUG("MyAgent: start compute fup");

  compute_fup(root, param);

  SC_LOG_DEBUG("MyAgent: end compute fup");

  SC_LOG_DEBUG("MyAgent: start find bridges");
  find_bridges();
  SC_LOG_DEBUG("MyAgent: end find bridges");

  AgentUtils::finishAgentWork(&m_memoryCtx, otherAddr, answer);
  SC_LOG_DEBUG("MyAgent: finished");
  return SC_RESULT_OK;
}

void MyAgent::compute_tin(ScAddr node, ScAddr parent)
{  
  SC_LOG_DEBUG("myAgent: Process " + m_memoryCtx.HelperGetSystemIdtf(node));

  passed.push_back(node);
  tin[node.Hash()] = timer++;

  ScIterator3Ptr iterator3 = m_memoryCtx.Iterator3(param, ScType::EdgeAccessConstPosPerm, ScType::EdgeUCommonConst);
  while (iterator3->Next())
  {    
    ScAddr edge = iterator3->Get(2);
    ScAddr source;
    ScAddr target;

    m_memoryCtx.GetEdgeInfo(edge, source, target);
    ScAddr next;

    if (source == node)
      next = target;
    else if (target == node)
      next = source;
    else
      continue;

    SC_LOG_DEBUG("myAgent: Process edge from" + m_memoryCtx.HelperGetSystemIdtf(node) + " to " + m_memoryCtx.HelperGetSystemIdtf(next));

    if (next == parent)
      continue;
    if (find(passed.begin(), passed.end(), next) != passed.end())
      continue;
    else
    {
      ScAddr treeAccess = m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, tree, next);
      //answer.push_back(treeAccess);
      ScAddr treeEdge = m_memoryCtx.CreateEdge(ScType::EdgeDCommonConst, node, next);
      ScAddr treeAccessEdge = m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, tree, treeEdge);
      //answer.push_back(treeAccessEdge);
      compute_tin(next, node);
    }
  }
}

void MyAgent::compute_fup(ScAddr root, ScAddr parent)
{  
  SC_LOG_DEBUG("myAgent: Process " + m_memoryCtx.HelperGetSystemIdtf(root));
  
  fup[root.Hash()] = tin[root.Hash()];

  ScIterator5Ptr iterator5 = m_memoryCtx.Iterator5(root, ScType::EdgeUCommonConst, ScType::NodeConst, ScType::EdgeAccessConstPosPerm, param);
  while (iterator5->Next())
  {    
    ScAddr child = iterator5->Get(2);
    SC_LOG_DEBUG("myAgent: Process edge from " + m_memoryCtx.HelperGetSystemIdtf(root) + " to " + m_memoryCtx.HelperGetSystemIdtf(child));
    if (child == parent)
    {
      SC_LOG_DEBUG("myAgent: parent");
      continue;
    }

    ScIterator5Ptr it_1 = m_memoryCtx.Iterator5(root, ScType::EdgeDCommonConst, child, ScType::EdgeAccessConstPosPerm, tree);
    if (it_1->Next())
    {
      SC_LOG_DEBUG("myAgent: child");
      compute_fup(child, root);
      fup[root.Hash()] = min(fup[root.Hash()], fup[child.Hash()]);
    }
    else
    {
      SC_LOG_DEBUG("myAgent: parent");
      fup[root.Hash()] = min(fup[root.Hash()], tin[child.Hash()]);
    }
  }
  
  iterator5 = m_memoryCtx.Iterator5(ScType::NodeConst, ScType::EdgeUCommonConst, root, ScType::EdgeAccessConstPosPerm, param);
  while (iterator5->Next())
  {    
    ScAddr child = iterator5->Get(0);
    SC_LOG_DEBUG("myAgent: Process edge from " + m_memoryCtx.HelperGetSystemIdtf(root) + " to " + m_memoryCtx.HelperGetSystemIdtf(child));
    if (child == parent)
    {
      SC_LOG_DEBUG("myAgent: parent");
      continue;
    }
    
    ScIterator5Ptr it_1 = m_memoryCtx.Iterator5(root, ScType::EdgeDCommonConst, child, ScType::EdgeAccessConstPosPerm, tree);
    if (it_1->Next())
    {
      SC_LOG_DEBUG("myAgent: child");
      compute_fup(child, root);
      fup[root.Hash()] = min(fup[root.Hash()], fup[child.Hash()]);
    }
    else
    {
      SC_LOG_DEBUG("myAgent: parent");
      fup[root.Hash()] = min(fup[root.Hash()], tin[child.Hash()]);
    }
  }
}

void MyAgent::find_bridges()
{
  ScIterator3Ptr iterator3 = m_memoryCtx.Iterator3(tree, ScType::EdgeAccessConstPosPerm, ScType::EdgeDCommonConst);
  while (iterator3->Next())
  {
    ScAddr treeEdge = iterator3->Get(2);
    ScAddr source;
    ScAddr target;

    m_memoryCtx.GetEdgeInfo(treeEdge, source, target);

    SC_LOG_DEBUG("myAgent: Process edge from " + m_memoryCtx.HelperGetSystemIdtf(source) + " to " + m_memoryCtx.HelperGetSystemIdtf(target));

    SC_LOG_DEBUG("myAgent: tin of source is " + to_string(tin[source.Hash()]));
    SC_LOG_DEBUG("myAgent: fup of target is " + to_string(fup[target.Hash()]));
    if (fup[target.Hash()] > tin[source.Hash()])
    {
      ScIterator5Ptr it5 = m_memoryCtx.Iterator5(source, ScType::EdgeUCommonConst, target, ScType::EdgeAccessConstPosPerm, param);
      if (!it5->Next())
      {
        it5 = m_memoryCtx.Iterator5(target, ScType::EdgeUCommonConst, source, ScType::EdgeAccessConstPosPerm, param);
        if (!it5->Next())
          SC_LOG_ERROR("Can not find edge");
      }
      ScAddr edge = it5->Get(1);
      ScAddr edgeParam = it5->Get(3);
      SC_LOG_DEBUG("myAgent: edge between " + m_memoryCtx.HelperGetSystemIdtf(source) + " and " + m_memoryCtx.HelperGetSystemIdtf(target) + " is bridge");
      ScAddr bridgeMark = m_memoryCtx.CreateEdge(ScType::EdgeAccessConstPosPerm, Keynodes::rrel_bridge, edgeParam);
      SC_LOG_INFO("hash is " << bridgeMark.Hash() );
      SC_LOG_INFO("hash is " << edge.Hash() );
      //answer.push_back(bridgeMark);
      answer.push_back(edge); 
      answer.push_back(source); 
      answer.push_back(target); 
    }
  }
}
}