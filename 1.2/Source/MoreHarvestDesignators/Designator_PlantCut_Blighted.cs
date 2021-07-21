/*
 * Created by SharpDevelop.
 * User: Tobias
 * Date: 27.08.2018
 * Time: 13:50
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
	/// Description of Designator_PlantCut_Blighted.
	/// </summary>
	public class Designator_PlantCut_Blighted : Designator_Plants
	{
		
		public Designator_PlantCut_Blighted()
		{
			this.defaultLabel = "Designator_PlantCut_Blighted_label".Translate();
			this.defaultDesc = "Designator_PlantCut_Blighted_desc".Translate();
			this.icon = ContentFinder<Texture2D>.Get("UI/Designators/CutPlants", true);
			this.soundDragSustain = SoundDefOf.Designate_DragStandard;
			this.soundDragChanged = SoundDefOf.Designate_DragStandard_Changed;
			this.useMouseIcon = true;
			this.soundSucceeded = SoundDefOf.Designate_Harvest;
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
				

				if ((plant.def.plant.harvestTag != "Standard" && plant.def.plant.harvestTag != "Wood") || !plant.Blighted)
				{
					result = "Designator_PlantCut_Blighted_rejected".Translate();
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
