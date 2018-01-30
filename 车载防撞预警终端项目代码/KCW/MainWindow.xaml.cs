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




namespace WpfApplication4
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //tsmiConnect.Enabled = false;
            //Application.DoEvents();
            
            SystemPub.ADSio = new ADCom();
            if (SystemPub.ADSio.bConnected)
            {
                SystemPub.ADSio.DisConnect();
               // m_bStopComm = true;
            }
            else
            {
              //  m_bStopComm = false;
                SystemPub.ADRcp.Sio = SystemPub.ADSio;
                SystemPub.ADSio.Connect(IniSettings.HostName, IniSettings.HostPort);
              //  Application.DoEvents();
                if (!SystemPub.ADSio.bConnected && IniSettings.Communication == IniSettings.CommType.NET) RFID_Com_Label.Foreground = Brushes.Red;
                // Application.DoEvents();
            }
            //Vehicle1.Stroke = Brushes.Red;
            //Vehicle1.Fill = Brushes.Red;
            
        }
        

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            BtnClose.IsEnabled = false;
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

    }
}
