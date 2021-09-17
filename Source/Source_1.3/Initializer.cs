using RimWorld;
using System.Reflection;
using Verse;
using HarmonyLib;

namespace NoRandomConstructionQuality
{
    [StaticConstructorOnStartup]
    public static class Initializer
    {
        static Initializer()
        {
            Harmony harmony = new Harmony("NoRandomConstructionQuality_Ben");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            MethodInfo m1 = typeof(QualityUtility).GetMethod("SendCraftNotification", BindingFlags.Static | BindingFlags.Public);
            MethodInfo m2 = typeof(_QualityUtility).GetMethod("_SendCraftNotification", BindingFlags.Static | BindingFlags.Public);

            if (!Detours.TryDetourFromTo(m1, m2))
            {
                Log.Message("NoRandomConstructionQuality: QualityUtility._SendCraftNotification failed to override, please contact mod author");
            }
        }
    }
}
