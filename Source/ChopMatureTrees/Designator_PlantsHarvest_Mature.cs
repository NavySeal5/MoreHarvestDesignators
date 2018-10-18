/*
 * Created by SharpDevelop.
 * User: Tobias
 * Date: 16.08.2018
 * Time: 18:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Verse;
using RimWorld;
using UnityEngine;

namespace MoreHarvestDesignators
{
	/// <summary>
	/// Description of Designator_PlantsHarvest_Mature.
	/// </summary>
	public class Designator_PlantsHarvest_Mature : Designator_Plants
	{
		public Designator_PlantsHarvest_Mature()
		{
			this.defaultLabel = "Designator_PlantsHarvest_Mature_label".Translate();
			this.defaultDesc = "Designator_PlantsHarvest_Mature_desc".Translate();
			this.icon = ContentFinder<Texture2D>.Get("UI/Designators/Harvest", true);
			this.soundDragSustain = SoundDefOf.Designate_DragStandard;
			this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
			this.useMouseIcon = true;
			this.soundSucceeded = SoundDefOf.Designate_Harvest;
			this.hotKey = KeyBindingDefOf.Misc2;
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
				if (!plant.HarvestableNow || plant.def.plant.harvestTag != "Standard" || plant.Growth < 0.999f)
				{
					result = "Designator_PlantsHarvest_Mature_rejected".Translate();
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
