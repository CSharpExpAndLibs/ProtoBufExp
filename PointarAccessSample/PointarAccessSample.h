#ifndef _LINUX_BUILD_
# pragma once
# ifdef POINTARACCESSSAMPLE_EXPORTS
#  define POINTARACCESSSAMPLE_API __declspec(dllexport)
# else
#  define POINTARACCESSSAMPLE_API __declspec(dllimport)
# endif // POINTARACCESSSAMPLE_EXPORTS
#else // _LINUX_BUILD_
# define POINTARACCESSSAMPLE_API
#endif // _LINUX_BUILD_

extern "C" {
    POINTARACCESSSAMPLE_API void ConvertContents(int size, int* data);
    POINTARACCESSSAMPLE_API void Dummy(int size);
}

