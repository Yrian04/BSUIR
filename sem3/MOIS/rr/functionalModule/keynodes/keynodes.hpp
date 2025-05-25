/*
 * This source file is part of an OSTIS project. For the latest info, see
 * http://ostis.net Distributed under the MIT License (See accompanying file
 * COPYING.MIT or copy at http://opensource.org/licenses/MIT)
 */

#pragma once

#include <sc-memory/sc_addr.hpp>
#include <sc-memory/sc_object.hpp>

#include "keynodes.generated.hpp"

namespace functionalModule
{
class Keynodes : public ScObject
{
  SC_CLASS()
  SC_GENERATED_BODY()

public:
  SC_PROPERTY(Keynode("question_is_functional"), ForceCreate)
  static ScAddr question_is_functional;

  SC_PROPERTY(Keynode("nrel_search_result"), ForceCreate)
  static ScAddr nrel_search_result;

  SC_PROPERTY(Keynode("functional_graph"), ForceCreate)
  static ScAddr functional_graph;

  SC_PROPERTY(Keynode("counterfunctional_graph"), ForceCreate)
  static ScAddr counterfunctional_graph;
};

}  // namespace functionalModule
