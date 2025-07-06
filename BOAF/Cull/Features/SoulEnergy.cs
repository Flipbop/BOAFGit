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
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AStatus_Begin_Postfix))
		);
	}
	public (IReadOnlyList<Color> Colors, int? BarSegmentWidth)? OverrideStatusRenderingAsBars(IKokoroApi.IV2.IStatusRenderingApi.IHook.IOverrideStatusRenderingAsBarsArgs args)
	{
		if (args.Status != ModEntry.Instance.SoulEnergyStatus.Status) return null;

		var ship = args.Ship;
		var expected = 10;
		var current = ship.Get(ModEntry.Instance.SoulEnergyStatus.Status);

		var filled = Math.Min(expected, current);
		var empty = Math.Max(expected - current, 0);
		return (Enumerable.Repeat(new Color("301934"), filled)
				.Concat(Enumerable.Repeat(new Color("7a3045"), empty))
				.ToImmutableList(),
			null);
	}
	public static void AStatus_Begin_Postfix(AStatus __instance, State s, Combat c)
	{
		if (__instance.status != ModEntry.Instance.SoulEnergyStatus.Status) return;
        
		var ship = __instance.targetPlayer ? s.ship : c.otherShip;
		if (ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) <= 10) return;
		ship.Set(ModEntry.Instance.SoulEnergyStatus.Status, 10);
		if (ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 0) return;
		ship.Set(ModEntry.Instance.SoulEnergyStatus.Status, 0);
	}

}
