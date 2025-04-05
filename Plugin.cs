using BepInEx;
using GorillaNetworking;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GamemodeSelectorGUI
{
    [BepInPlugin(Constants.GUID, Constants.Name, Constants.Version)]
    public class Plugin : BaseUnityPlugin
    {

        public void Start()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }


        public void Update()
        {
            if (Keyboard.current.tabKey.wasPressedThisFrame)
            {
                guiEnabled = !guiEnabled;
            }
        }

        public bool guiEnabled = true;
        public void OnGUI()
        {
            if (guiEnabled)
            {
                GUI.Box(new Rect(50, 50, 175, 180), Constants.Name);
                GUI.color = Color.gray;
                GUI.Label(new Rect(55, 65, 150, 20), Constants.Version);
                GUI.Label(new Rect(170, 65, 150, 20), "ciperuoy");

                if (GUI.Button(new Rect(55, 90, 165, 30), "Casual"))
                {
                    GorillaComputer.instance.currentGameMode.Value = "Casual";
                }
                if (GUI.Button(new Rect(55, 125, 165, 30), "Infection"))
                {
                    GorillaComputer.instance.currentGameMode.Value = "Infection";
                }
                if (GUI.Button(new Rect(55, 160, 165, 30), "Modded Casual"))
                {
                    GorillaComputer.instance.currentGameMode.Value = "MODDED_Casual";
                }
                if (GUI.Button(new Rect(55, 195, 165, 30), "Modded Infection"))
                {
                    GorillaComputer.instance.currentGameMode.Value = "MODDED_Infection";
                }
            }

        }
    }
}
