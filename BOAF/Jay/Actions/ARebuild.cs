using FSPRO;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;


namespace Flipbop.BOAF;

public sealed class ARebuild : CardAction
{
	public required int Part;

	public override void Begin(G g, State s, Combat c)
	{

	}
	
	
	public override Icon? GetIcon(State s)
	{
		return new Icon(ModEntry.Instance.rebuildSprite.Sprite, number: Part,color: Colors.textMain, flipY: false);
	}

	public override List<Tooltip> GetTooltips(State s)
		=> [
			new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Rebuild")
			{
				Icon = ModEntry.Instance.rebuildSprite.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Jay","action", "Rebuild", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Rebuild", "description"])
			}
		];
}
