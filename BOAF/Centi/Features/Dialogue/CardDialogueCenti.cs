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
                "CATsummonedJayCard_Multi_0", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [AmCat],
                    lookup = ["summonJay"],
                    oncePerCombatTags = ["summonJayTag"],
                    dialogue =
                    [
                        new(AmCat, "I feel more in-tune with the ship.")
                    ]
                }
            },
            {
                "CATsummonedJayCard_Multi_1", new()
                {
                    type = NodeType.combat,
                    oncePerRun = true,
                    allPresent = [AmCat, AmJay],
                    lookup = ["summonJay"],
                    oncePerCombatTags = ["summonJayTag"],
                    dialogue =
                    [
                        new(AmCat, "My turn to screw with the ship's layout."),
                        new(AmJay,  "Have fun!")
                    ]
                }
            },
        });
    }
}