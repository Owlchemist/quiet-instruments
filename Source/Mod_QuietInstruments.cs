using Verse;
using UnityEngine;
using HarmonyLib;
using System;
using static QuietInstruments.ModSettings_QuietInstruments;
 
namespace QuietInstruments
{
    public class Mod_QuietInstruments : Mod
	{
		public Mod_QuietInstruments(ModContentPack content) : base(content)
		{
			new Harmony(this.Content.PackageIdPlayerFacing).PatchAll();
			base.GetSettings<ModSettings_QuietInstruments>();
		}

		public override void DoSettingsWindowContents(Rect inRect)
		{
			Listing_Standard options = new Listing_Standard();
			options.Begin(inRect);
			options.Label("QuietInstruments.Settings.Volume".Translate("0","1","1") + Math.Round(volume, 2), -1f, null);
			volume = options.Slider(volume, 0f, 1f);
			options.End();
			base.DoSettingsWindowContents(inRect);
		}
		public override string SettingsCategory()
		{
			return "Quiet Instruments";
		}
		public override void WriteSettings()
		{
			base.WriteSettings();
		}
	}
	public class ModSettings_QuietInstruments : ModSettings
	{
		public override void ExposeData()
		{
			Scribe_Values.Look<float>(ref volume, "volume", 1f, false);
			base.ExposeData();
		}

		public static float volume = 1f;
	}
}