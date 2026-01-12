using System.Collections.Generic;
using HarmonyLib;
using Nanoray.PluginManager;
using Nickel;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class EnhancedFocusArtifact : Artifact, IRegisterable
{
	private static ISpriteEntry ActiveSprite = null!;
	private static ISpriteEntry InactiveSprite = null!;
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		ActiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/EnhancedFocus.png"));
		InactiveSprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Artifacts/EnhancedFocusUsed.png"));
		
		helper.Content.Artifacts.RegisterArtifact("EnhancedFocus", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CullDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = ActiveSprite.Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "EnhancedFocus", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Cull","artifact", "EnhancedFocus", "description"]).Localize
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
	
	public override Spr GetSprite()
	{
		if (!_used)
		{
			return ActiveSprite.Sprite;
		}
		return InactiveSprite.Sprite;
	}
	
	public override List<Tooltip>? GetExtraTooltips()
	{
		List<Tooltip> tooltips =
		[
			new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::SoulEnergy")
			{
				Icon = ModEntry.Instance.soulEnergySprite.Sprite,
				TitleColor = Colors.status,
				Title = ModEntry.Instance.Localizations.Localize(["Cull", "status", "SoulEnergy", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull", "status", "SoulEnergy", "description"])
			}];
		return tooltips;
	}
}
