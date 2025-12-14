using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nickel;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class SoulEnergyManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{
	
	public SoulEnergyManager()
	{
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
	}

	public static void ApplyPatches(IHarmony harmony, ILogger logger)
	{
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AStatusSoul_Begin_Postfix))
		);
	}
	public IKokoroApi.IV2.IStatusRenderingApi.IStatusInfoRenderer? OverrideStatusInfoRenderer(IKokoroApi.IV2.IStatusRenderingApi.IHook.IOverrideStatusInfoRendererArgs args)
	{
		if (args.Status != ModEntry.Instance.SoulEnergyStatus.Status)
			return null;
		
		var colors = new Color[10];
		for (var i = 0; i < colors.Length; i++)
			colors[i] = GetColor(i);

		return ModEntry.Instance.KokoroApi.StatusRendering.MakeBarStatusInfoRenderer().SetSegments(colors).SetRows(2);

		Color GetColor(int i)
		{
			if (i >= args.Amount)
				return ModEntry.Instance.KokoroApi.StatusRendering.DefaultInactiveStatusBarColor;
			return ModEntry.Instance.KokoroApi.StatusRendering.DefaultActiveStatusBarColor;

		}
	}
	
	public static void AStatusSoul_Begin_Postfix(AStatus __instance, State s, Combat c)
	{
		if (__instance.status != ModEntry.Instance.SoulEnergyStatus.Status) return;
        
		var ship = __instance.targetPlayer ? s.ship : c.otherShip;
		if (ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) <= 10) return;
		ship.Set(ModEntry.Instance.SoulEnergyStatus.Status, 10);
		if (ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 0) return;
		ship.Set(ModEntry.Instance.SoulEnergyStatus.Status, 0);
	}

}
