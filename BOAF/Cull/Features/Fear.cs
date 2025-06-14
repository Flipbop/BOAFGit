using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HarmonyLib;
using Nickel;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class FearManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{
	internal static IStatusEntry SoulEnergyStatus { get; private set; } = null!;

	public FearManager()
	{
		
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
		//ModEntry.Instance.Harmony.Patch(
		//	original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
		//	postfix: new HarmonyMethod(GetType(), nameof(AStatus_Begin_Postfix))
		//);
	}
	

}
