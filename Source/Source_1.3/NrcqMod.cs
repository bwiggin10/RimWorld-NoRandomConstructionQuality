using UnityEngine;
using Verse;

namespace NoRandomConstructionQuality
{
    public class NrcqMod : Mod
    {
        public static Nrcq_settings settings;

        public NrcqMod(ModContentPack content) : base(content)
        {
            NrcqMod.settings = GetSettings<Nrcq_settings>();
        }

        public override string SettingsCategory()
        {
            return "No Random Construction Quality";
        }

        public override void DoSettingsWindowContents(Rect canvas) { settings.DoWindowsContents(canvas); }

    }
}
