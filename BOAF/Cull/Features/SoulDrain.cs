using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HarmonyLib;
using Nickel;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class SoulDrainManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{
	internal static IStatusEntry SoulDrainStatus { get; private set; } = null!;

	public SoulDrainManager()
	{
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
		ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(Artifact.OnTurnStart), (State state, Combat combat) =>
		{
			if (!combat.isPlayerTurn)
				return;

			var stacks = state.ship.Get(ModEntry.Instance.SoulDrainStatus.Status);
			if (stacks <= 0)
				return;

			combat.Queue(new AStatus(){status = SoulEnergyManager.SoulEnergyStatus.Status, statusAmount = -1*stacks, targetPlayer = true});
			combat.Queue(new AStatus(){status = SoulDrainStatus.Status, statusAmount = -1, targetPlayer = true});
		});
	}
}
