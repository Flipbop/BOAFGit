using System;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class ReaperCannonsArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("ReaperCannons", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = Deck.colorless,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Ship/Thanatos/Artifacts/ReaperCannons.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "ReaperCannons", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "ReaperCannons", "description"]).Localize
		});
	}

	public bool peace = true;
	public bool war = false;
	public int turnCounter = 0;

	public override void OnTurnEnd(State state, Combat combat)
	{
		base.OnTurnEnd(state, combat);
		if (war && !peace)
		{
			if (!(turnCounter > 0))
			{
				war = false;
				foreach (Part p in state.ship.parts)
				{
				
					if (p.active)
					{
						p.active = false;
						p.skin = "wing_ares_off";
					}
					if (!p.active && p.skin == "wing_ares_off" && ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(p, "previouslyActive", false))
					{
						ModEntry.Instance.helper.ModData.SetModData(p, "previouslyActive", false);
						p.active = true;
						p.skin = "wing_ares";
					}
				}
			}
			else
			{
				turnCounter--;
			}
		}
		if (peace)
		{
			war = true;
			foreach (Part p in state.ship.parts)
			{
				if (p.active && p.skin == "wing_ares" && !ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(p, "previouslyActive", false))
				{
					ModEntry.Instance.helper.ModData.SetModData(p, "previouslyActive", true);
				}
				if (!p.active)
				{
					p.active = true;
					p.skin = "wing_ares";
				}
			}

			turnCounter = 3;
		}
	}

	public override void OnEnemyGetHit(State state, Combat combat, Part? part)
	{
		base.OnEnemyGetHit(state, combat, part);
		peace = false;
	}

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		peace = true;
	}

	public override void OnReceiveArtifact(State state)
	{
		base.OnReceiveArtifact(state);
		string artifactType = "HunterCannons";
		foreach (Artifact artifact in state.artifacts)
		{
			if (artifact.Key() == artifactType)
				artifact.OnRemoveArtifact(state);
		}
		state.artifacts.RemoveAll((Predicate<Artifact>) (r => r.Key() == artifactType));
	}

	public override int? GetDisplayNumber(State s)
	{
		if (peace)
		{
			return null;
		}
		return turnCounter;
	}
}
