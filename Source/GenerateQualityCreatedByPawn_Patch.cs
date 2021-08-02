using HarmonyLib;
using RimWorld;
using System;
using Verse;
using System.Reflection;

namespace NoRandomConstructionQuality
{
    [HarmonyPatch(typeof(QualityUtility))]
    [HarmonyPatch("GenerateQualityCreatedByPawn")]
    [HarmonyPatch(new Type[]
        {
        typeof(Pawn),
        typeof(SkillDef)
        }, new ArgumentType[]
        {
        0,
        0
        })]
    public static class GenerateQualityCreatedByPawn_Patch
    {
        private static void Prefix(Pawn pawn, out bool __state)
        {
            if (pawn.InspirationDef == InspirationDefOf.Inspired_Creativity)
            {
                __state = true;
            }
            else
            {
                __state = false;
            }
        }

        private static void Postfix(ref QualityCategory __result, Pawn pawn, SkillDef relevantSkill, bool __state)
        {
            int relevantSkillLevel = pawn.skills.GetSkill(relevantSkill).Level;
            QualityCategory quality = _QualityUtility.GetStaticQuality(relevantSkillLevel);

            if (__state)
            {
                quality = _QualityUtility.AddLevels(quality, 2);
            }

            __result = quality;

        }
    }
}
