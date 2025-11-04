using System.Collections;
using FSPRO;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Microsoft.Extensions.Logging;


namespace Flipbop.BOAF;

public class AFactoryResetManager {
    public AFactoryResetManager()
    {
        ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(Artifact.OnCombatStart), (State state) =>
        {
            for (int i = 0; i < state.ship.parts.Count; i++)
            {
                ModEntry.Instance.helper.ModData.SetModData(state.ship.parts[i], "originalPosition", i);
            }
        });
    }
    public sealed class AFactoryReset : CardAction
    {

        public override void Begin(G g, State s, Combat c)
        {
            List<Part> orignalOrder = [];
            for (int i = 0; i < s.ship.parts.Count; i++)          
            {
                foreach (Part p in s.ship.parts)
                {
                    if (ModEntry.Instance.helper.ModData.GetModDataOrDefault<int>(p, "originalPosition", 0) == i)
                    {
                        orignalOrder.Add(p);
                    }
                }
            }
            s.ship.parts.Clear();
            foreach (Part p in orignalOrder)
            {
                s.ship.parts.Add(p);
            }
            foreach (Part p in s.ship.parts)
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
        }
    }
}
