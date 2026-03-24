using System;
using FSPRO;
using Nickel;
using System.Collections.Generic;
using Flipbop.BOAF;


namespace Flipbop.BOAF;

public sealed class ABackupCore : CardAction
{
  public bool bubbled = false;
  public bool anyObject = false;

	public override void Begin(G g, State s, Combat c)
	{
		base.Begin(g, s, c); 
		timer = 0.0; 
		
		
	}
}
