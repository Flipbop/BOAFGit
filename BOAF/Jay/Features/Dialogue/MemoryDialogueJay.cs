using System.Collections.Generic;
using Flipbop.BOAF;
using Microsoft.Xna.Framework.Graphics;
using Nanoray.PluginManager;
using Nickel;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueJay 
{
    public MemoryDialogueJay()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            //Remove the _PREEMPTIVE from every tag when everything is finished
            {"RunWinWho_Jay_1_PREEMPTIVE", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmJay, "neutral", "Are you the reason I'm here?" ),
                    new (AmVoid,"neutral","In a way."),
                    new (AmJay, "neutral", "But why? According to Cat, almost everyone else is missing their memories." ),
                    new (AmVoid,"neutral","I need you to be whole again."),
                    new (AmVoid,"neutral","You may remember your past, but that does not mean you have not pushed it deep down."),
                    new (AmVoid,"neutral","I need you to remember her."),
                ]
            }},
            {"RunWinWho_Jay_2_PREEMPTIVE", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                requiredScenes = [
                    "RunWinWho_Jay_1_PREEMPTIVE"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmJay, "neutral", "Back here again. What for?" ),
                    new (AmVoid,"neutral","I am not sure. You know who you are searching for, yes?" ),
                    new (AmJay, "neutral", "The person Valv bought the part from, some \"bat dude\" as she put it." ),
                    new (AmVoid,"neutral","That is correct. As of now, there is nothing I can do for you here." )
                ]
            }},
            {"RunWinWho_Jay_3_PREEMPTIVE", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmJay],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmJay}"
                ],
                requiredScenes = [
                    "Jay_Post_Smiff_PREEMPTIVE"
                ],
                dialogue = [
                    new(new Wait{secs = 3}),
                    new (AmJay, "neutral", "Is that it? Am I \"whole\" now?" ),
                    new (AmVoid,"neutral","Almost. You are still grieving. I may not be able to help with that, but I know someone that can." ),
                    new (AmJay, "neutral", "Then what?" ),
                    new (AmVoid,"neutral","We will see." )
                ]
            }},
            {"Jay_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault",
                    $"vault_{AmJay}"
                ],
                dialogue = [
                    new("T+98 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 1 }),
                    new (AmValv, "neutral", "What's up, bro!" ),
                    new (AmJay,"neutral","Valv! It's been some time. Did you get the part I needed?" ),
                    new (AmValv, "neutral", "Yup! Bought it off of some bat dude. Drove a hard bargain, saying it was from some weird ship." ),
                    new (AmJay,"neutral","Excellent! With this, I think I'll be able to finish my prototype engine within the next week or so." ),
                    new (AmValv, "neutral", "We're gonna be so rich!" ),
                    new (AmJay,"squint","That's not the point." ),
                    new (AmValv, "angry", "Yeah, I know, revolutionizing space travel yada yada yada." ),
                    new (AmValv, "neutral", "The money is still a huge bonus." ),
                    new (AmJay,"neutral","Oh of course." ),
                ]
            }},
            {"Jay_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault", $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_1_PREEMPTIVE"],
                dialogue = [
                    new("T+94 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),
                    new (AmJay, "neutral", "Screw that plate in and then we should be finished." ),
                    new (AmValv,"neutral","Alright! I think that's done! Ready to test it?" ),
                    new (AmJay, "neutral", "Of course." ),
                    new(new Wait{secs = 2}),
                    new (AmJay, "neutral", "Engine is stable. Temperatures are normal." ),
                    new (AmValv,"neutral","That's good, right? That sounds good." ),
                    new (AmJay, "neutral", "It's very good. If this holds, then it's finally finished!" ),
                    new(new Wait{secs = 1}),
                    new (AmJay, "nervous", "Uh oh. The part you bought seems unable to hold!" ),
                    new (AmValv,"angry","We were so close!" ),
                    new (AmJay, "nervous", "Shutting down power!" ),
                    new(new Wait{secs = 1}),
                    new (AmValv,"nervous","What's wrong? Why isn't it stopping?!" ),
                    new (AmJay, "nervous", "It's not letting me!" ),
                    new (AmJay, "nervous", "GET DOWN!" ),
                    new(new Wait{secs = 5}),
                    new (AmJay, "damaged", "Valv! Wake up! VALV!" ),
                    new (AmValv,"dead","..." ),
                    new (AmJay, "damaged", "Don't do this to me! C'mon, wake up!" ),
                    new (AmValv,"dead","..." ),
                    new (AmJay, "damaged", "No! No..." ),

                ]
            }},
            {"Jay_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGRunWin",
                lookup = [
                    "vault", $"vault_{AmJay}"
                ],
                requiredScenes = ["Jay_Memory_2_PREEMPTIVE"],
                dialogue = [
                    new (AmCull, "neutral", "Sorry, I'm not gonna reveal any lore for my mod until EVERYTHING is finished!" ),
                    new (AmCull,"neutral","You are just gonna have to wait until then!" )
                ]
            }}
        });
    }
}