using System;
using FSPRO;
using Nickel;
using System.Collections.Generic;
using Flipbop.BOAF;


namespace Flipbop.BOAF;

public sealed class ALastStand : CardAction
{
  public bool bUpgrade = false;

	public override void Begin(G g, State s, Combat c)
	{
		base.Begin(g, s, c);
    timer = 0.0;
    int count = 0;
    if (bUpgrade)
    {
      foreach (var stuff in c.stuff)
      {
        if (stuff.Value is Core)
        {
          c.Queue(new AKillThisDrone() {droneX = stuff.Value.x, fromPlayer = true});
          c.Queue(new ASpawnFromMidrow() {thing = new Asteroid() {bubbleShield = true}, byPlayer = true, worldX = stuff.Value.x});
        }
      }
    }
    else
    {
      foreach (var stuff in c.stuff)
      {
        if (stuff.Value is Core)
        {
          c.Queue(new AKillThisDrone() {droneX = stuff.Value.x, fromPlayer = true});
          count++;
        }
      }
    }

    for (int i = 0; i < count; i++)
    {
      if (!bUpgrade)
      {
        c.Queue(new AAttack() {damage = Card.GetActualDamage(s, 2)});
      }
    }
	}
	
	public override List<Tooltip> GetTooltips(State s)
      {
        List<Tooltip> tooltips = new List<Tooltip>();
        tooltips.Add(new TTGlossary("action.attack.name"));
        if (bUpgrade)
        {
          tooltips.Add(new TTGlossary("midrow.asteroid.name"));
          tooltips.Add(new TTGlossary("midrow.asteroid.description"));
        }
        return tooltips;
      }
}
