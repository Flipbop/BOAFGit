using System.Collections.Generic;
using Nickel;
using System.Linq;
using FSPRO;
using Microsoft.Extensions.Logging;
using Shockah.Kokoro;

namespace Flipbop.BOAF;
internal sealed class StardustCostManager
{
    public StardustCostManager()
    {
        ModEntry.Instance.KokoroApi.ActionCosts.RegisterResourceCostIcon(new StardustCost(), ModEntry.Instance.stardustSprite.Sprite, ModEntry.Instance.stardustCostSprite.Sprite);
    }
}

internal sealed class StardustCost : IKokoroApi.IV2.IActionCostsApi.IResource
{
    public string ResourceKey => "BOAF::Stardust";
    public int GetCurrentResourceAmount(State state, Combat combat)
    {
        return state.ship.Get(ModEntry.Instance.StardustStatus.Status);
    }

    public void Pay(State s, Combat c, int amount)
    {
        c.QueueImmediate(new AStatus(){status = ModEntry.Instance.StardustStatus.Status, statusAmount = -amount, targetPlayer = true});
        if (s.EnumerateAllArtifacts().Any((a) => a is BackupCrystalArtifact) && s.ship.Get(ModEntry.Instance.StardustStatus.Status) <= 0)
        {
	        if (!BackupCrystalArtifact.used)
	        {
		        BackupCrystalArtifact.used = true;
		        c.QueueImmediate(new AStatus(){statusAmount = 10, status = ModEntry.Instance.StardustStatus.Status, targetPlayer = true});
	        }
        }
        if (s.EnumerateAllArtifacts().Any((a) => a is ChronomancyArtifact))
        {
	        c.QueueImmediate(new AStatus(){statusAmount = 1, status = Status.timeStop, targetPlayer = true});
        }
    }

    public IReadOnlyList<Tooltip> GetTooltips(State state, Combat combat, int amount)
	    => [
		    new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::StardustCost")
		    {
			    Icon = ModEntry.Instance.stardustCostSprite.Sprite,
			    TitleColor = Colors.action,
			    Title = ModEntry.Instance.Localizations.Localize(["Luna","action", "StardustCost", "name"]),
			    Description = ModEntry.Instance.Localizations.Localize(["Luna","action", "StardustCost", "description"]),
			    vals = [amount]
		    }
	    ];
}
