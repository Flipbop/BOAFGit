using FSPRO;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;


namespace Flipbop.BOAF;

public sealed class AReconfigure : CardAction
{
	public required int Amount;

	public override void Begin(G g, State s, Combat c)
	{

	}
	
	
	public override Icon? GetIcon(State s)
	{
		return new Icon(ModEntry.Instance.reconfigureSprite.Sprite, number: Amount,color: Colors.textMain, flipY: false);
	}

	public override List<Tooltip> GetTooltips(State s)
		=> [
			new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Reconfigure")
			{
				Icon = ModEntry.Instance.reconfigureSprite.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Jay","action", "Reconfigure", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Reconfigure", "description"])
			}
		];
}
