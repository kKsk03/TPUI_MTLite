# TeknoParrotUI

Open Source JVS / Other I/O emulator for Windows. Works in collaboration with [TeknoParrot](https://teknoparrot.com) and [OpenParrot](https://github.com/teknogods/OpenParrot).

[TeknoParrot Discord](https://discord.gg/kmWgGDe), development discussion is in the ``#openparrot-dev`` channel.

## Dependencies

[discord-rpc-win](https://github.com/discordapp/discord-rpc/releases/download/v3.4.0/discord-rpc-win.zip)

Extract ``discord-rpc.dll`` (``win32-dynamic\bin\discord-rpc.dll``) into TeknoParrotUI's bin folder

## Notes for contributors

When adding a new GameProfile, create a description file and fill in as much details as possible

If possible, also add the game's icon to the [Icons](https://github.com/teknogods/TeknoParrotUIThumbnails/tree/master/Icons) repository.

When updating a GameProfile, increment the ``GameProfileRevision``.

Do not commit any GameProfile/Descriptions changes to the ``TeknoParrotUi.Common.csproj`` file. The files will be added automatically when the project is reloaded.

## Added translations for Game Settings / Joystick Control

### Game Settings

In `TeknoParrotUi.Common\ConfigTemplate.cs`:  

Category Name:  
```cs
private static readonly Dictionary<string, string> CategoryTranslations = new Dictionary<string, string>
{
    { "Resolution", "分辨率" },
    { "Authentication", "认证" },
    { "General", "常规" },
    // You can continue to add
    // format: { "<CategoryName>", "<Translated Name>" },
};
```

Field Name:  
```cs
private static readonly Dictionary<string, string> FieldTranslations = new Dictionary<string, string>
{
    { "RES", "游戏窗口分辨率" },
    { "GameVersion", "游戏版本" },
    { "NetworkAdapterIP", "网络适配器IP" },
    { "ServerHost", "游戏服务器认证地址" },
    { "TerminalMode", "终端机模式" },
    { "WhiteScreenFix", "白屏修复" },
    { "Windowed", "窗口化模式" },
    { "FpsLimitEnable", "帧率限制" },
    { "Input API", "输入模式" },
    { "Use Keyboard/Button For Axis", "使用键盘操控" },
    { "Keyboard/Button Axis Wheel Sensitivity", "键盘转向灵敏度" },
    { "Keyboard/Button Axis Pedal Sensitivity", "键盘油门刹车灵敏度" },
    // You can continue to add
    // format: { "<FieldName>", "<Translated Name>" },
};
```

### Joystick Control

In `TeknoParrotUi.Common\JoystickMapping.cs`:  

```cs
private static readonly Dictionary<string, string> ButtonNameTranslations = new Dictionary<string, string>
{
    { "Test", "机修按钮" },
    { "Service", "服务按钮" },
    { "Coin", "投币按钮" },
    { "Wheel Axis", "转向（向左打方向即可）" },
    { "Wheel Axis Left", "转向（左）" },
    { "Wheel Axis Right", "转向（右）" },
    { "Gas", "油门" },
    { "Brake", "刹车" },
    { "Test Menu Up", "机修菜单 向上" },
    { "Test Menu Down", "机修菜单 向下" },
    { "Enter Switch", "机修菜单 确认" },
    { "Gear Shift 1", "H档 - 1档" },
    { "Gear Shift 2", "H档 - 2档" },
    { "Gear Shift 3", "H档 - 3档" },
    { "Gear Shift 4", "H档 - 4档" },
    { "Gear Shift 5", "H档 - 5档" },
    { "Gear Shift 6", "H档 - 6档" },
    { "Gear Shift Up", "升档" },
    { "Gear Shift Down", "降档" },
    { "Perspective Switch Button", "视角切换" },
    { "Interuption Switch Button", "闯入切换" },
    // You can continue to add
    // format: { "<ButtonName>", "<Translated Name>" },
};
```
