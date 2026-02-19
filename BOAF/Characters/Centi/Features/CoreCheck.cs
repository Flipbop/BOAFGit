using System.Collections.Generic;
using Nickel;
using System.Linq;
using FSPRO;
using Microsoft.Extensions.Logging;
using Shockah.Kokoro;

namespace Flipbop.BOAF;
internal sealed class DemonCoreCheckManager
{
    public DemonCoreCheckManager()
    {
        ModEntry.Instance.KokoroApi.ActionCosts.RegisterResourceCostIcon(new DemonCoreCheck(), ModEntry.Instance.DemonCoreIcon.Sprite, ModEntry.Instance.DemonCoreEmptyIcon.Sprite);
        
    }
}

internal sealed class DemonCoreCheck : IKokoroApi.IV2.IActionCostsApi.IResource
{
    public string ResourceKey => "BOAF::DemonCore";
    public int GetCurrentResourceAmount(State state, Combat combat)
    {
	    Dictionary<int, StuffBase> check = combat.stuff;
	    if (check.Values.Any(o => o is DemonCore) ||
	        check.Values.Any(o => o is LavaCore) ||
	        check.Values.Any(o => o is BrimstoneCore) ||
	        check.Values.Any(o => o is InfinityCore))
		    return 1;
	    return 0;
    }
    
    public void Pay(State s, Combat c, int amount)
    {
        
    }

    public IReadOnlyList<Tooltip> GetTooltips(State state, Combat combat, int amount)
	    => [
		    new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::DemonAction")
		    {
			    Icon = ModEntry.Instance.DemonCoreEmptyIcon.Sprite,
			    TitleColor = Colors.action,
			    Title = ModEntry.Instance.Localizations.Localize(["Centi","action", "DemonAction", "name"]),
			    Description = ModEntry.Instance.Localizations.Localize(["Centi","action", "DemonAction", "description"]),
		    }
	    ];
}


internal sealed class AquaCoreCheckManager
{
	public AquaCoreCheckManager()
	{
		ModEntry.Instance.KokoroApi.ActionCosts.RegisterResourceCostIcon(new AquaCoreCheck(), ModEntry.Instance.AquaCoreIcon.Sprite, ModEntry.Instance.AquaCoreEmptyIcon.Sprite);
	}
}

internal sealed class AquaCoreCheck : IKokoroApi.IV2.IActionCostsApi.IResource
{
	public string ResourceKey => "BOAF::AquaCore";
	public int GetCurrentResourceAmount(State state, Combat combat)
	{
		Dictionary<int, StuffBase> check = combat.stuff;
		if (check.Values.Any(o => o is AquaCore) ||
		    check.Values.Any(o => o is LavaCore) ||
		    check.Values.Any(o => o is MossCore) ||
		    check.Values.Any(o => o is InfinityCore))
			return 1;
		return 0;
	}
    
	public void Pay(State s, Combat c, int amount)
	{
        
	}

	public IReadOnlyList<Tooltip> GetTooltips(State state, Combat combat, int amount)
		=> [
			new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::AquaAction")
			{
				Icon = ModEntry.Instance.AquaCoreEmptyIcon.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","action", "AquaAction", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","action", "AquaAction", "description"]),
			}
		];
}


internal sealed class StoneCoreCheckManager
{
	public StoneCoreCheckManager()
	{
		ModEntry.Instance.KokoroApi.ActionCosts.RegisterResourceCostIcon(new StoneCoreCheck(), ModEntry.Instance.StoneCoreIcon.Sprite, ModEntry.Instance.StoneCoreEmptyIcon.Sprite);
	}
}

internal sealed class StoneCoreCheck : IKokoroApi.IV2.IActionCostsApi.IResource
{
	public string ResourceKey => "BOAF::StoneCore";
	public int GetCurrentResourceAmount(State state, Combat combat)
	{
		Dictionary<int, StuffBase> check = combat.stuff;
		if (check.Values.Any(o => o is StoneCore) ||
		    check.Values.Any(o => o is MossCore) ||
		    check.Values.Any(o => o is BrimstoneCore) ||
		    check.Values.Any(o => o is InfinityCore))
			return 1;
		return 0;
	}
    
	public void Pay(State s, Combat c, int amount)
	{
        
	}

	public IReadOnlyList<Tooltip> GetTooltips(State state, Combat combat, int amount)
		=> [
			new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::StoneAction")
			{
				Icon = ModEntry.Instance.StoneCoreEmptyIcon.Sprite,
				TitleColor = Colors.action,
				Title = ModEntry.Instance.Localizations.Localize(["Centi","action", "StoneAction", "name"]),
				Description = ModEntry.Instance.Localizations.Localize(["Centi","action", "StoneAction", "description"]),
			}
		];
}