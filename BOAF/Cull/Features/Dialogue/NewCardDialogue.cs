using System.Collections.Generic;
using Flipbop.BOAF;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using Flipbop.BOAF;

namespace Cull.Conversation;

internal class NewCardDialogue : IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {
                "CATsummonedCullCard_Multi_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [AmCat],
                    lookup = ["summonCull"],
                    oncePerCombatTags = ["summonCullTag"],
                    dialogue =
                    [
                        new(AmCat, "A little bit of necromancy can't hurt.")
                    ]
                }
            },
            {
                "CATsummonedCullCard_Multi_1", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [AmCat, AmCull],
                    lookup = ["summonCull"],
                    oncePerCombatTags = ["summonCullTag"],
                    dialogue =
                    [
                        new(AmCull, "squint", "Are you copying me?"),
                        new(AmCat, "ArE yOu CoPyInG mE?")
                    ]
                }
            },
        });
    }
}