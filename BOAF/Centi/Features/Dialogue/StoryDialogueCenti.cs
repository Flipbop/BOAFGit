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
            
            {"Jay_Intro_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmJay ],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "Alright everyone, let's get going!", flipped: true),
                    new(AmJay, "squint", "This doesn't look familiar. What's going on?"),
                    new(AmCat, "Oh, you are new here. Hello! We're trapped in a time loop!", flipped: true),
                    new(AmJay, "nervous", "A what?!"),
                    new(AmCat, "A time loop! You don't happen to have your memories do you?", flipped: true),
                    new(AmJay, "squint", "I do, but I don't see how that is relevant."),
                    new(AmCat, "squint", "Oh. That's interesting.", flipped: true),
                ]
            }},
            {"Jay_Post_Cicada", new(){
                type = NodeType.@event,
                lookup = [ "after_any" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_0"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "squint","Just how much do you remember? No gaps in your memory?", flipped: true),
                    new(AmJay, "No, I remember everything just fine."),
                    new(AmCat, "squint","Strange. Usually people that show up on this ship are missing key memories.", flipped: true),
                    new(AmCat, "squint","But not you. There must be some reason you are here now.", flipped: true),
                    new(AmJay, "squint", "I can still be of use."),
                ]
            }},
            {"Jay_Intro_1", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_0", "Jay_Memory_1"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "squint", "Judging by the fact that space travel has not been revolutionized recently, it didn't work out?", flipped: true ),
                    new (AmJay,"nervous","You could say that." ),
                    new (AmCat, "neutral", "That \"bat dude\" she mentioned, I think I know who that is.", flipped: true ),
                    new (AmJay,"neutral","Really? I need to talk to him!" ),
                    new (AmCat, "neutral", "No guarantee we see him, but we can try!", flipped: true ),
                ]
            }},
            {"Jay_Pre_Smiff", new(){
                type = NodeType.@event,
                lookup = [ "before_batboy" ],
                once = true,
                priority = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_1", "Jay_Memory_1"],
                dialogue = [
                    new (AmJay, "squint", "Did you ever sell a piece of a weird ship to some bird girl?" ),
                    new (AmSmiff,"neutral","Yeah, why?", flipped: true),
                    new (AmJay, "angry", "The part was faulty." ),
                    new (AmSmiff,"neutral","Not my problem, that was months ago.", flipped: true ),
                    new (AmJay, "angry", "I'm about to make it your problem." ),
                ]
            }},
            {"Jay_Post_Smiff", new(){
                type = NodeType.@event,
                lookup = [ "after_batboy" ],
                once = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Pre_Smiff"],
                dialogue = [
                    new (AmCat, "worried","Are you ok?", flipped: true),
                    new(AmJay, "As much as I can be."),
                    new(AmCat, "worried","What was that about, anyways?", flipped: true),
                    new(AmJay, "gameover","..."),
                    new(AmJay, "sad", "I'll tell you after the loop."),
                    new (new SetMemoryLevel(){chararcter = ModEntry.Instance.JayDeck.Deck, level = 2})
                ]
            }},
            {"Jay_Intro_2", new(){
                type = NodeType.@event,
                lookup = [ "zone_first" ],
                once = true,
                priority = true,
                allPresent = [ AmJay ],
                requiredScenes = ["Jay_Intro_1", "Jay_Memory_2"],
                bg = "BGRunStart",
                dialogue = [
                    new (AmCat, "worried", "Oh, I'm so sorry. That can't have been easy to go through.", flipped: true ),
                    new (AmJay,"sad","It's... alright." ),
                    new (AmJay,"sob","There is nothing you could say that I haven't already told myself." ),
                    new (AmCat, "worried", "Don't talk like that! We're all here for you, you are our friend.", flipped: true ),
                    new (AmJay,"tear","Thanks. It means a lot." ),
                ]
            }},
            {"Jay_Dizzy_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmJay, AmDizzy ],
                bg = "BGRunStart",
                requiredScenes = [ "Jay_Intro_0", "Jay_Memory_3" ],
                dialogue = [
                    new (AmDizzy, "Do you remember what kind of part your sister bought off Smiff?", true),
                    new (AmJay, "squint", "Yeah, it was some sort of crystal like thing. I don't remember exactly. It was destroyed in the blast."),
                    new (AmDizzy, "crystal", "Like this?", true), 
                    new (AmJay, "nervous", "Where did you get that?!"),
                    new (AmDizzy, "crystal", "These things are everywhere. They last between each loop, so everytime we turn the big crystal to dust some more get scattered about.", true),
                    new (AmDizzy, "crystal", "They have some weird time-warping properties, if my tests are to be believed.", true), 
                    new (AmJay, "squint", "I guess that would make for some fast engines..."),
                ]
            }},
            {"Jay_Isaac_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                bg = "BGRunStart",
                allPresent = [AmJay, AmIsaac],
                once = true,
                requiredScenes = ["Jay_Intro_0", "Goat_1"],
                dialogue = [
                    new (AmIsaac, "Hey Jay, I was wondering what you are doing to manipulate the ships we pilot.", true),
                    new (AmJay, "It's quite simple really! I use microscopic nanomachines to deconstruct and reconstruct the ship in a few seconds."),
                    new (AmIsaac, "Nanomachines? I thought those didn't exist yet.", true),
                    new (AmJay, "I just recently developed them myself. They are still in the prototype phase, not to be released to the public."),
                    new (AmJay, "They can be quite dangerous in the wrong hands!"),
                    new (AmIsaac, "panic","They can?!", true)
                ]
            }},
            {"Jay_Riggs_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmJay, AmRiggs ],
                bg = "BGRunStart",
                requiredScenes = [ "Jay_Intro_0", "Jay_Memory_1"],
                dialogue = [
                    new (AmRiggs, "What were you working on with your sister?", true),
                    new (AmJay, "It was a prototype lightspeed engine. Small enough to fit on a single-person craft."),
                    new (AmRiggs, "Whoa! That's so cool! Why did you stop?", true),
                    new (AmJay, "nervous", "It... uh... didn't work."),
                    new (AmRiggs, "Awww, that sucks. I would have loved to pilot a ship with it.", true)
                ]
            }},
            {"Jay_Drake_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                bg = "BGRunStart",
                allPresent = [ AmJay, AmDrake ],
                requiredScenes = [ "Jay_Post_Smiff", "Jay_Memory_2"],
                dialogue = [
                    new (AmDrake, "squint","What kinda beef you got with Smiff?", true),
                    new (AmJay, "angry", "He is the reason my sister is dead."),
                    new (AmDrake, "squint","Really? THAT guy? He's harmless. How would he even do that?", true),
                    new (AmJay, "angry", "He sold her a faulty part that ended up causing a critical failure in an engine, causing an explosion that killed her."),
                    new (AmDrake, "nervous", "Oh.", true)
                ]
            }},
            {"Jay_Luna_0", new(){
                type = NodeType.@event,
                lookup = [ "zone_first"],
                once = true,
                allPresent = [ AmJay, AmLuna ],
                bg = "BGRunStart",
                requiredScenes = [ "Jay_Intro_0", "Luna_Intro_0_PREEMPTIVE"],
                dialogue = [
                    new (AmJay, "Luna! I've been meaning to ask where you get your supply of Stardust. It's quite a useful material to have."),
                    new (AmLuna, "Stardust is everywhere! You just gotta know how to tap into it!", true),
                    new (AmJay, "squint", "What, like, it binds all living beings together?"),
                    new (AmLuna, "squint","What? No, that's silly.", true),
                    new (AmLuna, "It really is just everywhere, it's just often too small to see or use. You just need to have the right magic to get it in large enough clumps.", true),
                    new (AmJay,  "You don't suppose I could get in on that? I would love to have a material like that."),
                    new (AmLuna, "Sorry! It takes years of practice to get it right. I'm barely proficient enough with it as is.", true)
                ]
            }},
        });
    }
}