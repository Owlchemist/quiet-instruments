
using HarmonyLib;
using Verse;
using Verse.Sound;
using RimWorld;
using System.Linq;
using static QuietInstruments.ModSettings_QuietInstruments;

namespace QuietInstruments
{
	[HarmonyPatch(typeof(SoundInfo), nameof(SoundInfo.InMap))]
	public class Patch_SupportsAllowedAreas
	{
		static public void Postfix(TargetInfo maker, ref SoundInfo __result)
		{	
			//Is this an instrument?
			var thingsAt = maker.Map?.thingGrid.ThingsAt(maker.cellInt) ?? null;
			foreach (var thing in thingsAt ?? Enumerable.Empty<Thing>())
			{
				if (thing.def?.soundPlayInstrument != null)
				{
					__result.volumeFactor *= volume;
					return;
				}
			}
		}
    }

	[HarmonyPatch(typeof(Building_MusicalInstrument), nameof(Building_MusicalInstrument.SoundRange), MethodType.Getter)]
	public class Patch_SoundRange
	{
		static public void Postfix(ref FloatRange __result)
		{	
			if (fade) __result.min = __result.max = 0f;
		}
    }

	/*
	//This would be a performance gain but it stops the fleck emitter....
	[HarmonyPatch(typeof(Building_MusicalInstrument), nameof(Building_MusicalInstrument.StartPlaying))]
	public class Patch_Tick
	{
		static public bool Prefix(Building_MusicalInstrument __instance)
		{
			if (volume == 0f) return false;
			return true;
		}
	}
	*/
}
