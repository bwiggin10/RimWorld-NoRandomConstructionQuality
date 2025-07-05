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

        public static QualityCategory AddLevels(QualityCategory quality, int levels)
        {
            return (QualityCategory)Math.Min((int)quality + levels, (int)QualityCategory.Legendary);
        }

    }
}
