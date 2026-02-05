using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;


namespace Flipbop.BOAF;

internal class CardDialogueCenti
{
    public CardDialogueCenti()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {
                "CATsummonedCentiCard_Multi_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [AmCat],
                    lookup = ["summonCenti"],
                    oncePerCombatTags = ["summonCentiTag"],
                    dialogue =
                    [
                        new(AmCat, "Could use some cybernetic defense.")
                    ]
                }
            },
            {
                "CATsummonedCentiCard_Multi_1", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [AmCat, AmCenti],
                    lookup = ["summonCenti"],
                    oncePerCombatTags = ["summonCentiTag"],
                    dialogue =
                    [
                        new(AmCat, "How exactly do these cores work?"),
                        new(AmCenti,  "A bunch of technology I don't understand.")
                    ]
                }
            },
        });
    }
}