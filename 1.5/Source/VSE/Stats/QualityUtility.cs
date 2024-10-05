using RimWorld;
using System.Collections.Generic;
using System.Linq;
using Verse;

namespace VSE.Stats
{
    public static class QualityUtility
    {
        private static readonly Dictionary<string, StatDef> BenchStatPairs = new()
        {
            { "HandTailoringBench", MoreStatDefOf.VSE_TailoringQuality },
            { "ElectricTailoringBench", MoreStatDefOf.VSE_TailoringQuality },
            { "FueledSmithy", MoreStatDefOf.VSE_SmithingQuality },
            { "ElectricSmithy", MoreStatDefOf.VSE_SmithingQuality },
            { "TableMachining", MoreStatDefOf.VSE_MachiningQuality },
            { "FabricationBench", MoreStatDefOf.VSE_FabricationQuality }
        };

        public static QualityCategory GenerateQuality(Pawn worker, SkillDef workSkill, Thing thing = null, RecipeDef recipe = null)
        {
            Log.Warning("Pawn: " + worker.DescriptionDetailed + " Skill: " + workSkill + " Thing: " + thing?.def.defName);
            var start = RimWorld.QualityUtility.GenerateQualityCreatedByPawn(worker, workSkill);
            if (workSkill == SkillDefOf.Artistic) start.AddFromStat(worker.GetStatValue(MoreStatDefOf.VSE_ArtQuality));
            if (workSkill == SkillDefOf.Construction) start.AddFromStat(worker.GetStatValue(MoreStatDefOf.VSE_ConstructQuality));
            if (workSkill == SkillDefOf.Crafting)
            {
                start.AddFromStat(worker.GetStatValue(MoreStatDefOf.VSE_CraftingQuality));
                if (recipe != null && !recipe.recipeUsers.NullOrEmpty())
                { 
                    Log.Warning("Recipe: " + recipe.defName + " Users: " + string.Join(", ", recipe.recipeUsers.Select(r => r.defName)));
                    StatDef statDef = null;
                    var recipeUser = recipe.recipeUsers.Find(r => BenchStatPairs.TryGetValue(r.defName, out statDef));
                    Log.Warning("RecipeUser: " + recipeUser.defName + " Stat: " + statDef.defName);
                    if (statDef != null) start.AddFromStat(worker.GetStatValue(statDef));
                }
            }
            
            return start;
        }

        public static void AddFromStat(ref this QualityCategory initial, float statValue)
        {
            while (statValue >= 0f)
            {
                Log.Warning("StatValue: " + statValue + " Initial: " + initial);
                if (Rand.Chance(statValue)) initial = RimWorld.QualityUtility.AddLevels(initial, 1);

                statValue -= 1f;
            }
            Log.Warning("StatValue: " + statValue + " Initial: " + initial);
        }
    }
}