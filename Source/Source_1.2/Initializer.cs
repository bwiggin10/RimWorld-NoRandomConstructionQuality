using RimWorld;
using System;
using System.Reflection;
using Verse;

namespace NoRandomConstructionQuality
{
    [StaticConstructorOnStartup]
    public static class Initializer
    {
        static Initializer()
        {
            MethodInfo m1 = typeof(QualityUtility).GetMethod("GenerateQualityCreatedByPawn", BindingFlags.Static | BindingFlags.Public, null, CallingConventions.Standard, new Type[] { typeof(int), typeof(bool) }, null);
            MethodInfo m2 = typeof(_QualityUtility).GetMethod("GenerateQualityCreatedByPawn", BindingFlags.Static | BindingFlags.Public);

            if (!Detours.TryDetourFromTo(m1, m2))
            {
                Log.Message("NoRandomConstructionQuality: QualityUtility.RandomCreationQuality failed to override, please contact mod author");
            }

            MethodInfo m3 = typeof(QualityUtility).GetMethod("SendCraftNotification", BindingFlags.Static | BindingFlags.Public);
            MethodInfo m4 = typeof(_QualityUtility).GetMethod("_SendCraftNotification", BindingFlags.Static | BindingFlags.Public);

            if (!Detours.TryDetourFromTo(m3, m4))
            {
                Log.Message("NoRandomConstructionQuality: QualityUtility._SendCraftNotification failed to override, please contact mod author");
            }
        }
    }
}
