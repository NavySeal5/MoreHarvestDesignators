using Verse;
using RimWorld;
using UnityEngine;

namespace MoreHarvestDesignators
{
	public class Designator_PlantCut_NoTrees : Designator_Plants
	{

		public Designator_PlantCut_NoTrees()
		{
			this.defaultLabel = "Designator_PlantCut_NoTrees_label".Translate();
			this.defaultDesc = "Designator_PlantCut_NoTrees_desc".Translate();
			this.icon = ContentFinder<Texture2D>.Get("UI/Designators/CutPlants", true);
			this.soundDragSustain = SoundDefOf.Designate_DragStandard;
			this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
			this.useMouseIcon = true;
			this.soundSucceeded = SoundDefOf.Designate_CutPlants;
			this.hotKey = KeyBindingDefOf.Misc2;
			this.designationDef = DesignationDefOf.CutPlant;
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
				if (plant.def.plant.harvestTag == "Wood")
				{
					result = "Designator_PlantCut_NoTrees_rejected".Translate();
				}
				else if (plant.def.defName == "Plant_PodGauranlen" || plant.def.defName == "Plant_TreeGauranlen" || plant.def.defName == "Plant_MossGauranlen"){
                    result = false;
				}
				else if (plant.def.defName == "Plant_TreeAnima"){
                    result = false;
				}
				else
				{
					result = true;
				}
			}
			return result;
		}

		protected override bool RemoveAllDesignationsAffects(LocalTargetInfo target)
		{
			return target.Thing.def.plant.harvestTag == "Standard";
		}
	}

}
