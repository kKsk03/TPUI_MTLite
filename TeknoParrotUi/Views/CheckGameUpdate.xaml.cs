using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TeknoParrotUi.Views
{
    /// <summary>
    /// CheckGameUpdate.xaml 的交互逻辑
    /// </summary>
    public partial class CheckGameUpdate : Window
    {
        public CheckGameUpdate()
        {
            InitializeComponent();
            this.Loaded += CheckGameUpdate_Loaded;
        }

        private void CheckGameUpdate_Loaded(object sender, RoutedEventArgs e)
        {
            // 获取窗口句柄
            var hwnd = new WindowInteropHelper(this).Handle;

            // 获取当前窗口样式
            int currentStyle = GetWindowLong(hwnd, GWL_STYLE);

            // 去掉关闭按钮
            SetWindowLong(hwnd, GWL_STYLE, currentStyle & ~WS_SYSMENU);
        }

        // 常量定义
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;

        // 调用 Win32 API
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
    }
}
