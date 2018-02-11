#pragma once


#ifndef LSXXX_H_
#define LSXXX_H_

#include "ls_structs.h"
#include <string>
#include <stdint.h>

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

extern "C" class __declspec(dllexport)  LSxxx
{
public:
	LSxxx();
	virtual ~LSxxx();
	INT32 connect(char* hostPC, int portPC);
	void disconnect();
	bool isConnected();
	void   send_data(void* vpSrc, UINT16 usCnt);
	INT32 read_data(void* vpSrc, UINT16 usCnt);

	INT32 ParaSync(PARA_SYNC_RSP *g_stRealPara);
	INT32 ParaConfiguration(PARA_SYNC_RSP *g_stRealPara);
	void  StartMeasureTransmission();
	INT32 GetLidarMeasData(PARA_SYNC_RSP *g_stRealPara, MEAS_DATA_NO_INTENSITY *g_stMeasDataNoIntensity, MEAS_DATA_HAVE_INTENSITY1  *g_stMeasDataHaveIntensity1, MEAS_DATA_HAVE_INTENSITY2   *g_stMeasDataHaveIntensity2);
	INT32 PackParaSyncReq(PARA_SYNC_REQ *vpstParaSyncReq, UINT8 *vpucBuff);
	INT32 PackParaConfigurationReq(PARA_CONFIGURATION_REQ *vpstParaConfigurationReq, UINT8 *vpucBuff);
	INT32 PackStartMeasureTransmissionReq(START_MEASURE_TRANSMISSION_REQ *vpstStartMeasureTransmissionReq, UINT8 *vpucBuff);
	INT32 UnpackParaSyncRsp(UINT8 *vpucMsg, PARA_SYNC_RSP *vpstParaSyncRsp);
	INT32 UnpackParaConfigurationRsp(UINT8 *vpucMsg, PARA_CONFIGURATION_RSP *vpstParaConfigurationRsp);
	INT32 UnpackMeasDataNoIntensity(UINT8 *vpucMsg, MEAS_DATA_NO_INTENSITY *vpstMeasDataNoIntensity);
	INT32 UnpackMeasDataHaveIntensity1(UINT8 *vpucMsg, MEAS_DATA_HAVE_INTENSITY1 *vpstMeasDataHaveIntensity1);
	INT32 UnpackMeasDataHaveIntensity2(UINT8 *vpucMsg, MEAS_DATA_HAVE_INTENSITY2 *vpstMeasDataHaveIntensity2);

protected:
	bool connected_;
	int socket_fd_;
};

#endif /* LSXXX_H_ */