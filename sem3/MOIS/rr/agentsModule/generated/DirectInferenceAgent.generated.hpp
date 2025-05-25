#include <memory>

#include "sc-memory/sc_memory.hpp"


#include "sc-memory/sc_event.hpp"




#define DirectInferenceAgent_hpp_20_init  bool _InitInternal(ScAddr const & outputStructure = ScAddr::Empty) override \
{ \
    ScMemoryContext ctx(sc_access_lvl_make_min, "MyDirectInferenceAgent::_InitInternal"); \
    ScSystemIdentifierFiver fiver; \
    bool result = true; \
    return result; \
}


#define DirectInferenceAgent_hpp_20_initStatic static bool _InitStaticInternal(ScAddr const & outputStructure = ScAddr::Empty)  \
{ \
    ScMemoryContext ctx(sc_access_lvl_make_min, "MyDirectInferenceAgent::_InitStaticInternal"); \
    ScSystemIdentifierFiver fiver; \
    bool result = true; \
    return result; \
}


#define DirectInferenceAgent_hpp_20_decl \
private:\
	typedef ScAgent Super;\
protected: \
	MyDirectInferenceAgent(char const * name, sc_uint8 accessLvl) : Super(name, accessLvl) {}\
	virtual sc_result Run(ScAddr const & listenAddr, ScAddr const & edgeAddr, ScAddr const & otherAddr) override; \
private:\
	static std::unique_ptr<ScEvent> ms_event;\
    static std::unique_ptr<ScMemoryContext> ms_context;\
public: \
	static bool handler_emit(ScAddr const & addr, ScAddr const & edgeAddr, ScAddr const & otherAddr)\
	{\
		MyDirectInferenceAgent Instance("MyDirectInferenceAgent", sc_access_lvl_make_min);\
		return Instance.Run(addr, edgeAddr, otherAddr) == SC_RESULT_OK;\
	}\
	static void RegisterHandler()\
	{\
		ms_context.reset(new ScMemoryContext(sc_access_lvl_make_min, "handler_MyDirectInferenceAgent"));\
		ms_event.reset(new ScEvent(*ms_context, InferenceKeynodes::action_my_direct_inference, ScEvent::Type::AddOutputEdge, &MyDirectInferenceAgent::handler_emit));\
        if (ms_event.get())\
        {\
            SC_LOG_INFO("Register agent MyDirectInferenceAgent");\
        }\
        else\
        {\
            SC_LOG_ERROR("Can't register agent MyDirectInferenceAgent");\
        }\
	}\
	static void UnregisterHandler()\
	{\
		ms_event.reset();\
		ms_context.reset();\
	}

#define DirectInferenceAgent_hpp_MyDirectInferenceAgent_impl \
std::unique_ptr<ScEvent> MyDirectInferenceAgent::ms_event;\
std::unique_ptr<ScMemoryContext> MyDirectInferenceAgent::ms_context;

#undef ScFileID
#define ScFileID DirectInferenceAgent_hpp

