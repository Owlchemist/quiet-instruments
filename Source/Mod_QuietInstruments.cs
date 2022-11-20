using Verse;
using UnityEngine;
using HarmonyLib;
using System;
using static SmartEating.ModSettings_QuietInstruments;
 
namespace SmartEating
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
			options.Label("QuietInstruments.Settings.Volume".Translate("1","0","1") + Math.Round(volume, 2), -1f, null);
			volume = options.Slider(volume, 0f, 1f);
			options.CheckboxLabeled("QuietInstruments.Settings.Fade".Translate(), ref fade, "QuietInstruments.Settings.Fade.Desc".Translate());
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
			Scribe_Values.Look<bool>(ref fade, "fade", false, false);
			base.ExposeData();
		}

		public static float volume = 1f;
		public static bool fade;
	}
}