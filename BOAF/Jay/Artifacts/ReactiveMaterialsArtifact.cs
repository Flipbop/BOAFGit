using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class ReactiveMaterialsArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("EnhancedFocus", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.JayDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Jay/Artifacts/EnhancedFocus.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "EnhancedFocus", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Jay","artifact", "EnhancedFocus", "description"]).Localize
		});
	}
	public bool _used = false;
	public override void OnPlayerTakeNormalDamage(State state, Combat combat, int rawAmount, Part? part)
	{
		base.OnPlayerTakeNormalDamage(state, combat, rawAmount, part);
		if (_used == false)
		{
			combat.Queue(new AStatus(){targetPlayer = true, status = ModEntry.Instance.SoulEnergyStatus.Status, statusAmount = 1});
		}
		_used = true;
	}

	public override void OnTurnEnd(State state, Combat combat)
	{
		base.OnTurnEnd(state, combat);
		_used = false;
	}
}
