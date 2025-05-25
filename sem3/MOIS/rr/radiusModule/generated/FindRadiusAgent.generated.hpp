#include <memory>

#include "sc-memory/sc_memory.hpp"


#include "sc-memory/sc_event.hpp"




#define FindRadiusAgent_hpp_15_init  bool _InitInternal(ScAddr const & outputStructure = ScAddr::Empty) override \
{ \
    ScMemoryContext ctx(sc_access_lvl_make_min, "FindRadiusAgent::_InitInternal"); \
    ScSystemIdentifierFiver fiver; \
    bool result = true; \
     \
    return result; \
}


#define FindRadiusAgent_hpp_15_initStatic static bool _InitStaticInternal(ScAddr const & outputStructure = ScAddr::Empty)  \
{ \
    ScMemoryContext ctx(sc_access_lvl_make_min, "FindRadiusAgent::_InitStaticInternal"); \
    ScSystemIdentifierFiver fiver; \
    bool result = true; \
    return result; \
}


#define FindRadiusAgent_hpp_15_decl \
private:\
	typedef ScAgent Super;\
protected: \
	FindRadiusAgent(char const * name, sc_uint8 accessLvl) : Super(name, accessLvl) {}\
	virtual sc_result Run(ScAddr const & listenAddr, ScAddr const & edgeAddr, ScAddr const & otherAddr) override; \
private:\
	static std::unique_ptr<ScEvent> ms_event;\
    static std::unique_ptr<ScMemoryContext> ms_context;\
public: \
	static bool handler_emit(ScAddr const & addr, ScAddr const & edgeAddr, ScAddr const & otherAddr)\
	{\
		FindRadiusAgent Instance("FindRadiusAgent", sc_access_lvl_make_min);\
		return Instance.Run(addr, edgeAddr, otherAddr) == SC_RESULT_OK;\
	}\
	static void RegisterHandler()\
	{\
		ms_context.reset(new ScMemoryContext(sc_access_lvl_make_min, "handler_FindRadiusAgent"));\
		ms_event.reset(new ScEvent(*ms_context, Keynodes::question_find_radius, ScEvent::Type::AddOutputEdge, &FindRadiusAgent::handler_emit));\
        if (ms_event.get())\
        {\
            SC_LOG_INFO("Register agent FindRadiusAgent");\
        }\
        else\
        {\
            SC_LOG_ERROR("Can't register agent FindRadiusAgent");\
        }\
	}\
	static void UnregisterHandler()\
	{\
		ms_event.reset();\
		ms_context.reset();\
	}

#define FindRadiusAgent_hpp_FindRadiusAgent_impl \
std::unique_ptr<ScEvent> FindRadiusAgent::ms_event;\
std::unique_ptr<ScMemoryContext> FindRadiusAgent::ms_context;

#undef ScFileID
#define ScFileID FindRadiusAgent_hpp

