using System;
using UnityModManagerNet;
using UnityEngine;
using Harmony12;
using System.Reflection;

namespace XLEsc
{
    class Main
    {
        public static bool enabled;

        private static EscapeMod escapeMod;

        static void Load(UnityModManager.ModEntry modEntry)
        {
            modEntry.OnToggle = OnToggle;
        }

        public static HarmonyInstance harmonyInstance;
        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
        {
            if (value == enabled) return true;
            enabled = value;

            if (enabled)
            {
                escapeMod = new GameObject().AddComponent<EscapeMod>();
                GameObject.DontDestroyOnLoad(escapeMod);
                harmonyInstance = HarmonyInstance.Create(modEntry.Info.Id);
                harmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

            } else
            {
                harmonyInstance.UnpatchAll(harmonyInstance.Id);
                if (escapeMod != null)
                {
                    GameObject.DestroyImmediate(escapeMod);
                }
            }
            return true;
        }
    }
}
