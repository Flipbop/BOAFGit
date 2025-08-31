using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Nickel;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class FearManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{
	public FearManager()
	{
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
		ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(Artifact.OnTurnEnd),
			(State state, Combat combat) =>
			{
				
				var stacks = state.ship.Get(ModEntry.Instance.FearStatus.Status);
				if (stacks <= 0)
					return;
				
				if (!combat.isPlayerTurn)
					combat.Queue(new AStatus() { status = ModEntry.Instance.FearStatus.Status, statusAmount = 0, targetPlayer = false, mode = AStatusMode.Set});
				else
				{
					combat.Queue(new AStatus() { status = ModEntry.Instance.FearStatus.Status, statusAmount = 0, targetPlayer = true, mode = AStatusMode.Set});
				}
			});
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.ModifyDamageDueToParts)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_MDDTP_FearBonus))
		);
	}
	public static void Ship_MDDTP_FearBonus(Ship __instance, ref int __result)
	{
		if (__instance.Get(ModEntry.Instance.FearStatus.Status) > 0)
		{
			__result += 1;
			__instance.PulseStatus(ModEntry.Instance.FearStatus.Status);
		}
	}

	
}
