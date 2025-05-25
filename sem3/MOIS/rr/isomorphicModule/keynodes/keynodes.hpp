/*
 * This source file is part of an OSTIS project. For the latest info, see
 * http://ostis.net Distributed under the MIT License (See accompanying file
 * COPYING.MIT or copy at http://opensource.org/licenses/MIT)
 */

#pragma once

#include <sc-memory/sc_addr.hpp>
#include <sc-memory/sc_object.hpp>

#include "keynodes.generated.hpp"

namespace isomorphicModule
{
class Keynodes : public ScObject
{
  SC_CLASS()
  SC_GENERATED_BODY()

public:
  SC_PROPERTY(Keynode("question_find_isomorphic"), ForceCreate)
  static ScAddr question_find_isomorphic;

  SC_PROPERTY(Keynode("nrel_search_result"), ForceCreate)
  static ScAddr nrel_search_result;

  SC_PROPERTY(Keynode("empty_set"), ForceCreate)
  static ScAddr empty_set;
};

}  // namespace isomorphicModule
