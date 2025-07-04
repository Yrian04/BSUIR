/*
 * This source file is part of an OSTIS project. For the latest info, see
 * http://ostis.net Distributed under the MIT License (See accompanying file
 * COPYING.MIT or copy at http://opensource.org/licenses/MIT)
 */

#pragma once

#include <sc-memory/sc_addr.hpp>
#include <sc-memory/sc_object.hpp>

#include "keynodes.generated.hpp"

namespace myModule
{
class Keynodes : public ScObject
{
  SC_CLASS()
  SC_GENERATED_BODY()

public:
  SC_PROPERTY(Keynode("question_find_bridges"), ForceCreate)
  static ScAddr question_find_bridges;

  SC_PROPERTY(Keynode("rrel_bridge"), ForceCreate)
  static ScAddr rrel_bridge;

  SC_PROPERTY(Keynode("nrel_answer"), ForceCreate)
  static ScAddr nrel_answer;
};

}  // namespace exampleModule
