using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;


namespace Flipbop.BOAF;

internal class EventDialogueJay
{
    public EventDialogueJay()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            {$"ChoiceCardRewardOfYourColorChoice_{AmJay}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmJay ],
                bg = "BGBootSequence",
                dialogue = [
                    new(AmJay, "squint", "Nope. Don't like that."),
                    new(AmCat, "Energy readings are back to normal.")
                ]
            }},
            {"ShopkeeperInfinite_Jay_Multi_0", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmJay ],
                dialogue = [
                    new(AmJay, "neutral", "Cool ship!"),
                    new(AmShopkeeper, "Thanks!", true),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {"ShopkeeperInfinite_Jay_Multi_1", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmJay ],
                dialogue = [
                    new(AmJay, "neutral", "Where do you get all the parts for repairs?"),
                    new(AmShopkeeper, "That's classified.", true),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {$"CrystallizedFriendEvent_{AmJay}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmJay ],
                bg = "BGCrystalizedFriend",
                dialogue = [
                    new(new Wait{secs = 1.5}),
                    new(AmCull, "squint", "Again? Alright...")
                ]
            }},
            {$"LoseCharacterCard_{AmJay}", new(){
                type = NodeType.@event,
                allPresent = [ AmJay ],
                oncePerRun = true,
                bg = "BGSupernova",
                dialogue = [
                    new(AmCull,  "At least the ship is ok.")
                ]
            }},
            {"CrystallizedFriendEvent", new () {
                    edit = [    
                        new (EMod.countFromStart, 1, AmJay,  "If I'm going, make sure the ship stays intact.")
                    ]
            }},
            {"DraculaTime", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "squint", "I don't recall meeting any Draculas before.")
                ]
            }},
            {"ForeignCardOffering_After", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "neutral", "I don't see why not.")
                ]
            }},
            {"ForeignCardOffering_Refuse", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "squint", "Maybe best if we don't.")
                ]
            }},
            {"GrandmaShop", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "neutral", "Do you have any peanuts?")
                ]
            }},
            {"Knight_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "neutral", "What an interesting ship. Sure isn't my design.")
                ]
            }},
            {"LoseCharacterCard", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay,"Better than hull damage.")
                ]
            }},
            {"LoseCharacterCard_No", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "angry", "Not a fan of the hull getting damaged so severely.")
                ]
            }},
            {"Sasha_2_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "neutral", "I'm up for a game.")
                ]
            }},
            {"SogginsEscape_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "angry", "Not on my watch.")
                ]
            }},
            {"Soggins_Infinite", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmJay, "squint", "This frog annoys me.")
                ]
            }},
        });
    }
}