#include <memory>

#include "sc-memory/sc_memory.hpp"


#include "sc-memory/sc_event.hpp"




#define IsFunctionalAgent_hpp_13_init  bool _InitInternal(ScAddr const & outputStructure = ScAddr::Empty) override \
{ \
    ScMemoryContext ctx(sc_access_lvl_make_min, "IsFunctionalAgent::_InitInternal"); \
    ScSystemIdentifierFiver fiver; \
    bool result = true; \
     \
    return result; \
}


#define IsFunctionalAgent_hpp_13_initStatic static bool _InitStaticInternal(ScAddr const & outputStructure = ScAddr::Empty)  \
{ \
    ScMemoryContext ctx(sc_access_lvl_make_min, "IsFunctionalAgent::_InitStaticInternal"); \
    ScSystemIdentifierFiver fiver; \
    bool result = true; \
    return result; \
}


#define IsFunctionalAgent_hpp_13_decl \
private:\
	typedef ScAgent Super;\
protected: \
	IsFunctionalAgent(char const * name, sc_uint8 accessLvl) : Super(name, accessLvl) {}\
	virtual sc_result Run(ScAddr const & listenAddr, ScAddr const & edgeAddr, ScAddr const & otherAddr) override; \
private:\
	static std::unique_ptr<ScEvent> ms_event;\
    static std::unique_ptr<ScMemoryContext> ms_context;\
public: \
	static bool handler_emit(ScAddr const & addr, ScAddr const & edgeAddr, ScAddr const & otherAddr)\
	{\
		IsFunctionalAgent Instance("IsFunctionalAgent", sc_access_lvl_make_min);\
		return Instance.Run(addr, edgeAddr, otherAddr) == SC_RESULT_OK;\
	}\
	static void RegisterHandler()\
	{\
		ms_context.reset(new ScMemoryContext(sc_access_lvl_make_min, "handler_IsFunctionalAgent"));\
		ms_event.reset(new ScEvent(*ms_context, Keynodes::question_is_functional, ScEvent::Type::AddOutputEdge, &IsFunctionalAgent::handler_emit));\
        if (ms_event.get())\
        {\
            SC_LOG_INFO("Register agent IsFunctionalAgent");\
        }\
        else\
        {\
            SC_LOG_ERROR("Can't register agent IsFunctionalAgent");\
        }\
	}\
	static void UnregisterHandler()\
	{\
		ms_event.reset();\
		ms_context.reset();\
	}

#define IsFunctionalAgent_hpp_IsFunctionalAgent_impl \
std::unique_ptr<ScEvent> IsFunctionalAgent::ms_event;\
std::unique_ptr<ScMemoryContext> IsFunctionalAgent::ms_context;

#undef ScFileID
#define ScFileID IsFunctionalAgent_hpp

