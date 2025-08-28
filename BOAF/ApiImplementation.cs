using Nickel;

namespace Flipbop.BOAF;

public sealed class ApiImplementation : IBOAFApi
{
	public IDeckEntry CullDeck
		=> ModEntry.Instance.CullDeck;

	public IStatusEntry SoulEnergyStatus => ModEntry.Instance.SoulEnergyStatus;
	public IStatusEntry FearStatus => ModEntry.Instance.FearStatus;
	public IStatusEntry SoulDrainStatus => ModEntry.Instance.SoulDrainStatus;

	public Tooltip GetSoulEnergyTooltip(bool amount)
		=> new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::SoulEnergy")
		{
			Icon = ModEntry.Instance.soulEnergySprite.Sprite,
			TitleColor = Colors.cardtrait,
			Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulEnergy", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulEnergy", "description"])
		};
	public Tooltip GetFearTooltip(bool amount)
		=> new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::Fear")
		{
			Icon = ModEntry.Instance.fearSprite.Sprite,
			TitleColor = Colors.cardtrait,
			Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "Fear", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "Fear", "description"])
		};
	public Tooltip GetSoulDrainTooltip(bool amount)
		=> new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::SoulDrain")
		{
			Icon = ModEntry.Instance.soulDrainSprite.Sprite,
			TitleColor = Colors.cardtrait,
			Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulDrain", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "SoulDrain", "description"])
		};
	
	public Tooltip GetEmpoweredTooltip(bool amount)
		=> new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::Empowered")
		{
			Icon = ModEntry.Instance.empoweredSprite.Sprite,
			TitleColor = Colors.cardtrait,
			Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "Empowered", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "Empowered", "description"])
		};
	public Tooltip GetCloakedTooltip(bool amount)
		=> new GlossaryTooltip($"status.{ModEntry.Instance.Package.Manifest.UniqueName}::Cloaked")
		{
			Icon = ModEntry.Instance.cloakedSprite.Sprite,
			TitleColor = Colors.cardtrait,
			Title = ModEntry.Instance.Localizations.Localize(["Cull","status", "Cloaked", "name"]),
			Description = ModEntry.Instance.Localizations.Localize(["Cull","status", "Cloaked", "description"])
		};

}
