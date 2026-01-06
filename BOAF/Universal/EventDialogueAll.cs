using System.Collections.Generic;
using static Flipbop.BOAF.CommonDefinitions;


namespace Flipbop.BOAF;

internal class EventDialogueAll
{
    public EventDialogueAll()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            #region Cull
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
            #endregion
            #region Jay
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
                    new(AmJay, "squint", "Again? Alright...")
                ]
            }},
            {$"LoseCharacterCard_{AmJay}", new(){
                type = NodeType.@event,
                allPresent = [ AmJay ],
                oncePerRun = true,
                bg = "BGSupernova",
                dialogue = [
                    new(AmJay,  "At least the ship is ok.")
                ]
            }},
            #endregion
            #region Luna
            {$"ChoiceCardRewardOfYourColorChoice_{AmLuna}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmLuna ],
                bg = "BGBootSequence",
                dialogue = [
                    new(AmLuna, "squint", "That felt weird. Too weird."),
                    new(AmCat, "Energy readings are back to normal.")
                ]
            }},
            {"ShopkeeperInfinite_Luna_Multi_0", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmLuna ],
                dialogue = [
                    new(AmLuna, "neutral", "I love your little drone!"),
                    new(AmShopkeeper, "Thanks!", true),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {"ShopkeeperInfinite_Luna_Multi_1", new(){
                type = NodeType.@event,
                lookup = [ "shopBefore" ],
                bg = "BGShop",
                allPresent = [ AmLuna ],
                dialogue = [
                    new(AmLuna, "neutral", "Hi Cleo!"),
                    new(AmShopkeeper, "Hey Luna!", true),
                    new(new Jump{key = "NewShop"})
                ]
            }},
            {$"CrystallizedFriendEvent_{AmLuna}", new(){
                type = NodeType.@event,
                oncePerRun = true,
                allPresent = [ AmLuna ],
                bg = "BGCrystalizedFriend",
                dialogue = [
                    new(new Wait{secs = 1.5}),
                    new(AmLuna, "squint", "Huh? Oh, hi everyone.")
                ]
            }},
            {$"LoseCharacterCard_{AmLuna}", new(){
                type = NodeType.@event,
                allPresent = [ AmLuna ],
                oncePerRun = true,
                bg = "BGSupernova",
                dialogue = [
                    new (new Wait {secs = 1.5}),
                    new(AmLuna,  "Doesn't feel the greatest.")
                ]
            }},
            #endregion
            #region Centi
            
            #endregion
            #region Eva
            
            #endregion
            
            #region Edits
            {"CrystallizedFriendEvent", new () {
                    edit = [    
                        new (EMod.countFromStart, 1, AmCull, "squint", "I think I might be due for a nap."),
                        new (EMod.countFromStart, 1, AmJay,  "If I'm going, make sure the ship stays intact."),
                        new (EMod.countFromStart, 1, AmLuna,  "squint","Wake me up when we we're there.")
                    ]
            }},
            {"DraculaTime", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "An undead? In this region of space?"),
                    new(EMod.countFromStart, 1, AmJay, "squint", "I don't recall meeting any Draculas before."),
                    new(EMod.countFromStart, 1, AmLuna, "squint", "I don't like this guys vibe...")
                ]
            }},
            {"ForeignCardOffering_After", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "neutral", "Interesting. Could be useful."),
                    new(EMod.countFromStart, 1, AmJay, "neutral", "I don't see why not."),
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Couldn't hurt, right?")
                ]
            }},
            {"ForeignCardOffering_Refuse", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "Nuh uh."),
                    new(EMod.countFromStart, 1, AmJay, "squint", "Maybe best if we don't."),
                    new(EMod.countFromStart, 1, AmLuna, "squint", "Probably a good idea.")
                ]
            }},
            {"GrandmaShop", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "neutral", "Chocolate peanut butter cups!"),
                    new(EMod.countFromStart, 1, AmJay, "neutral", "Do you have any peanuts?"),
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Cosmic brownies!")
                ]
            }},
            {"Knight_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "neutral", "A knight versus a necromancer, huh?"),
                    new(EMod.countFromStart, 1, AmJay, "neutral", "What an interesting ship. Sure isn't my design."),
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Ooooh, hello little knight!")
                ]
            }},
            {"LoseCharacterCard", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "nervous","That's not good!"),
                    new(EMod.countFromStart, 1, AmJay,"Better than hull damage."),
                    new(EMod.countFromStart, 1, AmLuna,"Doesn't feel the greatest.")
                ]
            }},
            {"LoseCharacterCard_No", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "angry", "At least it wasn't during a fight."),
                    new(EMod.countFromStart, 1, AmJay, "angry", "Not a fan of the hull getting damaged so severely."),
                    new(EMod.countFromStart, 1, AmLuna, "nervous", "Did we plan for that?")

                ]
            }},
            {"Sasha_2_Multi_2", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "neutral", "We can play a little bit."),
                    new(EMod.countFromStart, 1, AmJay, "neutral", "I'm up for a game."),
                    new(EMod.countFromStart, 1, AmLuna, "neutral", "Sports!")

                ]
            }},
            {"SogginsEscape_1", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "angry", "So you want to be blown up?"),
                    new(EMod.countFromStart, 1, AmJay, "angry", "Not on my watch."),
                    new(EMod.countFromStart, 1, AmLuna,  "Nuh-uh.")

                ]
            }},
            {"Soggins_Infinite", new(){
                edit = [
                    new(EMod.countFromStart, 1, AmCull, "squint", "I don't like this frog's vibes."),
                    new(EMod.countFromStart, 1, AmJay, "squint", "This frog annoys me."),
                    new(EMod.countFromStart, 1, AmLuna,  "...")

                ]
            }},
            #endregion
            
        });
    }
}