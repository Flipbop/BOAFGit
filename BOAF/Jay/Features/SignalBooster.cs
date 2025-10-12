using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HarmonyLib;
using Nickel;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class SignalBoosterManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{

	public SignalBoosterManager()
	{
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
		ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(Artifact.OnTurnStart), (State state, Combat combat) =>
		{
			if (!combat.isPlayerTurn)
				return;

			var stacks = state.ship.Get(ModEntry.Instance.CloakedStatus.Status);
			if (stacks <= 0)
				return;

			combat.Queue(new AStunShip());
			combat.Queue(new AStatus(){status = ModEntry.Instance.CloakedStatus.Status, statusAmount = 0, targetPlayer = true, mode = AStatusMode.Set});
		});
		ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(Artifact.OnPlayerTakeNormalDamage),
			(State state, Combat combat) =>
			{
				var stacks = state.ship.Get(ModEntry.Instance.CloakedStatus.Status);
				if (stacks <= 0)
					return;
				combat.Queue(new AStatus(){status = ModEntry.Instance.CloakedStatus.Status, statusAmount = 0, targetPlayer = true, mode = AStatusMode.Set});
			});
	}
}
