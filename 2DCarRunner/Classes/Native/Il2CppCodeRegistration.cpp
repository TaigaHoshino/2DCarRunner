﻿#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"










extern const Il2CppMethodPointer g_MethodPointers[];
extern const Il2CppMethodPointer g_ReversePInvokeWrapperPointers[];
extern const Il2CppMethodPointer g_Il2CppGenericMethodPointers[];
extern const InvokerMethod g_Il2CppInvokerPointers[];
extern const CustomAttributesCacheGenerator g_AttributeGenerators[];
extern const Il2CppMethodPointer g_UnresolvedVirtualMethodPointers[];
extern Il2CppInteropData g_Il2CppInteropData[];
extern const Il2CppCodeRegistration g_CodeRegistration = 
{
	18951,
	g_MethodPointers,
	7,
	g_ReversePInvokeWrapperPointers,
	11551,
	g_Il2CppGenericMethodPointers,
	2609,
	g_Il2CppInvokerPointers,
	3702,
	g_AttributeGenerators,
	578,
	g_UnresolvedVirtualMethodPointers,
	229,
	g_Il2CppInteropData,
};
extern const Il2CppMetadataRegistration g_MetadataRegistration;
static const Il2CppCodeGenOptions s_Il2CppCodeGenOptions = 
{
	true,
};
void s_Il2CppCodegenRegistration()
{
	il2cpp_codegen_register (&g_CodeRegistration, &g_MetadataRegistration, &s_Il2CppCodeGenOptions);
	#if IL2CPP_MONO_DEBUGGER
	extern const Il2CppDebuggerMetadataRegistration g_DebuggerMetadataRegistration;
	il2cpp_codegen_register_debugger_data(&g_DebuggerMetadataRegistration);
	#endif
}
#if RUNTIME_IL2CPP
static il2cpp::utils::RegisterRuntimeInitializeAndCleanup s_Il2CppCodegenRegistrationVariable (&s_Il2CppCodegenRegistration, NULL);
#endif
