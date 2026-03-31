using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class NanomachinesManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{

	public NanomachinesManager()
	{
		ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(new Hook());

		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.NormalDamage)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_DamageShield_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_DamageShield_Postfix))
		);
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(Ship), nameof(Ship.DirectHullDamage)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_Damage_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Ship_Damage_Postfix))
		);
	}

	private static bool shielded = false;
	private static void Ship_DamageShield_Prefix(Ship __instance, out int __state)
		=> __state = __instance.hull + __instance.Get(Status.shield) + __instance.Get(Status.tempShield);

	private static void Ship_DamageShield_Postfix(Ship __instance, State s, Combat c, in int __state)
	{
		var damageTaken = __state - __instance.hull - __instance.Get(Status.shield) - __instance.Get(Status.tempShield);
		if (damageTaken <= 0)
			return;
		var status = __instance.Get(ModEntry.Instance.NanomachinesStatus.Status);
		if (status <= 0)
			return;
		if ((__instance.Get(Status.shield) + __instance.Get(Status.tempShield)) <= 0)
		{
			shielded = false;
		}
		else
		{
			shielded = true;
		}
		
		if (__instance.isPlayerShip) 
		{
			c.Queue(new AStatus() { statusAmount = damageTaken, status = Status.tempShield, targetPlayer = true, timer = 0.0 });
		} else
		{
			c.Queue(new AStatus() { statusAmount = damageTaken, status = Status.tempShield, targetPlayer = false, timer = 0.0 });
			
		}
	}
	
	private static void Ship_Damage_Prefix(Ship __instance, out int __state)
		=> __state = __instance.hull;

	private static void Ship_Damage_Postfix(Ship __instance, State s, Combat c, in int __state)
	{
		var damageTaken = __state - __instance.hull;
		if (damageTaken <= 0)
			return;
		var status = __instance.Get(ModEntry.Instance.NanomachinesStatus.Status);
		if (status <= 0)
			return;
		if (shielded)
		{
			return;
		}
		if (__instance.isPlayerShip) 
		{
			c.Queue(new AStatus() { statusAmount = damageTaken, status = Status.tempShield, targetPlayer = true, timer = 0.0 });
		} else
		{
			c.Queue(new AStatus() { statusAmount = damageTaken, status = Status.tempShield, targetPlayer = false, timer = 0.0 });
			
		}
	}
	
	private sealed class Hook : IKokoroApi.IV2.IStatusLogicApi.IHook
	{
		public IReadOnlySet<Status> GetStatusesToCallTurnTriggerHooksFor(
			IKokoroApi.IV2.IStatusLogicApi.IHook.IGetStatusesToCallTurnTriggerHooksForArgs args)
		{
			return new HashSet<Status>() {ModEntry.Instance.NanomachinesStatus.Status};;
		}
		public bool HandleStatusTurnAutoStep(IKokoroApi.IV2.IStatusLogicApi.IHook.IHandleStatusTurnAutoStepArgs args)
		{
			if (args.Timing != IKokoroApi.IV2.IStatusLogicApi.StatusTurnTriggerTiming.TurnStart)
				return false;

			args.Amount -= 1;
			return false;
		}
	}
}
