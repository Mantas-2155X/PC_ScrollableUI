using BepInEx;
using HarmonyLib;

namespace PC_ScrollableUI
{
    [BepInPlugin(nameof(PC_ScrollableUI), nameof(PC_ScrollableUI), VERSION)]
    public class PC_ScrollableUI : BaseUnityPlugin
    {
        public const string VERSION = "1.0.0";
        
        private void Awake() => Harmony.CreateAndPatchAll(typeof(Hooks), "PC_ScrollableUI");
    }
}