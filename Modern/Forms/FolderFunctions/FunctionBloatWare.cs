using System.Collections.Generic;
using System.Diagnostics;

public class AppInfo
{
    public string DisplayName { get; set; }
    public string PackageName { get; set; }
    public string Category { get; set; } // "Bloatware" eller "Program"
}

public static class FunctionBloatWare
{
    // === Lista: Program som installeras via winget ===
    public static List<AppInfo> GetProgramList()
    {
        return new List<AppInfo>
        {
            new AppInfo { DisplayName = "Google Chrome", PackageName = "Google.Chrome", Category = "Program" },
            new AppInfo { DisplayName = "Mozilla Firefox", PackageName = "Mozilla.Firefox", Category = "Program" },
            new AppInfo { DisplayName = "VLC Media Player", PackageName = "VideoLAN.VLC", Category = "Program" },
            new AppInfo { DisplayName = "7-Zip", PackageName = "7zip.7zip", Category = "Program" },
            new AppInfo { DisplayName = "WinRAR", PackageName = "RARLab.WinRAR", Category = "Program" },
            new AppInfo { DisplayName = "Notepad++", PackageName = "Notepad++.Notepad++", Category = "Program" },
            new AppInfo { DisplayName = "Visual Studio Code", PackageName = "Microsoft.VisualStudioCode", Category = "Program" },
            new AppInfo { DisplayName = "Spotify", PackageName = "Spotify.Spotify", Category = "Program" },
            new AppInfo { DisplayName = "Discord", PackageName = "Discord.Discord", Category = "Program" },
            new AppInfo { DisplayName = "Steam", PackageName = "Valve.Steam", Category = "Program" },
            new AppInfo { DisplayName = "PowerToys", PackageName = "Microsoft.PowerToys", Category = "Program" },
            new AppInfo { DisplayName = "GIMP", PackageName = "GIMP.GIMP", Category = "Program" },
            new AppInfo { DisplayName = "OBS Studio", PackageName = "OBSProject.OBSStudio", Category = "Program" },
            new AppInfo { DisplayName = "Brave Browser", PackageName = "Brave.Brave", Category = "Program" },
            new AppInfo { DisplayName = "qBittorrent", PackageName = "qBittorrent.qBittorrent", Category = "Program" }
        };
    }

    // === Lista: Bloatware att ta bort ===
    public static List<AppInfo> GetBloatwareList()
    {
        return new List<AppInfo>
        {
            new AppInfo { DisplayName = "3D Builder", PackageName = "", Category = "Bloatware" },
            new AppInfo { DisplayName = "3D Viewer", PackageName = "Microsoft.Microsoft3DViewer", Category = "Bloatware" },
            new AppInfo { DisplayName = "Films & TV", PackageName = "Microsoft.ZuneVideo", Category = "Bloatware" },
            new AppInfo { DisplayName = "Get Help", PackageName = "Microsoft.GetHelp", Category = "Bloatware" },
            new AppInfo { DisplayName = "Get Started", PackageName = "Microsoft.Getstarted", Category = "Bloatware" },
            new AppInfo { DisplayName = "Groove Music", PackageName = "Microsoft.ZuneMusic", Category = "Bloatware" },
            new AppInfo { DisplayName = "Microsoft News", PackageName = "Microsoft.BingNews", Category = "Bloatware" },
            new AppInfo { DisplayName = "Mixed Reality Portal", PackageName = "Microsoft.MixedReality.Portal", Category = "Bloatware" },
            new AppInfo { DisplayName = "Office Hub", PackageName = "Microsoft.MicrosoftOfficeHub", Category = "Bloatware" },
            new AppInfo { DisplayName = "People", PackageName = "Microsoft.People", Category = "Bloatware" },
            new AppInfo { DisplayName = "Skype", PackageName = "Microsoft.SkypeApp", Category = "Bloatware" },
            new AppInfo { DisplayName = "Solitaire Collection", PackageName = "Microsoft.MicrosoftSolitaireCollection", Category = "Bloatware" },
            new AppInfo { DisplayName = "Sticky Notes", PackageName = "Microsoft.MicrosoftStickyNotes", Category = "Bloatware" },
            new AppInfo { DisplayName = "Xbox App", PackageName = "Microsoft.XboxApp", Category = "Bloatware" },
            new AppInfo { DisplayName = "Xbox Game Overlay", PackageName = "Microsoft.XboxGameOverlay", Category = "Bloatware" },
            new AppInfo { DisplayName = "Xbox Gaming Overlay", PackageName = "Microsoft.XboxGamingOverlay", Category = "Bloatware" },
            new AppInfo { DisplayName = "Your Phone", PackageName = "Microsoft.YourPhone", Category = "Bloatware" }

        };
    }

    // === Installerar appar ===
    public static void InstallApps(List<string> selectedApps)
    {
        foreach (string app in selectedApps)
        {
            ProcessStartInfo psi;

            if (app.StartsWith("Microsoft."))
            {
                psi = new ProcessStartInfo
                {
                    FileName = "powershell.exe",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Get-AppxPackage -AllUsers '{app}' | ForEach-Object {{Add-AppxPackage -Register -DisableDevelopmentMode ($_.InstallLocation + '\\AppXManifest.xml')}}\"",
                    Verb = "runas",
                    UseShellExecute = true
                };
            }
            else
            {
                psi = new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    Arguments = $"/c winget install --id={app} --silent --accept-source-agreements --accept-package-agreements",
                    Verb = "runas",
                    UseShellExecute = true
                };
            }

            Process.Start(psi);
        }
    }

    // === Tar bort appar ===
    public static void RemoveApps(List<string> selectedApps)
    {
        foreach (string app in selectedApps)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-Command \"Get-AppxPackage -Name '{app}' | Remove-AppxPackage -ErrorAction SilentlyContinue; Get-AppxProvisionedPackage -Online | Where-Object {{$_.DisplayName -eq '{app}'}} | Remove-AppxProvisionedPackage -Online -ErrorAction SilentlyContinue\"",
                Verb = "runas",
                UseShellExecute = true
            });
        }
    }
}
