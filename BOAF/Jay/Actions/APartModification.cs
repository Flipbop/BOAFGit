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
            List<Part> orignalOrder = [];
            for (int i = 0; i < state.ship.parts.Count; i++)          
            {
                foreach (Part p in state.ship.parts)
                {
                    if (ModEntry.Instance.helper.ModData.GetModDataOrDefault<int>(p, "originalPosition", 0) == i)
                    {
                        orignalOrder.Add(p);
                    }
                }
            }
            state.ship.parts.Clear();
            foreach (Part p in orignalOrder)
            {
                state.ship.parts.Add(p);
            }
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

    public sealed class APartRebuild : DynamicWidthCardAction
    {
        public required PType newPartType;
        public required Part part;
        public string partName = "WING";
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
                part.skin = ModEntry.Instance.rebuiltWingSprite;
            } else if (newPartType == PType.cannon) {
                part.skin = ModEntry.Instance.rebuiltCannonSprite;
            } else if (newPartType == PType.cockpit) { 
                part.skin = ModEntry.Instance.rebuiltCockpitSprite;
            } else if (newPartType == PType.comms) {
                part.skin = ModEntry.Instance.rebuiltCommsSprite;
            } else if (newPartType == PType.empty) {
                part.skin = ModEntry.Instance.rebuiltScaffoldSprite;
            } else if (newPartType == PType.missiles) {
                part.skin = ModEntry.Instance.rebuiltBaySprite;
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
        public override Icon? GetIcon(State s)
        {
            if (newPartType == PType.wing) { 
                return new Icon(ModEntry.Instance.rebuildWingSprite.Sprite, null, Colors.textMain, flipY: false);

            } else if (newPartType == PType.cannon) {
                return new Icon(ModEntry.Instance.rebuildCannonSprite.Sprite, null, Colors.textMain, flipY: false);

            } else if (newPartType == PType.cockpit) { 
                return new Icon(ModEntry.Instance.rebuildCockpitSprite.Sprite, null, Colors.textMain, flipY: false);

            } else if (newPartType == PType.comms) {
                return new Icon(ModEntry.Instance.rebuildCommsSprite.Sprite, null, Colors.textMain, flipY: false);

            } else if (newPartType == PType.empty) {
                return new Icon(ModEntry.Instance.rebuildScaffoldSprite.Sprite, null, Colors.textMain, flipY: false);

            } else if (newPartType == PType.missiles) {
                return new Icon(ModEntry.Instance.rebuildBaySprite.Sprite, null, Colors.textMain, flipY: false);

            }
            return new Icon(ModEntry.Instance.rebuildSprite.Sprite, null, Colors.textMain, flipY: false);
        }

        public override List<Tooltip> GetTooltips(State s)
            => [
                new GlossaryTooltip($"action.{ModEntry.Instance.Package.Manifest.UniqueName}::Rebuild")
                {
                    Icon = ModEntry.Instance.rebuildSprite.Sprite,
                    TitleColor = Colors.action,
                    Title = ModEntry.Instance.Localizations.Localize(["Jay","action", "Rebuild", "name"], new {partName}),
                    Description = ModEntry.Instance.Localizations.Localize(["Jay","action", "Rebuild", "description"], new {partName})
                }
            ];
    }
}
