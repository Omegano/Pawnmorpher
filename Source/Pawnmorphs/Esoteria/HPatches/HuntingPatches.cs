﻿// HuntingPatches.cs modified by Iron Wolf for Pawnmorph on 12/15/2019 7:40 AM
// last updated 12/15/2019  7:40 AM

using System.Collections.Generic;
using System.Linq;
using HarmonyLib;
using JetBrains.Annotations;
using RimWorld;
using Verse;
using Verse.AI;

namespace Pawnmorph.HPatches
{
    static class HuntingPatches
    {
        [HarmonyPatch(typeof(JobDriver_PredatorHunt)), HarmonyPatch("MakeNewToils")]
        static class JobDriver_PredatorHuntPatch
        {
            static IEnumerable<Toil> Postfix(IEnumerable<Toil> values, [NotNull] JobDriver_PredatorHunt __instance)
            {
                foreach (Toil toil in values) yield return toil;

                if (!__instance.pawn.IsFormerHuman() || __instance.pawn?.needs?.mood == null ) yield break;
                yield return Toils_General.Do(() =>
                {
                    FormerHumanUtilities.GiveSapientAnimalHuntingThought(__instance.pawn,
                                                                         __instance.Prey);
                });
 
            }

            
        }

        [HarmonyPatch(typeof(Designator_Hunt), nameof(Designator_Hunt.CanDesignateThing))]
        static class HuntingDesignatorPatch
        {
            static void Postfix(ref AcceptanceReport __result,  [NotNull] Thing t )
            {
                if (!__result.Accepted && Find.CurrentMap?.designationManager.DesignationOn(t, DesignationDefOf.Hunt) == null)
                {
                    var p = t as Pawn;
                    if (p == null) return;
                    if (p.IsFormerHuman() && p.Faction == null) __result = true; 
                }
            }
        }
    }
}