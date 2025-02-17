﻿namespace TeknoParrotUi.Common
{
    public class ParrotData
    {
        public bool UseSto0ZDrivingHack { get; set; }
        public int StoozPercent { get; set; }
        public bool FullAxisGas { get; set; }
        public bool FullAxisBrake { get; set; }
        public bool ReverseAxisGas { get; set; }
        public bool ReverseAxisBrake { get; set; }

        public string LastPlayed { get; set; }
        public string ExitGameKey { get; set; } = "0x1B";
        public string PauseGameKey { get; set; } = "0x13";

        public bool SaveLastPlayed { get; set; }

        public bool UseDiscordRPC { get; set; }
        public bool SilentMode { get; set; }
        public bool CheckForUpdates { get; set; } = false;

        public bool ConfirmExit { get; set; } = true;
        public bool DownloadIcons { get; set; } = false;
        public bool UiDisableHardwareAcceleration { get; set; } = false;

        public string UiColour { get; set; } = "lightblue";
        public bool UiDarkMode { get; set; } = true;
        public bool UiHolidayThemes { get; set; } = false;
    }
}
