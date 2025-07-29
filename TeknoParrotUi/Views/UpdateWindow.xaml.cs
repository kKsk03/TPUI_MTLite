using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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
using static TeknoParrotUi.Views.GameRunning;

namespace TeknoParrotUi.Views
{
    /// <summary>
    /// UpdateWindow.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateWindow : Window
    {
        private List<UpdateFile> _filesToUpdate;
        private string _basePath;

        public UpdateWindow(List<UpdateFile> filesToUpdate, string basePath)
        {
            InitializeComponent();
            this.Loaded += CheckGameUpdate_Loaded;
            _filesToUpdate = filesToUpdate;
            _basePath = basePath;
            Loaded += UpdateWindow_Loaded;
        }

        private async void UpdateWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await DoUpdateFilesAsync(_filesToUpdate, _basePath);
            this.DialogResult = true;
        }

        private async Task DoUpdateFilesAsync(List<UpdateFile> files, string basePath)
        {
            var client = new HttpClient();
            try
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];

                    StatusText.Text = $"正在下载: {file.filename}";
                    ProgressBar.Value = (double)i / files.Count * 100;

                    try
                    {
                        string localPath = System.IO.Path.Combine(basePath, file.filePath, file.filename);

                        var dir = System.IO.Path.GetDirectoryName(localPath);
                        if (dir != null)
                        {
                            Directory.CreateDirectory(dir);
                        }

                        var response = await client.GetAsync(file.downloadUrl);
                        response.EnsureSuccessStatusCode();

                        using (var fs = new FileStream(localPath, FileMode.Create, FileAccess.Write))
                        {
                            await response.Content.CopyToAsync(fs);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"更新失败: {file.filename}\n{ex.Message}", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                ProgressBar.Value = 100;
                StatusText.Text = "更新完成";
                await Task.Delay(1000);
            }
            finally
            {
                client.Dispose();
            }
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
