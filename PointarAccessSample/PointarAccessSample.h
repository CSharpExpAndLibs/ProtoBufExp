#pragma once
#ifdef POINTARACCESSSAMPLE_EXPORTS
#define POINTARACCESSSAMPLE_API __declspec(dllexport)
#else
#define POINTARACCESSSAMPLE_API __declspec(dllimport)
#endif

extern "C" POINTARACCESSSAMPLE_API void __cdecl ConvertContents(int size, int* data);

