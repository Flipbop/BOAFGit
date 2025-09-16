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
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Ship/Thanatos/Artifacts/HunterCannons.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "HunterCannons", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["ship","artifact", "HunterCannons", "description"]).Localize
		});
	}

	public bool peace = true;

	public override void OnTurnEnd(State state, Combat combat)
	{
		base.OnTurnEnd(state, combat);
		if (peace) combat.Queue(new AAttack() {damage = Card.GetActualDamage(state,1)});
	}

	public override void OnPlayerAttack(State state, Combat combat)
	{
		base.OnPlayerAttack(state, combat);
		peace = false;
	}

	public override void OnTurnStart(State state, Combat combat)
	{
		base.OnTurnStart(state, combat);
		peace = true;
	}
}
