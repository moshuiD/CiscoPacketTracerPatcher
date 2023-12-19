using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace CiscoPacketTracerPatcher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr ptr);
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool Wow64RevertWow64FsRedirection(IntPtr ptr);

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IntPtr oldWOW64State = new IntPtr();
            Wow64DisableWow64FsRedirection(ref oldWOW64State);
            File.WriteAllBytes(Environment.CurrentDirectory + "\\version.dll", ShellCode.data);
            File.Copy("C:\\Windows\\System32\\version.dll", Environment.CurrentDirectory + "\\versionOrg.dll");
            Wow64DisableWow64FsRedirection(ref oldWOW64State);
            MessageBox.Show("Done!");
            Environment.Exit(0);
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/moshuiD/CiscoPacketTracerPatcher");
        }

    }
}
