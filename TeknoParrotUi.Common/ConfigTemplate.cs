using System.Collections.Generic;

namespace TeknoParrotUi.Common
{
    public enum FieldType
    {
        Text = 0,
        Numeric = 1,
        Bool = 2,
        Dropdown = 3,
        Slider = 4
    }
    public class FieldInformation
    {
        public string CategoryName { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public FieldType FieldType { get; set; }
        public int FieldMin { get; set; }
        public int FieldMax { get; set; }
        public List<string> FieldOptions { get; set; }
        public string Hint { get; set; }

        private static readonly Dictionary<string, string> CategoryTranslations = new Dictionary<string, string>
        {
            { "Resolution", "分辨率" },
            { "Authentication", "认证" },
            { "General", "常规" },
        };

        private static readonly Dictionary<string, string> FieldTranslations = new Dictionary<string, string>
        {
            { "RES", "游戏窗口分辨率" },
            { "GameVersion", "游戏版本" },
            { "NetID", "NetID" },
            { "NetworkAdapterIP", "网络适配器IP" },
            { "ServerHost", "游戏服务器认证地址" },
            { "TerminalMode", "终端机模式" },
            { "WhiteScreenFix", "白屏修复" },
            { "Windowed", "窗口化模式" },
            { "FpsLimitEnable", "帧率限制至60FPS" },
            { "Input API", "输入模式" },
            { "Use Keyboard/Button For Axis", "使用键盘操控" },
            { "Keyboard/Button Axis Wheel Sensitivity", "键盘转向灵敏度" },
            { "Keyboard/Button Axis Pedal Sensitivity", "键盘油门刹车灵敏度" },
        };

        public string DisplayCategoryName
        {
            get
            {
                if (CategoryTranslations.TryGetValue(CategoryName, out var translated))
                {
                    return translated;
                }
                return CategoryName;
            }
        }

        public string DisplayFieldName
        {
            get
            {
                if (FieldTranslations.TryGetValue(FieldName, out var translated))
                {
                    return translated;
                }
                return FieldName;
            }
        }
    }
}
