using Nickel;

namespace Flipbop.BOAF;

public interface IBOAFApi
{
	IDeckEntry CullDeck { get; }
	IStatusEntry SoulEnergyStatus { get; }
	IStatusEntry FearStatus { get; }
	IStatusEntry SoulDrainStatus { get; }
	
	Tooltip GetSoulEnergyTooltip(bool onOrOff);
	Tooltip GetFearTooltip(bool onOrOff);
	Tooltip GetSoulDrainTooltip(bool onOrOff);
}