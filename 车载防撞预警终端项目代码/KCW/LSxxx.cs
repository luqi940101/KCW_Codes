using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;




namespace WpfApplication4
{

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct ALARM_AREA_INFO
    {
        public byte ucAreaType;
        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
        public byte[] aucPara;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct PARA_SYNC_REQ
    {
        public UInt32 ulMsgId;
        public UInt16 usTransId;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct PARA_SYNC_RSP
    {
        public UInt32 ulMsgId;
        public UInt16 usTransId;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] aucMAC;

        public UInt32 ulSerialNum1;
        public UInt32 ulSerialNum2;
        public byte ucDevNum;
        public byte ucSoftwareVersion;
        public byte ucIndex;
        public byte ucLineNum;
        public UInt32 ulStartAngle;
        public UInt16 usVerticalAngle;
        public UInt16 usMaxDistance;
        public UInt32 ulPointNum;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 19)]
        public byte[] aucReserved;

        public byte ucCurrentSpeed;
        public byte ucIntensityStatus;
        public byte ucCurrentAreaId;
        public UInt32 ulAngularResolution;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.Struct)]
        public ALARM_AREA_INFO[] stAlarmArea;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct PARA_CONFIGURATION_REQ
    {

        public UInt32 ulMsgId;
        public UInt16 usTransId;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
        public byte[] aucReserved;

        public byte ucCurrentSpeed;
        public byte ucIntensityStatus;
        public byte ucCurrentAreaId;
        public UInt32 ulAngularResolution;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public ALARM_AREA_INFO[] stAlarmArea;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct PARA_CONFIGURATION_RSP
    {
        public UInt32 ulMsgId;
        UInt16 usTransId;
        public byte ucResult;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct START_MEASURE_TRANSMISSION_REQ
    {

        public UInt32 ulMsgId;
        public byte ucStart;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct POINT0
    {
        public UInt32 ulDistance;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct POINT1
    {
        public UInt32 ulDistance;
        public byte ucIntensity;
        public UInt32 ulOutputStatus;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct POINT2
    {
        public UInt32 ulDistance;
        public UInt16 usIntensity;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct MEAS_DATA_NO_INTENSITY
    {

        public UInt32 ulMsgId;
        public byte ucDevNum;
        public byte ucSoftwareVersion;
        public byte ucLineNum;
        public byte ucEcho;
        public UInt32 ulSerialNum1;
        public UInt32 ulSerialNum2;
        public byte ucIntensityStatus;
        public byte ucDevStatus;
        public UInt16 usScanCounter;
        public UInt32 ulTime;
        public UInt32 ulInputStatus;
        public UInt32 ulOutputStatus;
        public UInt32 ulStartAngle;
        public UInt16 usVerticalAngle;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] aucReserved;
        public UInt16 usPackMeasPointNum;
        public UInt32 ulAngularResolution;
        public byte ucTotalPackNum;
        public byte ucCurrentPackNO;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 350, ArraySubType = UnmanagedType.Struct)]
        POINT0[] astPoint0;
    }

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct MEAS_DATA_HAVE_INTENSITY1
    {

        public UInt32 ulMsgId;
        public byte ucDevNum;
        public byte ucSoftwareVersion;
        public byte ucLineNum;
        public byte ucEcho;
        public UInt32 ulSerialNum1;
        public UInt32 ulSerialNum2;
        public byte ucIntensityStatus;
        public byte ucDevStatus;
        public UInt16 usScanCounter;
        public UInt32 ulTime;
        public UInt32 ulInputStatus;
        public UInt32 ulOutputStatus;
        public UInt32 ulStartAngle;
        public UInt16 usVerticalAngle;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] aucReserved;

        public UInt16 usPackMeasPointNum;
        public UInt32 ulAngularResolution;
        public byte ucTotalPackNum;
        public byte ucCurrentPackNO;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 250, ArraySubType = UnmanagedType.Struct)]
        POINT1[] astPoint1;
    };

    [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
    public struct MEAS_DATA_HAVE_INTENSITY2
    {

        public UInt32 ulMsgId;
        public byte ucDevNum;
        public byte ucSoftwareVersion;
        public byte ucLineNum;
        public byte ucEcho;
        public UInt32 ulSerialNum1;
        public UInt32 ulSerialNum2;
        public byte ucIntensityStatus;
        public byte ucDevStatus;
        public UInt16 usScanCounter;
        public UInt32 ulTime;
        public UInt32 ulInputStatus;
        public UInt32 ulOutputStatus;
        public UInt32 ulStartAngle;
        public UInt16 usVerticalAngle;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public byte[] aucReserved;

        public UInt16 usPackMeasPointNum;
        public UInt32 ulAngularResolution;
        public byte ucTotalPackNum;
        public byte ucCurrentPackNO;

        [System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 250, ArraySubType = UnmanagedType.Struct)]
        POINT2[] astPoint2;
    }

    class LSxxx
    {

        LSxxx() {
            connected_ = false;
        }
        ~LSxxx() {
        }

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?connect@LSxxx@@QAEHPADH@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 connect(string hostPC, int portPC);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?disconnect@LSxxx@@QAEXXZ", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void disconnect();

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?isConnected@LSxxx@@QAE_NXZ", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern bool isConnected();

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?send_data@LSxxx@@QAEXPAXG@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void send_data(IntPtr vpSrc, UInt16 usCnt);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?read_data@LSxxx@@QAEHPAXG@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 read_data(IntPtr vpSrc, UInt16 usCnt);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?ParaSync@LSxxx@@QAEHUPARA_SYNC_RSP@@@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 ParaSync(PARA_SYNC_RSP g_stRealPara);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?ParaConfiguration@LSxxx@@QAEHUPARA_SYNC_RSP@@@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 ParaConfiguration(PARA_SYNC_RSP g_stRealPara);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?StartMeasureTransmission @LSxxx@@QAEXXZ", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern void StartMeasureTransmission();

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?GetLidarMeasData@LSxxx@@QAEHUPARA_SYNC_RSP@@UMEAS_DATA_NO_INTENSITY@@UMEAS_DATA_HAVE_INTENSITY1@@UMEAS_DATA_HAVE_INTENSITY2@@@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 GetLidarMeasData(PARA_SYNC_RSP g_stRealPara, MEAS_DATA_NO_INTENSITY g_stMeasDataNoIntensity, MEAS_DATA_HAVE_INTENSITY1 g_stMeasDataHaveIntensity1, MEAS_DATA_HAVE_INTENSITY2 g_stMeasDataHaveIntensity2);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?PackParaSyncReq@LSxxx@@QAEHPAUPARA_SYNC_REQ@@PAE@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 PackParaSyncReq(PARA_SYNC_REQ vpstParaSyncReq, byte[] vpucBuff);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?PackParaConfigurationReq@LSxxx@@QAEHPAUPARA_CONFIGURATION_REQ@@PAE@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 PackParaConfigurationReq(PARA_CONFIGURATION_REQ vpstParaConfigurationReq, byte[] vpucBuff);
        
        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?PackStartMeasureTransmissionReq@LSxxx@@QAEHPAUSTART_MEASURE_TRANSMISSION_REQ@@PAE@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 PackStartMeasureTransmissionReq(START_MEASURE_TRANSMISSION_REQ vpstStartMeasureTransmissionReq, byte[] vpucBuff);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?UnpackParaSyncRsp@LSxxx@@QAEHPAEPAUPARA_SYNC_RSP@@@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 UnpackParaSyncRsp(byte[] vpucMsg, PARA_SYNC_RSP vpstParaSyncRsp);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?UnpackParaConfigurationRsp@LSxxx@@QAEHPAEPAUPARA_CONFIGURATION_RSP@@@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 UnpackParaConfigurationRsp(byte[] vpucMsg, PARA_CONFIGURATION_RSP vpstParaConfigurationRsp);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?UnpackMeasDataNoIntensity@LSxxx@@QAEHPAEPAUMEAS_DATA_NO_INTENSITY@@@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 UnpackMeasDataNoIntensity(byte[] vpucMsg, MEAS_DATA_NO_INTENSITY vpstMeasDataNoIntensity);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?UnpackMeasDataHaveIntensity1@LSxxx@@QAEHPAEPAUMEAS_DATA_HAVE_INTENSITY1@@@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 UnpackMeasDataHaveIntensity1(byte[] vpucMsg, MEAS_DATA_HAVE_INTENSITY1 vpstMeasDataHaveIntensity1);

        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "?UnpackMeasDataHaveIntensity2@LSxxx@@QAEHPAEPAUMEAS_DATA_HAVE_INTENSITY2@@@Z", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public static extern Int32 UnpackMeasDataHaveIntensity2(byte[] vpucMsg, MEAS_DATA_HAVE_INTENSITY2 vpstMeasDataHaveIntensity2);

        public bool connected_;
        public int socket_fd_;
    }
}
