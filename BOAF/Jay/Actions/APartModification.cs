using FSPRO;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;


namespace Flipbop.BOAF;

public class APartModManager {
    public APartModManager()
    {
        ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(Artifact.OnCombatEnd), (State state) =>
        {
            foreach (Part p in state.ship.parts)
            {
                if (ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(p, "modified", false))
                {
                    p.damageModifier = ModEntry.Instance.helper.ModData.GetModDataOrDefault<PDamMod>(p, "previousModifier", PDamMod.none);
                    ModEntry.Instance.helper.ModData.SetModData(p, "modified", false);
                }
                if (ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(p, "rebuilt", false))
                {
                    p.type = ModEntry.Instance.helper.ModData.GetModDataOrDefault<PType>(p, "previousPartType", PType.wing);
                    p.skin = ModEntry.Instance.helper.ModData.GetModDataOrDefault<string?>(p, "previousPartSkin", "wing_player");
                    ModEntry.Instance.helper.ModData.SetModData(p, "rebuilt", false);
                    p.active = ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(p, "activePart", true);
                }
            }
        });
    }
    public sealed class APartModification : CardAction
    {
        public required Part part;
        public PDamMod modifier = PDamMod.armor;

        public override void Begin(G g, State s, Combat c)
        {
            if (!ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(part, "modified", false))
            {
                ModEntry.Instance.helper.ModData.SetModData(part, "previousModifier", part.damageModifier);
                ModEntry.Instance.helper.ModData.SetModData(part, "modified", true);
            }
            part.damageModifier = modifier;
        }
    }

    public sealed class APartRebuild : CardAction
    {
        public required PType newPartType;
        public required Part part;
        public override void Begin(G g, State s, Combat c)
        {
            if (!ModEntry.Instance.helper.ModData.GetModDataOrDefault<bool>(part, "rebuilt", false))
            {
                ModEntry.Instance.helper.ModData.SetModData(part, "previousPartType", part.type);
                ModEntry.Instance.helper.ModData.SetModData(part, "previousPartSkin", part.skin);
                ModEntry.Instance.helper.ModData.SetModData(part, "rebuilt", true);
            }
            part.type = newPartType;
            if (newPartType == PType.wing) { 
                part.skin = ModEntry.Instance.rebuiltWingSprite.LocalName;
            } else if (newPartType == PType.cannon) { 
                part.skin = ModEntry.Instance.rebuiltCannonSprite.LocalName;
            } else if (newPartType == PType.cockpit) { 
                part.skin = ModEntry.Instance.rebuiltCockpitSprite.LocalName;
            } else if (newPartType == PType.comms) {
                part.skin = ModEntry.Instance.rebuiltCommsSprite.LocalName;
            } else if (newPartType == PType.empty) {
                part.skin = ModEntry.Instance.rebuiltScaffoldSprite.LocalName;
            } else if (newPartType == PType.missiles) {
                part.skin = ModEntry.Instance.rebuiltBaySprite.LocalName;
            }

            if (!part.active)
            {
                ModEntry.Instance.helper.ModData.SetModData(part, "activePart", false);
                part.active = true;
            }
            else
            {
                ModEntry.Instance.helper.ModData.SetModData(part, "activePart", true);
            }

            if (s.EnumerateAllArtifacts().Any((a) => a is FinalTestArtifact))
            {
                c.QueueImmediate(new ADetect(){Amount = 1});
            }
        }
    }
}
