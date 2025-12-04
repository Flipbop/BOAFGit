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

internal sealed class StardustManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{

	public StardustManager()
	{
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
	}

	public static int StardustMax = 15;

	public static void ApplyPatches(IHarmony harmony, ILogger logger)
	{
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AStatusStardust_Begin_Postfix))
		);
	}
	
	public (IReadOnlyList<Color> Colors, int? BarSegmentWidth)? OverrideStatusRenderingAsBars(IKokoroApi.IV2.IStatusRenderingApi.IHook.IOverrideStatusRenderingAsBarsArgs args)
	{
		if (args.Status != ModEntry.Instance.StardustStatus.Status) return null;

		var ship = args.Ship;
		var expected = StardustMax;
		var current = ship.Get(ModEntry.Instance.StardustStatus.Status);

		var filled = Math.Min(expected, current);
		var empty = Math.Max(expected - current, 0);
		return (Enumerable.Repeat(new Color("a661cb"), filled)
				.Concat(Enumerable.Repeat(new Color("7a3045"), empty))
				.ToImmutableList(),
			5);
	}
	public static void AStatusStardust_Begin_Postfix(AStatus __instance, State s, Combat c)
	{
		if (__instance.status != ModEntry.Instance.StardustStatus.Status) return;
        
		var ship = __instance.targetPlayer ? s.ship : c.otherShip;
		if (ship.Get(ModEntry.Instance.StardustStatus.Status) <= StardustMax) return;
		ship.Set(ModEntry.Instance.StardustStatus.Status, StardustMax);
		if (ship.Get(ModEntry.Instance.StardustStatus.Status) >= 0) return;
		ship.Set(ModEntry.Instance.StardustStatus.Status, 0);
	}
}
