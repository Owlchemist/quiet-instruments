
using HarmonyLib;
using Verse;
using Verse.Sound;
using static QuietInstruments.ModSettings_QuietInstruments;

namespace QuietInstruments
{
	[HarmonyPatch(typeof(SoundInfo), nameof(SoundInfo.InMap))]
	public class Patch_SupportsAllowedAreas
	{
		static public void Postfix(TargetInfo maker, ref SoundInfo __result)
		{	
			//Is this an instrument?
			var thingsAt = maker.Map?.thingGrid.ThingsAt(maker.cellInt);
			foreach (var thing in thingsAt)
			{
				if (thing.def?.soundPlayInstrument != null)
				{
					__result.volumeFactor *= volume;
					return;
				}
			}
		}
    }
}
