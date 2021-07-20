using UnityEngine;
using Verse;

namespace NoRandomConstructionQuality
{
    public class Nrcq_settings : ModSettings
    {
        public bool crafting_notification = false;
        public void DoWindowsContents(Rect canvas)
        {
            Listing_Standard ls = new Listing_Standard
            {
                ColumnWidth = 300f
            };
            ls.Begin(canvas);
            string text_cn = Translator.Translate("CraftingNotifications");
            ls.CheckboxLabeled(text_cn, ref crafting_notification, Translator.Translate("Notifs"));
            ls.End();
        }
        public override void ExposeData()
        {
            Scribe_Values.Look(ref crafting_notification, "crafting_notifications", false, false);
        }

    }

}
