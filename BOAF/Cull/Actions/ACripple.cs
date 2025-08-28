using System;
using FSPRO;
using Nickel;
using System.Collections.Generic;
using Flipbop.BOAF;


namespace Flipbop.BOAF;

public sealed class ACripple : DynamicWidthCardAction
{
  public bool bUpgrade = false;

	public override void Begin(G g, State s, Combat c)
	{
		base.Begin(g, s, c);
    if (!bUpgrade)
    {
      c.Queue(s.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 7
        ? new AAttack() { damage = Card.GetActualDamage(s, 1), brittle = true }
        : new AAttack() { damage = Card.GetActualDamage(s, 1), weaken = true });
    }
    else
    {
      c.Queue(s.ship.Get(ModEntry.Instance.SoulEnergyStatus.Status) >= 5
        ? new AAttack() { damage = Card.GetActualDamage(s, 1), brittle = true }
        : new AAttack() { damage = Card.GetActualDamage(s, 1), weaken = true });
    }
	}
	
	public override List<Tooltip> GetTooltips(State s)
      {
        List<Tooltip> tooltips = new List<Tooltip>();
        int x = s.ship.x;
        foreach (Part part in s.ship.parts)
        {
          if (part.type == PType.cannon && part.active)
          {
            if (s.route is Combat route && route.stuff.ContainsKey(x))
              route.stuff[x].hilight = 2;
            part.hilight = true;
          }
          ++x;
        }
        if (s.route is Combat route1)
        {
          foreach (StuffBase stuffBase in route1.stuff.Values)
          {
            if (stuffBase is JupiterDrone)
              stuffBase.hilight = 2;
          }
        }
        tooltips.Add(new TTGlossary("action.attack.name"));
        return tooltips;
      }
}
