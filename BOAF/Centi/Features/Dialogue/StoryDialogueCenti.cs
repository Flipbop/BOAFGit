using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class StoryDialogueCenti 
{
    public StoryDialogueCenti()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>(){
            
            {"Centi_Intro_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCenti ],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "Alright everyone, let's get going!", flipped: true),
                    new(AmCenti, "squint", "This doesn't look familiar. What's going on?"),
                    new(AmCat, "Oh, you are new here. Hello! We're trapped in a time loop!", flipped: true),
                    new(AmCenti, "nervous", "A what?!"),
                    new(AmCat, "A time loop! You don't happen to have your memories do you?", flipped: true),
                    new(AmCenti, "squint", "I do, but I don't see how that is relevant."),
                    new(AmCat, "squint", "Oh. That's interesting.", flipped: true),
                ]
            }},
            {"Centi_Post_Cicada", new(){
                type = NodeType.@event,
                lookup = [ "after_any" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_0"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "squint","Just how much do you remember? No gaps in your memory?", flipped: true),
                    new(AmCenti, "No, I remember everything just fine."),
                    new(AmCat, "squint","Strange. Usually people that show up on this ship are missing key memories.", flipped: true),
                    new(AmCat, "squint","But not you. There must be some reason you are here now.", flipped: true),
                    new(AmCenti, "squint", "I can still be of use."),
                ]
            }},
            {"Centi_Intro_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_0", "Centi_Memory_1"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "squint", "Judging by the fact that space travel has not been revolutionized recently, it didn't work out?", flipped: true ),
                    new (AmCenti,"nervous","You could say that." ),
                    new (AmCat, "neutral", "That \"bat dude\" she mentioned, I think I know who that is.", flipped: true ),
                    new (AmCenti,"neutral","Really? I need to talk to him!" ),
                    new (AmCat, "neutral", "No guarantee we see him, but we can try!", flipped: true ),
                ]
            }},
            {"Centi_Pre_Smiff", new(){
                type = NodeType.@event,
                lookup = [ "before_batboy" ],
                once = true,
                priority = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_1", "Centi_Memory_1"],
                dialogue = [
                    new (AmCenti, "squint", "Did you ever sell a piece of a weird ship to some bird girl?" ),
                    new (AmSmiff,"neutral","Yeah, why?", flipped: true),
                    new (AmCenti, "angry", "The part was faulty." ),
                    new (AmSmiff,"neutral","Not my problem, that was months ago.", flipped: true ),
                    new (AmCenti, "angry", "I'm about to make it your problem." ),
                ]
            }},
            {"Centi_Post_Smiff", new(){
                type = NodeType.@event,
                lookup = [ "after_batboy" ],
                once = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Pre_Smiff"],
                dialogue = [
                    new (AmCat, "worried","Are you ok?", flipped: true),
                    new(AmCenti, "As much as I can be."),
                    new(AmCat, "worried","What was that about, anyways?", flipped: true),
                    new(AmCenti, "gameover","..."),
                    new(AmCenti, "sad", "I'll tell you after the loop."),
                    new (new SetMemoryLevel(){chararcter = ModEntry.Instance.CentiDeck.Deck, level = 2})
                ]
            }},
            {"Centi_Intro_2", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                priority = true,
                allPresent = [ AmCenti ],
                requiredScenes = ["Centi_Intro_1", "Centi_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "worried", "Oh, I'm so sorry. That can't have been easy to go through.", flipped: true ),
                    new (AmCenti,"sad","It's... alright." ),
                    new (AmCenti,"sob","There is nothing you could say that I haven't already told myself." ),
                    new (AmCat, "worried", "Don't talk like that! We're all here for you, you are our friend.", flipped: true ),
                    new (AmCenti,"tear","Thanks. It means a lot." ),
                ]
            }},
            {"Centi_Dizzy_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCenti, AmDizzy ],
                bg = "BGRunStart",
                requiredScenes = [ "Centi_Intro_0", "Centi_Memory_3" ],
                dialogue = [
                    new (AmDizzy, "Do you remember what kind of part your sister bought off Smiff?", true),
                    new (AmCenti, "squint", "Yeah, it was some sort of crystal like thing. I don't remember exactly. It was destroyed in the blast."),
                    new (AmDizzy, "crystal", "Like this?", true), 
                    new (AmCenti, "nervous", "Where did you get that?!"),
                    new (AmDizzy, "crystal", "These things are everywhere. They last between each loop, so everytime we turn the big crystal to dust some more get scattered about.", true),
                    new (AmDizzy, "crystal", "They have some weird time-warping properties, if my tests are to be believed.", true), 
                    new (AmCenti, "squint", "I guess that would make for some fast engines..."),
                ]
            }},
            {"Centi_Isaac_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                bg = "BGRunStart",
                allPresent = [AmCenti, AmIsaac],
                once = true,
                requiredScenes = ["Centi_Intro_0", "Goat_1"],
                dialogue = [
                    new (AmIsaac, "Hey Centi, I was wondering what you are doing to manipulate the ships we pilot.", true),
                    new (AmCenti, "It's quite simple really! I use microscopic nanomachines to deconstruct and reconstruct the ship in a few seconds."),
                    new (AmIsaac, "Nanomachines? I thought those didn't exist yet.", true),
                    new (AmCenti, "I just recently developed them myself. They are still in the prototype phase, not to be released to the public."),
                    new (AmCenti, "They can be quite dangerous in the wrong hands!"),
                    new (AmIsaac, "panic","They can?!", true)
                ]
            }},
            {"Centi_Riggs_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCenti, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Centi_Intro_0", "Centi_Memory_1"],
                dialogue = [
                    new (AmRiggs, "What were you working on with your sister?", true),
                    new (AmCenti, "It was a prototype lightspeed engine. Small enough to fit on a single-person craft."),
                    new (AmRiggs, "Whoa! That's so cool! Why did you stop?", true),
                    new (AmCenti, "nervous", "It... uh... didn't work."),
                    new (AmRiggs, "Awww, that sucks. I would have loved to pilot a ship with it.", true)
                ]
            }},
            {"Centi_Drake_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                bg = "BGRunStart",
                allPresent = [ AmCenti, AmDrake ],
                requiredScenes = [ "Centi_Post_Smiff", "Centi_Memory_2"],
                dialogue = [
                    new (AmDrake, "squint","What kinda beef you got with Smiff?", true),
                    new (AmCenti, "angry", "He is the reason my sister is dead."),
                    new (AmDrake, "squint","Really? THAT guy? He's harmless. How would he even do that?", true),
                    new (AmCenti, "angry", "He sold her a faulty part that ended up causing a critical failure in an engine, causing an explosion that killed her."),
                    new (AmDrake, "nervous", "Oh.", true)
                ]
            }},
            {"Centi_Luna_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmCenti, AmLuna ],
                bg = "BGRunStart",
                requiredScenes = [ "Centi_Intro_0", "Luna_Intro_0_PREEMPTIVE"],
                dialogue = [
                    new (AmCenti, "Luna! I've been meaning to ask where you get your supply of Stardust. It's quite a useful material to have."),
                    new (AmLuna, "Stardust is everywhere! You just gotta know how to tap into it!", true),
                    new (AmCenti, "squint", "What, like, it binds all living beings together?"),
                    new (AmLuna, "squint","What? No, that's silly.", true),
                    new (AmLuna, "It really is just everywhere, it's just often too small to see or use. You just need to have the right magic to get it in large enough clumps.", true),
                    new (AmCenti,  "You don't suppose I could get in on that? I would love to have a material like that."),
                    new (AmLuna, "Sorry! It takes years of practice to get it right. I'm barely proficient enough with it as is.", true)
                ]
            }},
        });
    }
}