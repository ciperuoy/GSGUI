using BepInEx;
using GorillaNetworking;
using UnityEngine;

namespace GamemodeSelectorGUI
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version)]
    public class Plugin : BaseUnityPlugin
    {

        public void Start()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        int currentPage = 0;
        bool guiEnabled = true;
        Rect windowRect = new Rect(50, 50, 250, 240); // x, y, width, height

        public void OnGUI()
        {
            if (guiEnabled)
            {
                windowRect = GUI.Window(0, windowRect, DrawWindow, Constants.Name);
            }
        }

        void DrawWindow(int windowID)
        {
            GUI.color = Color.gray;
            GUI.Label(new Rect(10, 15, 150, 20), Constants.Version);
            GUI.Label(new Rect(165, 15, 150, 20), "ciperuoy");

            if (currentPage == 0)
            {
                if (GUI.Button(new Rect(10, 40, 230, 30), "Casual"))
                    GorillaComputer.instance.currentGameMode.Value = "Casual";

                if (GUI.Button(new Rect(10, 75, 230, 30), "Infection"))
                    GorillaComputer.instance.currentGameMode.Value = "Infection";

                if (GUI.Button(new Rect(10, 110, 230, 30), "Guardian"))
                    GorillaComputer.instance.currentGameMode.Value = "Guardian";

                if (GUI.Button(new Rect(10, 145, 230, 30), "Freezetag"))
                    GorillaComputer.instance.currentGameMode.Value = "Freezetag";
            }
            else if (currentPage == 1)
            {
                if (GUI.Button(new Rect(10, 40, 230, 30), "Modded Casual"))
                    GorillaComputer.instance.currentGameMode.Value = "MODDED_Casual";

                if (GUI.Button(new Rect(10, 75, 230, 30), "Modded Infection"))
                    GorillaComputer.instance.currentGameMode.Value = "MODDED_Infection";

                if (GUI.Button(new Rect(10, 110, 230, 30), "Modded Guardian"))
                    GorillaComputer.instance.currentGameMode.Value = "MODDED_Guardian";

                if (GUI.Button(new Rect(10, 145, 230, 30), "Modded Freezetag"))
                    GorillaComputer.instance.currentGameMode.Value = "MODDED_Freezetag";
            }

            if (GUI.Button(new Rect(210, 185, 30, 20), "→"))
                currentPage = (currentPage + 1) % 2;

            if (GUI.Button(new Rect(10, 185, 30, 20), "←"))
                currentPage = (currentPage - 1 + 2) % 2;

            GUI.DragWindow(new Rect(0, 0, 10000, 20));
        }
    }
}
