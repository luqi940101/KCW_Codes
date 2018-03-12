#pragma once

//#include "ls_structs.h"
#include <string>
#include <stdint.h>
#include "ls_structs.h"

typedef enum
{
	undefined = 0,
	initialisation = 1,
	configuration = 2,
	idle = 3,
	rotated = 4,
	in_preparation = 5,
	ready = 6,
	ready_for_measurement = 7
} status_t;

extern "C" __declspec(dllexport) int LS_connect(const char* hostPC, int portPC);
extern "C" __declspec(dllexport) bool isConnected();
extern "C" __declspec(dllexport) int ParaSync(PARA_SYNC_RSP *g_stRealPara);
extern "C" __declspec(dllexport) int ParaConfiguration(PARA_SYNC_RSP *g_stRealPara);
extern "C" __declspec(dllexport) void StartMeasureTransmission();
extern "C" __declspec(dllexport) int GetLidarMeasData(PARA_SYNC_RSP *g_stRealPara, int *Distance);
extern "C" __declspec(dllexport) void disconnect();
//extern "C" __declspec(dllexport) INT32 read_data(void* vpSrc, UINT16 usCnt);