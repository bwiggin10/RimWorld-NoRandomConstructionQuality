using HarmonyLib;
using RimWorld;
using System;
using Verse;
using System.Linq;

namespace NoRandomConstructionQuality
{
    public static class HarmonyPatches
    {

        [HarmonyPatch(typeof(QualityUtility))]
        [HarmonyPatch("GenerateQualityCreatedByPawn")]
        [HarmonyPatch(new Type[] { typeof(Pawn), typeof(SkillDef), typeof(bool) }, new ArgumentType[] { ArgumentType.Normal, ArgumentType.Normal, ArgumentType.Normal })]
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
                int relevantSkillLevel = (pawn.RaceProps.IsMechanoid ? pawn.RaceProps.mechFixedSkillLevel : pawn.skills.GetSkill(relevantSkill).Level);
                QualityCategory quality = _QualityUtility.GetStaticQuality(relevantSkillLevel);
                if (ModsConfig.IdeologyActive && pawn.Ideo != null)
                {
                    Precept_Role role = pawn.Ideo.GetRole(pawn);
                    if (role != null && role.def.roleEffects != null)
                    {
                        RoleEffect roleEffect = role.def.roleEffects.FirstOrDefault((RoleEffect eff) => eff is RoleEffect_ProductionQualityOffset);
                        if (roleEffect != null)
                        {
                            quality = _QualityUtility.AddLevels(quality, ((RoleEffect_ProductionQualityOffset)roleEffect).offset);
                        }
                    }
                }

                if (__state)
                {
                    quality = _QualityUtility.AddLevels(quality, 2);
                }

                __result = quality;

            }
        }

        [HarmonyPatch(typeof(QualityUtility))]
        [HarmonyPatch("SendCraftNotification")]
        [HarmonyPatch(new Type[] { typeof(Thing), typeof(Pawn) }, new ArgumentType[] { ArgumentType.Normal, ArgumentType.Normal })]
        public static class SendCraftNotification_Patch
        {
            public static bool Prefix(Thing thing, Pawn worker)
            {
                if (NrcqMod.settings.crafting_notification == true)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
