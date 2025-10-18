using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace TeknoParrotUi.Views
{
    /// <summary>
    /// UpdateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private string targetGameVersion;
        private string currentDownloadingFile;

        public UpdateWindow(string newGameVersion)
        {
            InitializeComponent();
            targetGameVersion = FormatVersion(newGameVersion);
            TargetGameVersion.Text = $"正在更新至：Rev{targetGameVersion}";
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

        // 实时更新文件名
        public void UpdateCurrentFile(string fileName)
        {
            Dispatcher.Invoke(() =>
            {
                CurrentUpdatingFile.Text = $"正在更新：{fileName}";
            });
        }

        // 实时更新进度条
        public void UpdateProgress(int current, int total)
        {
            Dispatcher.Invoke(() =>
            {
                if (total <= 0) total = 1; // 防止除零
                double percent = (current * 100.0) / total;
                if (percent < 0) percent = 0;
                if (percent > 100) percent = 100;
                UpdateProgressBar.Value = percent;
            });
        }

        // 常量定义
        private const int GWL_STYLE = -16;

        private const int WS_SYSMENU = 0x80000;

        // 调用 Win32 API
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private string FormatVersion(string rawVersion)
        {
            if (string.IsNullOrEmpty(rawVersion) || rawVersion.Length != 5)
                return rawVersion; // 不合法就直接返回原值

            string major = rawVersion.Substring(0, 1);
            string minor = rawVersion.Substring(1, 2);
            string patch = rawVersion.Substring(3, 2);

            return $"{major}.{minor}.{patch}";
        }
    }
}