using Nickel;

namespace Flipbop.BOAF;

public interface IBOAFApi
{
	IDeckEntry CullDeck { get; }
	
	Tooltip GetSoulEnergyTooltip(bool onOrOff);
	Tooltip GetFearTooltip(bool onOrOff);
}