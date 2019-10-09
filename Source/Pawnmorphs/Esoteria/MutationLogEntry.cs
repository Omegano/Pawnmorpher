﻿// MutationLogEntry.cs created by Iron Wolf for Pawnmorph on 10/09/2019 12:03 PM
// last updated 10/09/2019  12:03 PM

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using RimWorld;
using Verse;
using static Pawnmorph.DebugUtils.DebugLogUtils;

namespace Pawnmorph
{
    /// <summary>
    ///     log entry for when a pawn mutates
    /// </summary>
    public class MutationLogEntry : LogEntry
    {
        private HediffDef _mutationDef;
        [CanBeNull] private TaleDef _mutationTale;
        private List<BodyPartDef> _mutatedRecords;
        private Pawn _pawn;

        public MutationLogEntry(Pawn pawn, [CanBeNull] TaleDef taleDef, HediffDef mutationDef, IEnumerable<BodyPartDef> mutatedParts)
        {
            _mutatedRecords = mutatedParts.ToList();
            _pawn = pawn;
            _mutationTale = taleDef;
            _mutationDef = mutationDef;
        }


        public override bool Concerns(Thing t)
        {
            return t == _pawn;
        }

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Defs.Look(ref _mutationTale, nameof(_mutationTale));
            Scribe_Defs.Look(ref _mutationDef, nameof(_mutationDef));
            Scribe_Collections.Look(ref _mutatedRecords, nameof(_mutatedRecords), LookMode.Def);
            Scribe_References.Look(ref _pawn, nameof(_pawn));

            if (Scribe.mode == LoadSaveMode.PostLoadInit) _mutatedRecords = _mutatedRecords ?? new List<BodyPartDef>();
        }

        public override IEnumerable<Thing> GetConcerns()
        {
            yield return _pawn;
        }

        public override string GetTipString()
        {
            return $"{_mutationDef.LabelCap}";
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return
                $"{_pawn.Name}: {string.Join(",", _mutatedRecords.Select(r => r.LabelCap).ToArray())} -> {_mutationDef.LabelCap}";
        }

        protected override string ToGameStringFromPOV_Worker(Thing pov, bool forceLog)
        {
            Assert(pov == _pawn, "pov == _pawn");

            return _mutationDef.LabelCap; //TODO generate string 
        }
    }
}