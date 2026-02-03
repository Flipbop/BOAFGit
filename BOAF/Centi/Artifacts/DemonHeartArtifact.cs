using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class DemonHeartArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("DemonHeart", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CentiDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Centi/Artifacts/DemonHeart.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "DemonHeart", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "DemonHeart", "description"]).Localize
		});
	}

	public override void OnCombatStart(State state, Combat combat)
	{
		base.OnCombatStart(state, combat);
		combat.QueueImmediate(new AStatus(){statusAmount = 1, targetPlayer = true, status = ModEntry.Instance.SignalBoosterStatus.Status});
	}
	
}
