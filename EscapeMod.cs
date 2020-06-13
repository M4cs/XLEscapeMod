using UnityEngine;
using XLShredLib;

namespace XLEsc
{
    public class EscapeMod : MonoBehaviour
    {

        private bool shouldDisplayMenu;
        Rect EscapeMenuWindowRect;

        void Start()
        {
            shouldDisplayMenu = false;

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                shouldDisplayMenu = true;
                ModMenu.Instance.ShowCursor(Main.modId);
            }
        }

        private void OnGUI()
        {
            if (shouldDisplayMenu)
            {
                GUI.backgroundColor = Color.black;
                EscapeMenuWindowRect = GUI.Window(0, new Rect(25, 25, 220, 100), EscapeMenuWindow, "Confirm Close");
            }
        }

        private void EscapeMenuWindow(int windowID)
        {
            int x = (Screen.width - 50) / 2;
            int y = (Screen.height - 50) / 2;
            GUI.DragWindow(new Rect(x, y, 100, 50));
            if (GUI.Button(new Rect(10, 35, 100, 60), "NO"))
            {
                shouldDisplayMenu = false;
                ModMenu.Instance.HideCursor(Main.modId);
            }
            if (GUI.Button(new Rect(110, 35, 100, 60), "YES"))
            {
                Application.Quit();
            }
        }
    }
}
