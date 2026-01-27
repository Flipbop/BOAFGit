using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class HunterCannonsArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("HunterCannons", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = Deck.colorless,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!),
				unremovable = true
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Ship/Thanatos/Artifacts/HunterCannons.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "HunterCannons", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "HunterCannons", "description"]).Localize
		});
	}

	public bool peace = true;
	public bool war = false;

	public override void OnTurnEnd(State state, Combat combat)
	{
		base.OnTurnEnd(state, combat);
		if (war && !peace)
		{
			war = false;
			foreach (Part p in state.ship.parts)
			{
				
				if (p.active && p.skin == "wing_ares")
				{
					p.active = false;
				}
				if (!p.active && !ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(p, "previouslyActive", false))
				{
					p.active = true;
				}
				ModEntry.Instance.helper.ModData.SetModData(p, "previouslyActive", false);
			}
		}
		if (peace && !war)
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
				}
			}
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
}
