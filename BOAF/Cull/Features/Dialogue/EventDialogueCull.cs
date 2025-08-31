using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;


namespace Flipbop.BOAF;

internal class EventDialogueCull
{
    public EventDialogueCull()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            {$"ChoiceCardRewardOfYourColorChoice_{AmCull}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmCull ],
                bg = "BGBootSequence",
                dialogue = [
                    new(AmCull, "squint", "That felt weird."),
                    new(AmCat, "Energy readings are back to normal.")
                ]
            }},
            {"ShopkeeperInfinite_Cull_Multi_0", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "neutral", "Hi Cleo!"),
                    new(AmShopkeeper, "Hey bud!", true),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {"ShopkeeperInfinite_Cull_Multi_1", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmCull ],
                dialogue = [
                    new(AmCull, "neutral", "Cool shop!"),
                    new(AmShopkeeper, "Thank you!", true),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {$"CrystallizedFriendEvent_{AmCull}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmCull ],
                bg = "BGCrystalizedFriend",
                dialogue = [
                    new(new Wait{secs = 1.5}),
                    new(AmCull, "squint", "Huh? Wuh? What's going on?")
                ]
            }},
            {$"LoseCharacterCard_{AmCull}", new(){
                type = NodeType.@event,
                allPresent = [ AmCull ],
                oncePerRun = true,
                bg = "BGSupernova",
                dialogue = [
                    new(AmCull, "squint", "Not the worst outcome.")
                ]
            }},
            {"CrystallizedFriendEvent", new () {
                    edit = [    
                        new (EMod.countFromStart, 1, AmCull, "squint", "I think I might be due for a nap.")
                    ]
            }},
            {"DraculaTime", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "An undead? In this region of space?")
                ]
            }},
            {"ForeignCardOffering_After", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "neutral", "Interesting. Could be useful.")
                ]
            }},
            {"ForeignCardOffering_Refuse", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "Nuh uh.")
                ]
            }},
            {"GrandmaShop", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "neutral", "Chocolate peanut butter cups!")
                ]
            }},
            {"Knight_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "neutral", "A knight versus a necromancer, huh?")
                ]
            }},
            {"LoseCharacterCard", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "nervous","That's not good!")
                ]
            }},
            {"LoseCharacterCard_No", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "angry", "At least it wasn't during a fight.")
                ]
            }},
            {"Sasha_2_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "neutral", "We can play a little bit.")
                ]
            }},
            {"SogginsEscape_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "angry", "So you want to be blown up?")
                ]
            }},
            {"Soggins_Infinite", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "I don't like this frog's vibes.")
                ]
            }},
        });
    }
}