using FSPRO;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;


namespace Flipbop.BOAF;

public sealed class AReconfigure : CardAction
{
	public required int Amount;
	public bool reverse = false;

	public static int codeInspectionAmount = 0;
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
				var part = s.ship.parts[^1];
				s.ship.parts.RemoveAt(s.ship.parts.Count - 1);
				s.ship.parts.Insert(0, part);
			}
		}

		if (s.EnumerateAllArtifacts().Any((a) => a is CodeInspectionArtifact))
		{
			codeInspectionAmount++;
			if (codeInspectionAmount >= 3)
			{
				c.QueueImmediate(new AAddCard(){amount = 1, card = new InspectionCard(), destination = CardDestination.Hand});
				codeInspectionAmount = 0;
			}
		}
	}
	
	
	public override Icon? GetIcon(State s)
	{
		return new Icon(ModEntry.Instance.reconfigureSprite.Sprite, number: Amount,color: Colors.textMain, flipY: false);
	}

	public override List<Tooltip> GetTooltips(State s)
	{
		List<Tooltip> tooltips = base.GetTooltips(s);
		if (reverse)
			return tooltips;
		else
			tooltips.Add(new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Reconfigure")
			{
				Icon = ModEntry.Instance.reconfigureSprite.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Jay", "action", "Reconfigure", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Jay", "action", "Reconfigure", "description"])
			});
		return tooltips;
	}
			
		
}
