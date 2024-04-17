using System;
using Verse;
using RimWorld;
using UnityEngine;


namespace MoreHarvestDesignators
{
    public class Designator_PlantsHarvestStumps : Designator_Plants
    {
        public Designator_PlantsHarvestStumps()
        {
            this.defaultLabel = "Designator_PlantsHarvestStumps_label".Translate();
            this.defaultDesc = "Designator_PlantsHarvestStumps_desc".Translate();
            this.icon = ContentFinder<Texture2D>.Get("UI/Designators/HarvestWood", true);
            this.soundDragSustain = SoundDefOf.Designate_DragStandard;
            this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
            this.useMouseIcon = true;
            this.soundSucceeded = SoundDefOf.Designate_CutPlants;
            this.hotKey = KeyBindingDefOf.Misc1;
            this.designationDef = DesignationDefOf.HarvestPlant;
        }

        public override AcceptanceReport CanDesignateThing(Thing t)
        {
            AcceptanceReport acceptanceReport = base.CanDesignateThing(t);
            AcceptanceReport result;
            if (!acceptanceReport.Accepted)
            {
                result = acceptanceReport;
            }
            else
            {
                Plant plant = (Plant)t;
                if (plant.def.defName == "ChoppedStump")
                {
                    result = true;
                }
                else
                {
                    result = "Designator_PlantsHarvestStump_Rejected".Translate(); "Designator_PlantsHarvestStump_Rejected".Translate();
                }
            }
            return result;
        }

        protected override bool RemoveAllDesignationsAffects(LocalTargetInfo target)
        {
            return target.Thing.def.defName == "ChoppedStump";
        }
    }
}