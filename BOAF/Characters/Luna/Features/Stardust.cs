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

	public static int StardustMax = 10;

	public static void ApplyPatches(IHarmony harmony, ILogger logger)
	{
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AStatusStardust_Begin_Postfix))
		);
	}

	public IKokoroApi.IV2.IStatusRenderingApi.IStatusInfoRenderer? OverrideStatusInfoRenderer(
		IKokoroApi.IV2.IStatusRenderingApi.IHook.IOverrideStatusInfoRendererArgs args)
	{
		if (args.Status != ModEntry.Instance.StardustStatus.Status)
			return null;

		var colors = new Color[StardustMax];
		for (var i = 0; i < colors.Length; i++)
			colors[i] = GetColor(i);

		int rowCount;
		rowCount = StardustMax > 10 ? 3 : 2;

		return ModEntry.Instance.KokoroApi.StatusRendering.MakeBarStatusInfoRenderer().SetSegments(colors).SetRows(rowCount);

		Color GetColor(int i)
		{
			if (i >= args.Amount)
				return ModEntry.Instance.KokoroApi.StatusRendering.DefaultInactiveStatusBarColor;
			return ModEntry.Instance.KokoroApi.StatusRendering.DefaultActiveStatusBarColor;

		}
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
