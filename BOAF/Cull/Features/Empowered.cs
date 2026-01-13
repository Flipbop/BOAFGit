using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using HarmonyLib;
using Nickel;
using Shockah.Kokoro;

namespace Flipbop.BOAF;

internal sealed class EmpoweredManager : IKokoroApi.IV2.IStatusRenderingApi.IHook
{

	public EmpoweredManager()
	{
		ModEntry.Instance.KokoroApi.StatusRendering.RegisterHook(this);
		ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(Artifact.OnEnemyGetHit), (State state, Combat combat) =>
		{
			var stacks = state.ship.Get(ModEntry.Instance.EmpoweredStatus.Status);
			if (stacks <= 0)
				return;
			combat.Queue(new AStatus(){status = ModEntry.Instance.SoulEnergyStatus.Status, statusAmount = stacks, targetPlayer = true, timer = 0.0});
		});
	}
}
