using FSPRO;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;


namespace Flipbop.BOAF;

public sealed class APartModification : CardAction
{
	public required Part part;
	public PDamMod modifier = PDamMod.armor;
	private PDamMod storage;

	public override void Begin(G g, State s, Combat c)
	{
		storage = part.damageModifier;
		part.damageModifier = modifier;
		
	}
	
}
