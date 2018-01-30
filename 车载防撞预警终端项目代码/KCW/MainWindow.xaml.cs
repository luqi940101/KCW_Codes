using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ADSDK.Bases;
using ADSDK.Device;
using ADSDK.Device.Reader;
using ADSDK.Device.Reader.Passive;
using System.IO;
using System.IO.Ports;
using System.Windows.Threading;




namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsDisposed { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            SystemPub.ADRcp = new PassiveRcp();
            SystemPub.ADRcp.RcpLogEventReceived += RcpLogEventReceived;
            SystemPub.ADRcp.RxRspParsed += RxRspEventReceived;
            InitCommunication();
            //Vehicle1.Stroke = Brushes.Red;
            //Vehicle1.Fill = Brushes.Red;

        }

        /*
        #region ---DoEvents_Subtitution---
           public static void DoEvents()
        {
             Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background,
                                         new Action(delegate { }));
        }
        #endregion
        */
        #region ---Communication---
        bool cAddNew = false;
        public string ReaderMode = "";
        private void InitCommunication()
        {
            UnInitCommunication();
            //Serial Port Initialization
            IniSettings.Communication = IniSettings.CommType.SERIAL;
            IniSettings.PortName = "COM10";
            IniSettings.BaudRate = 9600;
            SystemPub.ADSio = new ADCom();
            SystemPub.ADSio.StatusConnected += Instance_Connected;
            SystemPub.ADRcp.Sio = SystemPub.ADSio;
            cAddNew = true;
        }
        #endregion
        private void UnInitCommunication()
        {
            if (!cAddNew) return;
            SystemPub.ADSio.StatusConnected -= Instance_Connected;
            cAddNew = false;
        }

        #region ---DoEvents_Subtitution---
        public void DoEvents()
        {
            DispatcherFrame frame = new DispatcherFrame();
            Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                new DispatcherOperationCallback(ExitFrame), frame);
            Dispatcher.PushFrame(frame);
        }

        public object ExitFrame(object f)
        {
            ((DispatcherFrame)f).Continue = false;

            return null;
        }
        #endregion

        void RcpLogEventReceived(object sender, StringEventArg e)
        {
            DisplayMsgString(e.Data);
        }

        private void DisplayMsgString(string data)
        {
            throw new NotImplementedException();
        }

        void RxRspEventReceived(object sender, ProtocolEventArg e)
        {
            /*
            if (this.IsDisposed)
                return;

            if (!this.InvokeRequired)
            {
                __ParseRsp(e.Protocol);
                return;
            }

            this.Invoke(new MethodInvoker(delegate ()
            {
                __ParseRsp(e.Protocol);
            }));
            */
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            BtnClose.IsEnabled = false;
           /*
            if (SystemPub.ADSio.bConnected)
            {
                SystemPub.ADSio.DisConnect();
            }
            */
            System.Windows.Application.Current.Shutdown();
        }
        
        private void BtnReadCard_Click(object sender, RoutedEventArgs e)
        {
            BtnReadCard.IsEnabled = false;
            CardID.Text = "";
            //Application.DoEvents();
            PassiveCommand.Identify6C(SystemPub.ADRcp);
            //if (!SystemPub.ADRcp.SendBytePkt(PassiveRcp.Identify6C(SystemPub.ADRcp.Address))) { }

            //  Bt_Read_Card.Enabled = true;
        }

        private void CardID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private bool m_bStopComm = false;
        private void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            BtnConnect.IsEnabled = false;
            DoEvents();
            if (SystemPub.ADSio.bConnected)
            {
                SystemPub.ADSio.DisConnect();
                m_bStopComm = true;
            }
            else
            {

                m_bStopComm = false;
                SystemPub.ADRcp.Sio = SystemPub.ADSio;
                SystemPub.ADSio.Connect(IniSettings.HostName, IniSettings.HostPort);
                DoEvents();
                //if (!SystemPub.ADSio.bConnected && IniSettings.Communication == IniSettings.CommType.NET) fwt.ShowDialog();
                //DoEvents();
            }
            /*
            //tsmiConnect.Enabled = false;
            DoEvents();            
            if (SystemPub.ADSio.bConnected)
            {
                SystemPub.ADSio.DisConnect();
                // m_bStopComm = true;
            }
            else
            {
                //  m_bStopComm = false;
                //SystemPub.ADRcp.Sio = SystemPub.ADSio;
                SystemPub.ADSio.Connect(IniSettings.HostName, IniSettings.HostPort);
             //   DoEvents();
                //if (!SystemPub.ADSio.bConnected && IniSettings.Communication == IniSettings.CommType.NET) RFID_Com_Label.Foreground = Brushes.Red;
                //DoEvents();
            }
            */
        }
        void Instance_Connected(object sender, ConnectEventArg e)
        {
            RFID_Com_Label.Foreground = Brushes.Red;
        }


    }
}
