using RimWorld;

namespace VSE.Stats
{
    [DefOf]
    public static class MoreStatDefOf
    {
        public static StatDef VSE_ArmorPenetrationFactor;
        public static StatDef VSE_MeleeCooldownFactor;
        public static StatDef VSE_AttackOnFailChanceFactor;
        public static StatDef VSE_ArtQuality;
        public static StatDef VSE_RoofSpeed;
        public static StatDef VSE_RepairSpeed;
        public static StatDef VSE_ConstructQuality;
        public static StatDef VSE_RockChunkChance;
        public static StatDef VSE_FloorSpeed;
        public static StatDef VSE_CraftingQuality;
        public static StatDef VSE_TailoringQuality;
        public static StatDef VSE_SmithingQuality;
        public static StatDef VSE_MachiningQuality;
        public static StatDef VSE_FabricationQuality;

        static MoreStatDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(MoreStatDefOf));
        }
    }
}