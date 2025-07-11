using FSPRO;
using Nickel;
using System.Collections.Generic;


namespace Flipbop.BOAF;

public sealed class AHarvestAttack : AAttack
{
	public override void Begin(G g, State s, Combat c)
	{
		base.Begin(g, s, c);

	}

	public override Icon? GetIcon(State s)
	{
		return new Icon(ModEntry.Instance.harvestAttackSprite.Sprite, number: damage,color: Colors.redd, flipY: false);
	}

	public override List<Tooltip> GetTooltips(State s)
		=> [
			new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Impair")
			{
				Icon = ModEntry.Instance.harvestAttackSprite.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Cull","action", "HarvestAttack", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Cull","action", "HarvestAttack", "description"])
			}
		];
}
