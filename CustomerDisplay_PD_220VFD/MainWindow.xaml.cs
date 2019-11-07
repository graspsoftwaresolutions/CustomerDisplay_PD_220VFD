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
using System.IO.Ports;

namespace CustomerDisplay_PD_220VFD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SerialPort serialPort = new SerialPort();
        public MainWindow()
        {
            InitializeComponent();
            txtMessage.Text = "1234567890123456789012345678901234567890";
        }

        private void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (btnConnect.Content.ToString().Equals("Connect"))
            {
                btnConnect.Content = "Disconnect";
                if (serialPort.IsOpen)serialPort.Close();
                serialPort = new SerialPort(cbxCOMPort.Text);
                serialPort.Open();
            }
            else
            {
                btnConnect.Content = "Connect";
                serialPort.Close();
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                ClearScreen();
                serialPort.Write(txtMessage.Text);
            }            
        }
        void ClearScreen()
        {
            if (serialPort.IsOpen)
            {
                byte[] clearScreen = { 12 };
                serialPort.Write(clearScreen, 0, 1);
            }                
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearScreen();
        }
    }
}
