using System.Collections.Generic;
using Verse;
using UnityEngine;
using RimWorld;

namespace NoRandomConstructionQuality
{
    class Nrcq_settings : ModSettings
    {
        public int doCustomQualities = 0;
        public int custom_quality = 0;
        public static float qualityAwful = 3f;
        private int[] skills = new int[] { 0, 4, 8, 11, 14, 17, 20 };



        public int GetSkillValue(QualityCategory qc) => skills[(int)qc];
        
        //private void SetSkillValue(QualityCategory qc, int value)
        //{ 
        //}


        public override void ExposeData()
        {
        
            
            
            base.ExposeData();
        }

        public void DoWindowContents(Rect canvas)
        {
            var ls = new Listing_Standard();
            ls.Begin(canvas);
            ls.Label("QualityOptions".Translate());
            ls.Gap(12f);

            bool[] qualityDefault = new bool[2];
            qualityDefault[0] = ls.RadioButton_NewTemp("QualityDefault".Translate(), custom_quality == 0);
            qualityDefault[1] = ls.RadioButton_NewTemp("QualityCustom".Translate(), custom_quality == 1);
            ls.Gap(12f);

            ls.Label("QualityAwful".Translate());


            qualityAwful = ls.Slider(qualityAwful, 0f, 20f);
            ls.Gap(12f);


            ls.Label("QualityPoor".Translate());
            ls.Label("NRCQ.Poor".Translate());
            qualityPoor = ls.Slider(qualityPoor, 0f, 20f);
            ls.Gap(12f);


            




        }




    }
}
