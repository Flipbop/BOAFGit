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
	public bool reverse = false;

	public override void Begin(G g, State s, Combat c)
	{
		if (!reverse)
		{
			for (int b = 0; b < Amount; b++)
			{
				Part leftmost = s.ship.parts[0];
				for (int i = 1; i < s.ship.parts.Count; i++)
				{
					s.ship.parts[i - 1] = s.ship.parts[i];
				}

				s.ship.parts[^1] = leftmost;
			}
		}
		else
		{
			for (int b = 0; b < Amount; b++)
			{
				Part rightmost = s.ship.parts[^1];
				for (int i = s.ship.parts.Count; i > 0; i--)
				{
					s.ship.parts[i + 1] = s.ship.parts[i];
				}

				s.ship.parts.Insert(0, rightmost);
			}
		}
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
