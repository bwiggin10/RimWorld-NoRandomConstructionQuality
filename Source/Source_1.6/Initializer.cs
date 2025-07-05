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
        }
    }
}
