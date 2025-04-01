using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Windows.Forms;

namespace Modern.Forms
{
    public static class FunctionPortableTools
    {
        public static void StartPortableTool(string zipFileName, string exeName)
        {
            // Sökvägar
            string basePath = Application.StartupPath;
            string zipPath = Path.Combine(basePath, @"Resources\Program", zipFileName);
            string extractFolder = Path.GetFileNameWithoutExtension(zipFileName);
            string extractPath = Path.Combine(basePath, @"Resources\Program", extractFolder);

            try
            {
                // Packa upp ZIP om mappen inte redan finns
                if (!Directory.Exists(extractPath))
                {
                    if (File.Exists(zipPath))
                    {
                        ZipFile.ExtractToDirectory(zipPath, extractPath);
                    }
                    else
                    {
                        MessageBox.Show($"Zip-filen hittades inte:\n{zipPath}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Leta efter EXE-filen i alla undermappar
                string exeFullPath = Directory.GetFiles(extractPath, exeName, SearchOption.AllDirectories).FirstOrDefault();

                if (exeFullPath != null)
                {
                    Process.Start(exeFullPath);
                }
                else
                {
                    MessageBox.Show($"EXE-filen hittades inte:\n{exeName}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fel vid uppstart:\n{ex.Message}", "Fel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
