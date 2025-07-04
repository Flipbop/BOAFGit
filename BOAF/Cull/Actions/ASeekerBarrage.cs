﻿using System;
using FSPRO;
using Nickel;
using System.Collections.Generic;


namespace Flipbop.BOAF;

public sealed class ASeekerBarrage : DynamicWidthCardAction
{
	public required int Amount;

	public override void Begin(G g, State s, Combat c)
	{
		base.Begin(g, s, c);
		int index = c.hand.Count -1;
		while (index >= 0)
		{
			if (c.hand[index].upgrade != Upgrade.None)
			{
				c.Queue(new AMove{dir= 1, targetPlayer = true});
				c.Queue(new ASpawn{fromPlayer = true, thing = new Missile{missileType = MissileType.seeker}});
			}
			index--;
		}
	}

	public override Icon? GetIcon(State s)
		=> new(ModEntry.Instance.placeholderSprite.Sprite, Amount == -1 ? null : Amount, Colors.textMain);

	public override List<Tooltip> GetTooltips(State s)
	{
		List<Tooltip> tooltips = new List<Tooltip>();
		tooltips.AddRange(new AMove {dir = 1 + s.ship.Get(Status.hermes), targetPlayer = true}.GetTooltips(s));
		tooltips.AddRange(new ASpawn { thing = new Missile { missileType = MissileType.seeker } }.GetTooltips(s));
		return tooltips;
	}
}
