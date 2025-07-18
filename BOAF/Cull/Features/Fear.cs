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
					combat.Queue(new AStatus() { status = ModEntry.Instance.FearStatus.Status, statusAmount = 0, targetPlayer = true, mode = AStatusMode.Set});
				else
				{
					combat.Queue(new AStatus() { status = ModEntry.Instance.FearStatus.Status, statusAmount = 0, targetPlayer = false, mode = AStatusMode.Set});
				}
			});
	}
	
}
