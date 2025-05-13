using Nanoray.PluginManager;
using Nickel;

namespace Flipbop.BOAF;

internal interface IRegisterable
{
	static abstract void Register(IPluginPackage<IModManifest> package, IModHelper helper);
}