using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class BubbleSiphonManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{

	public BubbleSiphonManager()
	{
		ModEntry.Instance.KokoroApi.StatusLogic.RegisterHook(new Hook());
		
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
