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
                        new(AmCat, "I feel more in-tune with the ship.")
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
                        new(AmCat, "My turn to screw with the ship's layout."),
                        new(AmCenti,  "Have fun!")
                    ]
                }
            },
        });
    }
}