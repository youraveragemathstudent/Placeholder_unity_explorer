using BepInEx;
using UnityEngine;
using System.IO;

namespace UnityExplorerToggle
{
    [BepInPlugin("yourname.ultrakill.unityexplorertoggle", "Unity Explorer Toggle", "1.0.0")]
    public class Main : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Unity Explorer Toggle Loaded!");

            string pluginsDir = Path.Combine(Paths.BepInExRootPath, "plugins");
            string explorerDir = Path.Combine(pluginsDir, "UnityExplorer.BepInEx5.Mono");
            string disabledDir = Path.Combine(pluginsDir, "UnityExplorer.BepInEx5.Mono_DISABLED");

            try
            {
                if (Directory.Exists(explorerDir))
                {
                    Directory.Move(explorerDir, disabledDir);
                    Logger.LogInfo("✅ UnityExplorer has been DISABLED.");
                }
                else if (Directory.Exists(disabledDir))
                {
                    Directory.Move(disabledDir, explorerDir);
                    Logger.LogInfo("✅ UnityExplorer has been ENABLED.");
                }
                else
                {
                    Logger.LogWarning("⚠️ UnityExplorer folder not found.");
                }
            }
            catch (IOException e)
            {
                Logger.LogError("❌ Toggle failed: " + e.Message);
            }
        }
    }
}
