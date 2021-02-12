using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyMoacapApp_V2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Windows.UI.Xaml.Media.SolidColorBrush red = new SolidColorBrush(Windows.UI.Colors.Red);
        Windows.UI.Xaml.Media.SolidColorBrush green = new SolidColorBrush(Windows.UI.Colors.Green);


        private Imotraf.Device.MoCapU unit1, unit2, unit3, unit4, unit5, unit6, unit7, unit8, unit9;

        public MainPage()
        {
            this.InitializeComponent();
        }

        //ButtonMPU1
        private void MPUBtn1_Click(object sender, RoutedEventArgs e)
        {
            Imotraf.Device.IDevice arduino = new Imotraf.Device.Arduino();
            unit1 = new Imotraf.Device.MoCapU(arduino);
            unit1.ConnectionEstablished += UnitOneConnected;
            unit1.ConnectionLost += UnitOneConnectionLost;
            unit1.ConnectMoCapUnit("192.168.1.130", 3001);
        }

        //MethodOne-Connected wifi
        private void UnitOneConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit One Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox1, MPUBtn1, msg);
           // MPUTxtBox1.Text = MPUTxtBox1.Text.ToString() + "\n" + msg;
           // MPUBtn1.Background = green;
          
        }
        //MethodTOne-Connection Lost
        private void UnitOneConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox1.Text = MPUTxtBox1.Text.ToString() + "\n" + msg;
            MPUBtn1.Background = red;
        }

        //ButtonMPU2 //Dome
        private void MPUBtn2_Click(object sender, RoutedEventArgs e)
        {
            Imotraf.Device.IDevice arduino = new Imotraf.Device.Arduino();
            unit2 = new Imotraf.Device.MoCapU(arduino);
            unit2.ConnectionEstablished += UnitTwoConnected;
            unit2.ConnectionLost += UnitTwoConnectionLost;
            unit2.ConnectMoCapUnit("192.168.1.129", 3038);

        }
        //MethodTwo Coonected wifi
        private void UnitTwoConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit Two Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox2, MPUBtn2, msg);
            

        }
        ///MethodTwo Connection Lost
        private void UnitTwoConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox2.Text = MPUTxtBox2.Text.ToString() + "\n" + msg;
            MPUBtn2.Background = red;
        }

        //ButtonMPU3 //Done
        private void MPUBtn3_Click(object sender, RoutedEventArgs e)
        {
            unit3 = new Imotraf.Device.MoCapU(new Imotraf.Device.Arduino());
            unit3.ConnectionEstablished += UnitThreeConnected;
            unit3.ConnectionFailed += UnitThreeConnectionFailed;
            unit3.ConnectionLost += UnitThreeConnectionLost;
            unit3.ConnectMoCapUnit("192.168.1.109", 3037);
        }

        //MethodThree Connected wifi
        private void UnitThreeConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit Three Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox3, MPUBtn3, msg);

        }

        private async Task Update(TextBox tbx, Button btn, string msg)
        {
            await Task.Run(async () =>
            {
                await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                        () =>
                        {

                            tbx.Text = tbx.Text.ToString() + "\n" + msg;
                            btn.Background = green;
                        });
            });
        }

        //MethodThree Connection Lost
        private void UnitThreeConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox3.Text = MPUTxtBox3.Text.ToString() + "\n" + msg;
            MPUBtn3.Background = red;
        }

        private void UnitThreeConnectionFailed(string message)
        {
            string msg = "Connection Failed - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox3.Text = MPUTxtBox3.Text.ToString() + "\n" + msg;
            MPUBtn3.Background = red;
        }

        //ButtonMPU4 //DONE
        private void MPUBtn4_Click(object sender, RoutedEventArgs e)
        {
            Imotraf.Device.IDevice arduino = new Imotraf.Device.Arduino();
            unit4 = new Imotraf.Device.MoCapU(arduino);
            unit4.ConnectionEstablished += UnitFourthConnected;
            unit4.ConnectionLost += UnitFourthConnectionLost;
            unit4.ConnectMoCapUnit("192.168.1.115", 3031);
        }

        //MethodFour connected wifi
        private void UnitFourthConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit Fourth Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox4, MPUBtn4, msg);
        }

        //MethodFou Connection Lost
        private void UnitFourthConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox4.Text = MPUTxtBox4.Text.ToString() + "\n" + msg;
            MPUBtn4.Background = red;
        }

        //ButtonMPU5 /DONE
        private void MPUBtn5_Click(object sender, RoutedEventArgs e)
        {

            Imotraf.Device.IDevice arduino = new Imotraf.Device.Arduino();
            unit5 = new Imotraf.Device.MoCapU(arduino);
            unit5.ConnectionEstablished += UnitFourthConnected;
            unit5.ConnectionLost += UnitFivethConnectionLost;
            unit5.ConnectMoCapUnit("192.168.1.104", 3032);

        }
        //MethodFive Connected wifi
        private void UnitFivethConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit Five Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox5, MPUBtn5, msg);
        }
        //MethodFive Connection Lost
        private void UnitFivethConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox5.Text = MPUTxtBox5.Text.ToString() + "\n" + msg;
            MPUBtn5.Background = red;
        }

        //ButtonMPU6  //DONE
        private void MPUBtn6_Click(object sender, RoutedEventArgs e)
        {

            Imotraf.Device.IDevice arduino = new Imotraf.Device.Arduino();
            unit6 = new Imotraf.Device.MoCapU(arduino);
            unit6.ConnectionEstablished += UnitSixthConnected;
            unit6.ConnectionLost += UnitSixthConnectionLost;
            unit6.ConnectMoCapUnit("192.168.1.122", 3034); ;

        }
        //MethodSixth Connected wifi
        private void UnitSixthConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit Sixth Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox6, MPUBtn6, msg);
        }
        //MethodSixth Connection Losted
        private void UnitSixthConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox6.Text = MPUTxtBox6.Text.ToString() + "\n" + msg;
            MPUBtn6.Background = red;
        }

        //ButtonMPU7 //DONE
        private void MPUBtn7_Click(object sender, RoutedEventArgs e)
        {
            Imotraf.Device.IDevice arduino = new Imotraf.Device.Arduino();
            unit7 = new Imotraf.Device.MoCapU(arduino);
            unit7.ConnectionEstablished += UnitSeventhConnected;
            unit7.ConnectionLost += UnitSeventhConnectionLost;
            unit7.ConnectMoCapUnit("192.168.1.123", 3036); ;

        }
        //Connected wifi
        private void UnitSeventhConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit Seventh Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox7, MPUBtn7, msg);
          
        }
        //Connection Lost
        private void UnitSeventhConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox7.Text = MPUTxtBox7.Text.ToString() + "\n" + msg;
            MPUBtn7.Background = red;
        }

        //ButtonMPU8 //DONE
        private void MPUBtn8_Click(object sender, RoutedEventArgs e)
        {
            Imotraf.Device.IDevice arduino = new Imotraf.Device.Arduino();
            unit8 = new Imotraf.Device.MoCapU(arduino);
            unit8.ConnectionEstablished += UnitEighthConnected;
            unit8.ConnectionLost += UnitEighthConnectionLost;
            unit8.ConnectMoCapUnit("192.168.1.133", 3030); ;

        }
        //Method Eighth Connected wifi
        private void UnitEighthConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit eighth Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox8, MPUBtn8, msg);
            

        }
        //Method Eight Connection Lost
        private void UnitEighthConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox8.Text = MPUTxtBox8.Text.ToString() + "\n" + msg;
            MPUBtn8.Background = red;
        }

        //ButtonMPU9 //DONE
        private void MPUBtn9_Click(object sender, RoutedEventArgs e)
        {
            Imotraf.Device.IDevice arduino = new Imotraf.Device.Arduino();
            unit9 = new Imotraf.Device.MoCapU(arduino);
            unit9.ConnectionEstablished += UnitNinethConnected;
            unit9.ConnectionLost += UnitEighthConnectionLost;
            unit9.ConnectMoCapUnit("192.168.1.146", 3033); ;

        }
        //Method Nineth Connected wifi
        private void UnitNinethConnected()
        {
            System.Diagnostics.Debug.WriteLine("Unit nineth Connected");
            string msg = "Device Connected!";
            Task tt = Update(MPUTxtBox9, MPUBtn9, msg);
        }
        //Method Nineth Connection Lost
        private void UnitNinethConnectionLost(string message)
        {
            string msg = "Connection Lost - " + message;
            System.Diagnostics.Debug.WriteLine(msg);
            MPUTxtBox9.Text = MPUTxtBox9.Text.ToString() + "\n" + msg;
            MPUBtn9.Background = red;
        }
    }
}
