using Nickel;

namespace Flipbop.BOAF;

public sealed class ApiImplementation : IBOAFApi
{
	public IDeckEntry CullDeck
		=> ModEntry.Instance.CullDeck;
	
	public Tooltip GetSoulEnergyTooltip(bool amount)
		=> new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::SoulEnergy")
		{
			Icon = ModEntry.Instance.ImprovedIcon.Sprite,
			TitleColor = Colors.cardtrait,
			Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulEnergy", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulEnergy", "description"])
		};
	public Tooltip GetFearTooltip(bool amount)
		=> new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::Fear")
		{
			Icon = ModEntry.Instance.ImprovedIcon.Sprite,
			TitleColor = Colors.cardtrait,
			Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "Fear", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "Fear", "description"])
		};
	public Tooltip GetSoulDrainTooltip(bool amount)
		=> new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::SoulDrain")
		{
			Icon = ModEntry.Instance.ImprovedIcon.Sprite,
			TitleColor = Colors.cardtrait,
			Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulDrain", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulDrain", "description"])
		};

}
