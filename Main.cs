using System;
using UnityModManagerNet;
using XLShredLib;
using Harmony12;
using System.Reflection;

namespace XLEsc
{
    class Main
    {
        public static bool enabled;
        public static String modId;
        public static UnityModManager.ModEntry modEntry;

        private static EscapeMod escapeMod;

        static void Load(UnityModManager.ModEntry modEntry)
        {
            Main.modEntry = modEntry;
            Main.modId = modEntry.Info.Id;

            modEntry.OnToggle = OnToggle;
        }

        public static HarmonyInstance harmonyInstance;
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value == enabled) return true;
            enabled = value;

            if (enabled)
            {
                escapeMod = ModMenu.Instance.gameObject.AddComponent<EscapeMod>();
                harmonyInstance = HarmonyInstance.Create(modEntry.Info.Id);
                harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

            } else
            {
                harmonyInstance.UnpatchAll(harmonyInstance.Id);
                if (escapeMod != null)
                {
                    UnityEngine.Object.Destroy(ModMenu.Instance.GetComponent<EscapeMod>());
                }
            }
            return true;
        }
    }
}
