using FSPRO;
using Nickel;
using System.Collections.Generic;
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
                    p.damageModifier =
                        ModEntry.Instance.helper.ModData.GetModDataOrDefault<PDamMod>(p, "previousModifier", PDamMod.none);
                    ModEntry.Instance.helper.ModData.SetModData(p, "modified", false);
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
                part.damageModifier = modifier;
            }
            else
            {
                part.damageModifier = modifier;
            }
        }
    }

}
