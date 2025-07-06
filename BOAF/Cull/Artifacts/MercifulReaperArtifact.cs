using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class MercifulReaperArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("MercifulReaper", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/EnhancedTools.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "MercifulReaper", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "MercifulReaper", "description"]).Localize
		});
	}

	public override void OnCombatStart(State state, Combat combat)
	{
		base.OnCombatStart(state, combat);
		combat.Queue(new AAddCard { amount = 1, card = new HarmlessSiphonCard(), destination = CardDestination.Hand });
	}
}
