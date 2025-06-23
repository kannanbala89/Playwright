using Microsoft.Playwright;
using System.Collections.Generic;

namespace PlaywrightMSTestFramework.DeviceProfiles
{
    public static class DeviceLibrary
    {
        // Add or modify device profiles here
        public static readonly Dictionary<string, DeviceDescriptor> Profiles = new()
        {
            ["Pixel 5"] = Playwright.Devices["Pixel 5"],
            ["iPhone 13 Pro"] = Playwright.Devices["iPhone 13 Pro"],
            ["iPad Pro 11"] = Playwright.Devices["iPad Pro 11"],
            ["Galaxy S9"] = Playwright.Devices["Galaxy S9"],
            // Custom desktop profile
            ["Desktop 1920x1080"] = new DeviceDescriptor
            {
                Name = "Desktop 1920x1080",
                UserAgent = "Desktop",
                Viewport = new ViewportSize { Width = 1920, Height = 1080 },
                DeviceScaleFactor = 1,
                IsMobile = false,
                HasTouch = false
            }
        };
    }
}
