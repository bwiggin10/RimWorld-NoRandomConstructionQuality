using RimWorld;
using System;
using Verse;

namespace NoRandomConstructionQuality
{
    public static class _QualityUtility
    {
        public static QualityCategory GetStaticQuality(int relevantSkillLevel)
        {
            if (relevantSkillLevel > 20)
            {
                return QualityCategory.Legendary;
            }
            else
            {
                switch (relevantSkillLevel)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        return QualityCategory.Awful;

                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        return QualityCategory.Poor;

                    case 8:
                    case 9:
                    case 10:
                        return QualityCategory.Normal;

                    case 11:
                    case 12:
                    case 13:
                        return QualityCategory.Good;

                    case 14:
                    case 15:
                    case 16:
                        return QualityCategory.Excellent;

                    case 17:
                    case 18:
                    case 19:
                        return QualityCategory.Masterwork;

                    case 20:
                        return QualityCategory.Legendary;

                    default:
                        throw new InvalidOperationException("Unable to determine quality for skill level " + relevantSkillLevel);
                }
            }
        }

        public static QualityCategory AddLevels(QualityCategory quality, byte levels)
        {
            return (QualityCategory)Math.Min((byte)quality + levels, (byte)QualityCategory.Legendary);
        }

        public static void _SendCraftNotification(Thing thing, Pawn worker)

        {
            if (worker == null || NrcqMod.settings.crafting_notification == false)
            {
                return;
            }
            CompQuality compQuality = thing.TryGetComp<CompQuality>();
            if (compQuality == null)
            {
                return;
            }

            if (compQuality.Quality == QualityCategory.Masterwork)
            {
                Find.LetterStack.ReceiveLetter("LetterCraftedMasterworkLabel".Translate(), "LetterCraftedMasterworkMessage".Translate(worker.LabelShort, thing.LabelShort, worker.Named("WORKER"), thing.Named("CRAFTED")), LetterDefOf.PositiveEvent, thing, null, null);
            }
            else if (compQuality.Quality == QualityCategory.Legendary)
            {
                Find.LetterStack.ReceiveLetter("LetterCraftedLegendaryLabel".Translate(), "LetterCraftedLegendaryMessage".Translate(worker.LabelShort, thing.LabelShort, worker.Named("WORKER"), thing.Named("CRAFTED")), LetterDefOf.PositiveEvent, thing, null, null);
            }
        }
    }
}
