﻿// PMThingDefOf.cs modified by Iron Wolf for Pawnmorph on 09/08/2019 9:46 AM
// last updated 09/08/2019  9:46 AM

using RimWorld;
using Verse;
#pragma warning disable 1591
namespace Pawnmorph
{
    /// <summary> Static container for commonly referenced thing defs. </summary>
    [DefOf]
    public static class PMThingDefOf
    {
        static PMThingDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ThingDef));
        }

        public static ThingDef Plant_ChaoBulb;
        public static ThingDef Plant_GnarledTree;
        public static ThingDef Morphsilk;
        public static ThingDef CrashedMutagenicShipPartIncoming;
        public static ThingDef Mutanite; 
        public static ThingDef MutagenHopper; 

        public static ThingDef EggChickenUnfertilized;
        public static ThingDef Chicken;
        public static ThingDef Cow;
        public static ThingDef TFMilk;
        public static ThingDef TFEgg;


        public static ThingDef MechaniteSlurry;
    }
}