using Nickel;

namespace Flipbop.BOAF;

public interface IBOAFApi
{
	IDeckEntry CullDeck { get; }
	IStatusEntry SoulEnergyStatus { get; }
	IStatusEntry FearStatus { get; }
	IStatusEntry SoulDrainStatus { get; }
	IStatusEntry CloakedStatus { get; }
	IStatusEntry EmpoweredStatus { get; }
	Tooltip GetSoulEnergyTooltip(bool onOrOff);
	Tooltip GetFearTooltip(bool onOrOff);
	Tooltip GetSoulDrainTooltip(bool onOrOff);
	Tooltip GetCloakedTooltip(bool onOrOff);
	Tooltip GetEmpoweredTooltip(bool onOrOff);
	
	IDeckEntry JayDeck { get; }
	IStatusEntry SignalBoosterStatus { get; }
	IStatusEntry LessEnergyAllTurnsStatus { get; }
	Tooltip GetSignalBoosterTooltip(bool onOrOff);
	Tooltip GetLessEnergyAllTurnsTooltip(bool onOrOff);
}