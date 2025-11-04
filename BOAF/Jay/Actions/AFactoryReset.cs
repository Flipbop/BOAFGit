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
        }
    }
}
