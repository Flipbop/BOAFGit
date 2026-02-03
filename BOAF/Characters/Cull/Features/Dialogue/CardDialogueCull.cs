using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;


namespace Flipbop.BOAF;

internal class CardDialogueCull
{
    public CardDialogueCull()
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
                        new(AmCat, "Little bit of dark magic."),
                        new(AmCull, "angry", "But that's MY shtick!")
                    ]
                }
            },
        });
    }
}