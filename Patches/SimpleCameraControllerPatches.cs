using Harmony12;
using GameManagement;

namespace XLEsc.Patches
{
    [HarmonyPatch(typeof(GameStateMachine), "Update")]

    class QuitGamePatch
    {
        static bool Prefix(GameStateMachine __instance)
        {
            bool flag = Main.enabled;
            bool result;
            if (flag)
            {
                __instance.CurrentState.OnUpdate();
                //Whatever you wanna do
                result = false;
            }
            else
            {
                result = true;
            }

            return result;
        }
    }
}
