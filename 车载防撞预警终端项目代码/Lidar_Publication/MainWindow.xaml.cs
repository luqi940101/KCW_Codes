using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Windows.Threading;

namespace Lidar_Publication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        #region ---LS210 Lidar---
        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "LS_connect", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int LS_connect(string hostPC, int portPC);
        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "isConnected", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern bool isConnected();
        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "ParaSync", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int ParaSync(ref PARA_SYNC_RSP g_stRealPara);
        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "ParaConfiguration", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int ParaConfiguration(ref PARA_SYNC_RSP g_stRealPara);
        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "StartMeasureTransmission", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void StartMeasureTransmission();
        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "GetLidarMeasData", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern int GetLidarMeasData(ref PARA_SYNC_RSP g_stRealPara, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] int[] Distance);
        [DllImport("Osight_LS210_DLL.dll", EntryPoint = "disconnect", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        private static extern void disconnect();
        //LSxxx laser = new LSxxx();
        private void LS210()
        {
            PARA_SYNC_RSP g_stRealPara = new PARA_SYNC_RSP();
            //[System.Runtime.InteropServices.MarshalAs(UnmanagedType.ByValArray, SizeConst = 2000)]
            int[] Distance = new int[2000];

            //MEAS_DATA_NO_INTENSITY g_stMeasDataNoIntensity = new MEAS_DATA_NO_INTENSITY();

            //int[] res = new int[10];
            //POINT0[] DataIntensity0 = new POINT0[2000];

            int err;
            int loop_counter = 0;
            //byte i = 0;
            string hostPC = "192.168.1.100";

            Int32 portPC = 5500;
            byte IntensityStatus = 0;

            // Create a different thread
            while (true)
            {
                loop_counter++;
                err = LS_connect(hostPC, portPC);
                if (loop_counter >= 100 && err == 1)
                {
                    MessageBox.Show("激光雷达未连接");
                    IsLidarRuning = false;
                    this.Dispatcher.Invoke(new Action(delegate ()
                    {
                        BtnLidarConnect.IsEnabled = true;
                        DoEvents();
                    }));
                    break;
                }

                if (!isConnected())
                {
                    continue;
                }

                this.Dispatcher.Invoke(new Action(delegate ()
                {
                    LidarConnectionStatus.Text = "网口打开";
                    DoEvents();
                }));


                do
                {
                    err = ParaSync(ref g_stRealPara);
                } while (err != 0);
                this.Dispatcher.Invoke(new Action(delegate ()
                {
                    LidarConnectionStatus.Text = "参数同步成功";
                    DoEvents();
                }));

                //g_stRealPara.ucIntensityStatus = 0;
                //g_stRealPara.ucIntensityStatus = 1;
                //g_stRealPara.ucIntensityStatus = 2;

                g_stRealPara.ucIntensityStatus = IntensityStatus;

                do
                {
                    err = ParaConfiguration(ref g_stRealPara);
                } while (0 != err);
                this.Dispatcher.Invoke(new Action(delegate ()
                {
                    LidarConnectionStatus.Text = "参数配置成功";
                    DoEvents();
                }));

                StartMeasureTransmission();
                this.Dispatcher.Invoke(new Action(delegate ()
                {
                    LidarConnectionStatus.Text = "开始测量";
                    DoEvents();
                }));

                while (true)
                {
                    this.Dispatcher.Invoke(new Action(delegate ()
                    {
                        LidarConnectionStatus.Text = "开始测量";
                        DoEvents();
                    }));

                    err = GetLidarMeasData(ref g_stRealPara, Distance);
                    if (0 == err)
                    {

                        bool warning = false;
                        double[] angle_deg = Enumerable.Range(0, 1080).Select(x => x * 0.25-45).ToArray();
                        int warning_count = 0;
                        /*test: Print receiving ridar data */
                        for (int i = 0; i < 1080; i++)
                        {

                            double x_cor = Convert.ToInt16(0.005 * Distance[i] * Math.Cos(angle_deg[i] / 180 * Math.PI)); //0.001 单位：分米
                            double y_cor = Convert.ToInt16(0.005 * Distance[i] * Math.Sin(angle_deg[i] / 180 * Math.PI));


                            this.Dispatcher.Invoke(new Action(delegate ()
                            {
                                // LidarData.Text = Convert.ToString(Distance[i]);
                                //LidarData.Text = Convert.ToString(angle_deg[i]); 
                                Ellipse dataEllipse = new Ellipse();
                                dataEllipse.Fill = new SolidColorBrush(Color.FromRgb(0, 0, 0xff));
                                dataEllipse.Width = 4;
                                dataEllipse.Height = 4;

                                if (x_cor != 0 || y_cor != 0)
                                {
                                    Canvas.SetLeft(dataEllipse, 200 - x_cor - 2);//-2是为了补偿圆点的大小，到精确的位置
                                    Canvas.SetTop(dataEllipse, 250 - y_cor - 2);
                                }
                                

                                Point point_cloud = new Point(200 - x_cor, 250 - y_cor);
                                if (pt_poly.Count == 5)
                                {
                                    if (pnpoly(point_cloud, pt_poly.ToArray()))
                                    {

                                        //warning = true;
                                        warning_count++;
                                        WarningCount.Text = Convert.ToString(warning_count);

                                    }
                                    else
                                    {
                                        //polyline.Fill = null;

                                    }
                                }

                                //将数据点在画布中的位置保存下来
                                PointCloudCanvas.Children.Add(dataEllipse);

                            }));


                        }

                        this.Dispatcher.Invoke(new Action(delegate ()
                        {
                            if (warning_count>=10)
                            {
                                polyline.Fill = Brushes.Red;                                
                            }
                            else
                            {
                                polyline.Fill = null;
                            }

                            for (int index = 0; index <= PointCloudCanvas.Children.Count - 1; index++)
                            {

                                if (PointCloudCanvas.Children[index] is Ellipse)
                                {

                                    PointCloudCanvas.Children.RemoveAt(index);

                                }

                            }

                            warning_count = 0;
                        }));

                    }
                    else
                    {
                        //break;
                    }

                }

            }

        }


        private bool pnpoly(Point pt_test, Point[] pt_poly)
        {

            bool flag = false;
            double px;
            int n_vert = pt_poly.Length;

            if (n_vert <= 2) MessageBox.Show("Setting Warning Area");

            for (int i = 0; i < n_vert; i++)
            {

                int j = i + 1;
                if (j >= n_vert - 1) j = 0;

                if (pt_test.X == pt_poly[i].X && pt_test.Y == pt_poly[i].Y || pt_test.X == pt_poly[j].X && pt_test.Y == pt_poly[j].Y)
                {
                    flag = true;
                    return flag;
                }

                if ((pt_poly[i].Y < pt_test.Y && pt_poly[j].Y >= pt_test.Y) || (pt_poly[i].Y >= pt_test.Y && pt_poly[j].Y < pt_test.Y))
                {
                    px = pt_poly[i].X + (pt_test.Y - pt_poly[i].Y) * (pt_poly[j].X - pt_poly[i].X) / (pt_poly[j].Y - pt_poly[i].Y);
                    if (pt_test.X < px)
                    {
                        flag = !flag;
                    }
                    else if (pt_test.X == px)
                    {
                        flag = true;
                        return flag;

                    }
                }
            }

            return flag;
        }


        //private void test(){
        //    while(true)
        //    MessageBox.Show("Hello World");
        //}

        bool IsLidarRuning = false;
        private void BtnLidarConnect_Click(object sender, RoutedEventArgs e)
        {
            LidarConnectionStatus.Text = "";
            System.Threading.Thread LidarThread = new System.Threading.Thread(new System.Threading.ThreadStart(LS210));
            if (!IsLidarRuning)
            {
                LidarThread.Start();
                //BtnLidarConnect.Content = "断开激光雷达";
                BtnLidarConnect.IsEnabled = false;
            }
            else
            {
                disconnect();
                LidarThread.Abort();
                DoEvents();
                BtnLidarConnect.Content = "连接激光雷达";
            }
            IsLidarRuning = !IsLidarRuning;
            //LS210("192.168.1.100", 5500, 0);
        }


        List<Point> pt_poly = new List<Point>();
        List<Ellipse> polyEllipseList = new List<Ellipse>();
        bool IsSettingWarningArea = false;
        //private void PointCloudCanvas_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (flag == false)
        //        return;
        //    polyline.Points[polyline.Points.Count - 1] = e.GetPosition(PointCloudCanvas);
        //    Console.Write (polyline.Points[polyline.Points.Count - 1]);
        //}

        private void PointCloudCanvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (IsSettingWarningArea && polyline.Points.Count <= 5)
            {

                Ellipse polyEllipse = new Ellipse();
                polyEllipse.Fill = new SolidColorBrush(Color.FromRgb(0xff, 0, 0));
                polyEllipse.Width = 4;
                polyEllipse.Height = 4;
                Point p = Mouse.GetPosition(PointCloudCanvas);
                XCoordinate.Text = Convert.ToString(p.X);
                YCoordinate.Text = Convert.ToString(p.Y);
                Canvas.SetLeft(polyEllipse, p.X - 2);//-2是为了补偿圆点的大小，到精确的位置
                Canvas.SetTop(polyEllipse, p.Y - 2);
                PointCloudCanvas.Children.Add(polyEllipse);
                //MessageBox.Show("Left Down");          
                polyEllipseList.Add(polyEllipse);
                pt_poly.Add(p);
                polyline.Points.Add(p);
                //if (polyline.Points.Count == 1)  polyline.Points.Add(p);
                Console.WriteLine(p);

                if (polyline.Points.Count == 5)
                {
                    polyline.Points.Add(polyline.Points[0]);
                    IsSettingWarningArea = false;
                    BtnSetWarningArea.IsEnabled = true;

                }

                //PointCloudCanvas_MouseLeftButtonDown.IsEnabled = false;
            }
            else
            {

            }

            //Console.WriteLine("Left Down: " + e.GetPosition(PointCloudCanvas));
            //Console.WriteLine(polyline.Points.Count);
            // pt_poly.ForEach(i => Console.Write("{0}\t", i));
            //Console.WriteLine(polyline.Points);
            //Console.WriteLine(pt_poly[1].X);
            //Console.WriteLine(pt_poly[1].Y);
        }

        private void PointCloudCanvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

            Console.WriteLine("Right Down: " + e.GetPosition(PointCloudCanvas));
        }
        private void BtnSetWarningArea_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("请用鼠标在白色区域点击五个点，设置告警区域");
            BtnSetWarningArea.IsEnabled = false;
            IsSettingWarningArea = true;
            polyline.Points.Clear();
            foreach (Ellipse ellipse in polyEllipseList)
            {
                PointCloudCanvas.Children.Remove(ellipse);
            }
            pt_poly.Clear();
            polyline.Fill = null;
        }


        #endregion

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            BtnClose.IsEnabled = false;
            /*
             if (SystemPub.ADSio.bConnected)
             {
                 SystemPub.ADSio.DisConnect();
             }
             */
            //if (IsLidarRuning) {
            //    BtnLidarConnect_Click(sender, e);
            //}
            System.Environment.Exit(0);
            System.Windows.Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Point test_p;
            test_p.X = -101;
            test_p.Y = 159;
                //pnpoly(point_cloud, pt_poly.ToArray())
        }
    }
}
