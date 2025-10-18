using System;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class LessEnergyAllTurnsManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{

	public LessEnergyAllTurnsManager()
	{
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
		ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook<Action<State, Combat>>(nameof(Artifact.OnTurnStart),
			(State state, Combat combat) =>
			{
				if (!combat.isPlayerTurn)
				{
					return;
				}
				var stacks = state.ship.Get(ModEntry.Instance.LessEnergyAllTurnsStatus.Status);
				if (stacks <=0)
				{
					return;
				}
				combat.QueueImmediate(new AEnergy(){changeAmount = -stacks});
			});
	}
}
