// dllmain.cpp : DLL アプリケーションのエントリ ポイントを定義します。
#ifndef _LINUX_BUILD_
#include "pch.h"
#include "PointarAccessSample.h"
#include "stdio.h"

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}
#else
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "PointarAccessSample.h"
#endif // _LINUX_BUILD_

void Dummy(int size)
{
    printf("size=%d\n", size);
}

void ConvertContents(int size, int* data)
{
    for (int i = 0; i < size; i++) {
        data[i] = 2 * data[i];
    }
}

