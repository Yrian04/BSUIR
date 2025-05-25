#pragma once

#include <sc-memory/sc_module.hpp>

#include "agentsModule.generated.hpp"

class AgentsModule : public ScModule
{
  SC_CLASS(LoadOrder(11))
  SC_GENERATED_BODY()

  virtual sc_result InitializeImpl() override;
  virtual sc_result ShutdownImpl() override;
};