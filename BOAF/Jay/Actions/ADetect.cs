using System;
using FSPRO;
using Nickel;
using System.Collections.Generic;
using Flipbop.BOAF;


namespace Flipbop.BOAF;

public sealed class ADetect : CardAction
{
  public required int Amount;

  private GlossaryTooltip cannonDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::cannonDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "cannon"])
  };
  private GlossaryTooltip wingDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::wingDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "wing"])
  };
  private GlossaryTooltip commsDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::commsDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "comms"])
  };
  private GlossaryTooltip bayDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::bayDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "missileBay"])
  };
  private GlossaryTooltip cockpitDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::cockpitDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "cannon"])
  };
  private GlossaryTooltip otherDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::otherDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "other"])
  };
  private GlossaryTooltip cannonGreyDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::cannonGreyDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "cannonGrey"])
  };
  private GlossaryTooltip wingGreyDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::wingGreyDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "wingGrey"])
  };
  private GlossaryTooltip commsGreyDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::commsGreyDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "commsGrey"])
  };
  private GlossaryTooltip bayGreyDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::bayGreyDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "missileBayGrey"])
  };
  private GlossaryTooltip cockpitGreyDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::cockpitGreyDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "cannonGrey"])
  };
  private GlossaryTooltip otherGreyDetect = new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::otherGreyDetect") {
    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "otherGrey"])
  };
	public override void Begin(G g, State s, Combat c)
	{
    if (s.ship.parts[0].type == PType.cannon)
    {
      c.Queue(new AAttack(){damage = Card.GetActualDamage(s,2)});
    } else if (s.ship.parts[0].type == PType.cockpit)
    {
      c.Queue(new AStatus(){status = Status.shield, statusAmount = 1, targetPlayer = true});
      c.Queue(new AStatus(){status = Status.tempShield, statusAmount = 1, targetPlayer = true});
    } else if (s.ship.parts[0].type == PType.comms)
    {
      c.Queue(new AEnergy(){changeAmount = 1});
    } else if (s.ship.parts[0].type == PType.missiles)
    {
      c.Queue(new AStatus(){status = Status.droneShift, statusAmount = 2, targetPlayer = true});
    } else if (s.ship.parts[0].type == PType.wing)
    {
      c.Queue(new AStatus(){status = Status.evade, statusAmount = 1, targetPlayer = true});
    } else
    {
      c.Queue(new AReconfigure(){Amount = 1});
    }
	}
  
  public override Icon? GetIcon(State s)
  {
    return new Icon(ModEntry.Instance.reconfigureSprite.Sprite, number: Amount,color: Colors.textMain, flipY: false);
  }
  
	public override List<Tooltip> GetTooltips(State s)
      {
        List<Tooltip> tooltips = new List<Tooltip>();
        tooltips.Add(new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Detect") {
          Icon = ModEntry.Instance.reconfigureSprite.Sprite,
          TitleColor = Colors.action,
          Title = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "name"]),
          Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Detect", "description"])
        });
        
        if (s.ship.parts[0].type == PType.cannon)
        {
          tooltips.Add(wingGreyDetect);
          tooltips.Add(cannonDetect);
          tooltips.Add(cockpitGreyDetect);
          tooltips.Add(bayGreyDetect);
          tooltips.Add(commsGreyDetect);
          tooltips.Add(otherGreyDetect);
          
          tooltips.Add(new TTGlossary("action.attack.name"));
        } else if (s.ship.parts[0].type == PType.cockpit)
        {
          tooltips.Add(wingGreyDetect);
          tooltips.Add(cannonGreyDetect);
          tooltips.Add(cockpitDetect);
          tooltips.Add(bayGreyDetect);
          tooltips.Add(commsGreyDetect);
          tooltips.Add(otherGreyDetect);
          
          tooltips.Add(new TTGlossary("status.shield"));
          tooltips.Add(new TTGlossary("status.tempShield"));
        } else if (s.ship.parts[0].type == PType.comms)
        {
          tooltips.Add(wingGreyDetect);
          tooltips.Add(cannonGreyDetect);
          tooltips.Add(cockpitGreyDetect);
          tooltips.Add(bayGreyDetect);
          tooltips.Add(commsDetect);
          tooltips.Add(otherGreyDetect);
          
          foreach (Tooltip tooltip in new AEnergy().GetTooltips(s))
            tooltips.Add(tooltip);
        } else if (s.ship.parts[0].type == PType.missiles)
        {
          tooltips.Add(wingGreyDetect);
          tooltips.Add(cannonGreyDetect);
          tooltips.Add(cockpitGreyDetect);
          tooltips.Add(bayDetect);
          tooltips.Add(commsGreyDetect);
          tooltips.Add(otherGreyDetect);
          tooltips.Add(new TTGlossary("status.droneshift"));
        } else if (s.ship.parts[0].type == PType.wing)
        {
          tooltips.Add(wingDetect);
          tooltips.Add(cannonGreyDetect);
          tooltips.Add(cockpitGreyDetect);
          tooltips.Add(bayGreyDetect);
          tooltips.Add(commsGreyDetect);
          tooltips.Add(otherGreyDetect);
          tooltips.Add(new TTGlossary("status.evade"));
        } else
        {
          tooltips.Add(wingGreyDetect);
          tooltips.Add(cannonGreyDetect);
          tooltips.Add(cockpitGreyDetect);
          tooltips.Add(bayGreyDetect);
          tooltips.Add(commsGreyDetect);
          tooltips.Add(otherDetect);
          tooltips.Add(new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Reconfigure") {
            Icon = ModEntry.Instance.reconfigureSprite.Sprite,
            TitleColor = Colors.action,
            Title = ModEntry.Instance.Localizations.Localize(["Jay","action", "Reconfigure", "name"]),
            Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Reconfigure", "description"])
          });
        }
        return tooltips;
      }
}
