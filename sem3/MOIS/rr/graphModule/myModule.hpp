#pragma once

#include <sc-memory/sc_module.hpp>

#include "myModule.generated.hpp"

class MyModule : public ScModule
{
  SC_CLASS(LoadOrder(11))
  SC_GENERATED_BODY()

  virtual sc_result InitializeImpl() override;
  virtual sc_result ShutdownImpl() override;
};