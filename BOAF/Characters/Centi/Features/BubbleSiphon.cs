using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class BubbleSiphonManager
{

	public BubbleSiphonManager()
	{
		ModEntry.Instance.Harmony.Patch(
			original: AccessTools.DeclaredMethod(typeof(AAttack), nameof(AAttack.Begin)),
			prefix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AAttack_Bubble_Pop_Prefix)),
			postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(AAttack_Bubble_Pop_Postfix))
		);
	}

	private static void AAttack_Bubble_Pop_Prefix(Combat c, out int __state)
	{
		int count = 0;
		foreach (var midrowObject in c.stuff)
		{
			if (midrowObject.Value.bubbleShield)
			{
				count++;
			}
		}
		__state = count;
	}
	
	private static void AAttack_Bubble_Pop_Postfix(State s, Combat c, in int __state)
	{
		int count = 0;
		foreach (var midrowObject in c.stuff)
		{
			if (midrowObject.Value.bubbleShield)
			{
				count++;
			}
		}

		if (count >= __state)
			return;
		for (int i = 0; i < __state - count; i++)
		{
			if (s.ship.statusEffects.ContainsKey(ModEntry.Instance.BubbleSiphonStatus.Status))
			{
				c.QueueImmediate(new AStatus(){status = Status.shield, statusAmount = s.ship.Get(ModEntry.Instance.BubbleSiphonStatus.Status), targetPlayer = true, timer = 0.0});
				c.QueueImmediate(new AStatus(){status = ModEntry.Instance.BubbleSiphonStatus.Status, statusAmount = -1, targetPlayer = true});
			}
			if (c.otherShip.statusEffects.ContainsKey(ModEntry.Instance.BubbleSiphonStatus.Status))
			{
				c.QueueImmediate(new AStatus(){status = Status.shield, statusAmount = c.otherShip.Get(ModEntry.Instance.BubbleSiphonStatus.Status), targetPlayer = false, timer = 0.0});
				c.QueueImmediate(new AStatus(){status = ModEntry.Instance.BubbleSiphonStatus.Status, statusAmount = -1, targetPlayer = false});
			}
		}
	}
}
