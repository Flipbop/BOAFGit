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
		ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(new Hook());

		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
		
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.ModifyDamageDueToParts)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_MDDTP_FearBonus))
		);
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(AStatus), nameof(AStatus.Begin)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AStatusFear_Begin_Postfix))
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

	public static void AStatusFear_Begin_Postfix(AStatus __instance, State s, Combat c)
	{
		if (__instance.status != ModEntry.Instance.FearStatus.Status) return;
        
		var ship = __instance.targetPlayer ? s.ship : c.otherShip;
		
		if (ship.Get(ModEntry.Instance.FearStatus.Status) <= 1) return;
		ship.Set(ModEntry.Instance.FearStatus.Status, 1);
		if (ship.Get(ModEntry.Instance.FearStatus.Status) >= 0) return;
		ship.Set(ModEntry.Instance.FearStatus.Status, 0);
	}
	private sealed class Hook : IKokoroApi.IV2.IStatusLogicApi.IHook
	{
		public IReadOnlySet<Status> GetStatusesToCallTurnTriggerHooksFor(
			IKokoroApi.IV2.IStatusLogicApi.IHook.IGetStatusesToCallTurnTriggerHooksForArgs args)
		{
			IReadOnlySet<Status> statuses = new HashSet<Status>();
			statuses.AddItem(ModEntry.Instance.FearStatus.Status);
			return statuses;
		}
		public bool HandleStatusTurnAutoStep(IKokoroApi.IV2.IStatusLogicApi.IHook.IHandleStatusTurnAutoStepArgs args)
		{
			if (args.Timing != IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnStart)
				return false;

			args.Amount = 0;
			return false;
		}
	}
}
