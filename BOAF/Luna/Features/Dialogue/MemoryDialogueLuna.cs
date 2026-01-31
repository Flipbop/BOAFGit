using System.Collections.Generic;
using static Flipbop.BOAF.CommonDefinitions;

namespace Flipbop.BOAF;

internal class MemoryDialogueLuna 
{
    public MemoryDialogueLuna()
    {
        LocalDB.DumpStoryToLocalLocale("en", new Dictionary<string, DialogueMachine>()
        {
            {"RunWinWho_Luna_1", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmLuna],
                bg = "BGRunWin",
                lookup = [
                    $"runWin_{AmLuna}"
                ],
                dialogue = [
                    
                ]
            }},
            {"RunWinWho_Luna_2", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmLuna],
                bg = "BGRunWinCustom",
                lookup = [
                    $"runWin_{AmLuna}"
                ],
                requiredScenes = [
                    "RunWinWho_Luna_1"
                ],
                dialogue = [
                    
                ]
            }},
            {"RunWinWho_Luna_3", new(){
                type = NodeType.@event,
                introDelay = false,
                allPresent = [AmLuna],
                bg = "BGRunWin",
                priority = true,
                lookup = [
                    $"runWin_{AmLuna}"
                ],
                requiredScenes = [
                    "Luna_Post_Smiff", "Luna_Memory_2"
                ],
                dialogue = [
                    
                ]
            }},
            {"Luna_Memory_1", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBlack",
                lookup = [
                    "vault",
                    $"vault_{AmLuna}"
                ],
                dialogue = [
                    new("T-972 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),
                    new (AmLuna, "Close your eyes, I have something to show you."),
                    new (AmKass, "squint", "Okay, but it better not be another frog.", true),
                    new (AmLuna, "It's not! Just stick out your paws and I'll give it to you."),
                    new (AmKass, "closed", "Alright.", true),
                    new (AmKass, "closed", "What's this? A piece of paper?", true),
                    new (AmKass, "squint", "\"We are happy to inform you that you have been accepted to Iridescent Academy.\"", true),
                    new (AmKass, "smile", "What?! That's incredible! This was always your dream!", true),
                    new (AmLuna, "Yup! I'm gonna become a real stardust mage!"),
                    new (AmKass, "When do you leave?", true),
                    new (AmLuna, "In a month."),
                    new (AmLuna, "sad", "I'll miss you. I'll visit as often as I can."),
                    new (AmKass, "Awww, that's sweet.", true),
                    new (AmLuna,"squint", "Are you sure you'll be able to protect the village with me gone?"),
                    new (AmKass, "Luna, we haven't been raided by pirates ever since we started protecting the village together. We'll be fine.", true),
                    new (AmLuna, "sad", "I know but I just worry something is gonna happen without me here to help."),
                    new (AmKass, "Nothing is gonna happen!", true),
                    new (AmKass, "Go learn how to be a stardust mage. The village will be here when you get back. I'll be here when you get back.", true),
                    new (AmLuna, "Okay, love you."),
                    new (AmKass, "smile","Love you too.", true),

                ]
            }},
            {"Luna_Memory_2", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGLunaAcademy",
                lookup = [
                    "vault", $"vault_{AmLuna}"
                ],
                requiredScenes = ["Luna_Memory_1"],
                dialogue = [
                    new("T-433 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),
                    new(new Wait{secs = 2}),
                    new (new BGAction(){action = "academy"}),
                    new (AmDillian, "Hey Luna, you are from the Outer Rim, right? You lived in a small village in the countryside?", true),
                    new (AmLuna, "squint", "Yeah, why ask?"),
                    new (AmDillian, "squint", "Your home planet is under siege from a group of pirates...", true),
                    new (AmLuna, "nervous", "Oh no, Kass is all alone without me!"),
                    new (AmDillian, "Your girlfriend? How fast do you think you could make it back?", true),
                    new (AmLuna, "nervous", "A day at the earliest. I should go now."),
                    new (AmDillian, "You should.", true),
                    new("T-432 days"),
                    new(new Wait{secs = 2}),
                    new(title: null),                    
                    new (new BGAction(){action = "fire"}),
                    new(new Wait{secs = 2}),
                    new (AmLuna, "nervous", "Oh no..."),
                    new(new Wait{secs = 2}),
                    new (AmLuna, "tear", "Please please please please please"),
                    new (AmKass, "dying", "*cough cough* i-is that you, Luna?", true),
                    new (AmLuna, "tear", "Yes, it's alright, I'm here! I'm here."),
                    new (AmKass, "dying", "I-I don't think I'm gonna make it.", true),
                    new (AmLuna, "tear", "Don't talk like that! You'll be fine!"),
                    new (AmKass, "dying", "It's ok, Luna. You'll be ok.", true),
                    new (AmLuna, "tear", "Please don't..."),
                    new (AmKass, "dying", "Luna, I love you.", true),
                    new (AmLuna, "tear", "I love you too..."),
                    new (AmKass, "dead", "...", true),
                    new (AmLuna, "tear", "Nononononono..."),
                    new (AmLuna, "tear", "Wake up... please..."),
                    new (AmKass, "dead", "...", true),
                    new (AmLuna, "sob", "..."),
                    new (AmLuna, "tear", "This can't be real..."),
                    new (AmLuna, "sob", "If I didn't leave this wouldn't have happened..."),
                    new (AmLuna, "sob", "..."),
                    new (AmLuna, "sob", "I could have saved her if I was here."),
                ]
            }},
            {"Luna_Memory_3", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "vault", $"vault_{AmLuna}"
                ],
                requiredScenes = ["Luna_Memory_2"],
                dialogue = [
                    new(new Wait{secs = 2}),
                    new (AmLuna, "gameover", "..."),
                    new (AmCull, "Wake up.", true),
                    new (AmLuna, "squint", "Five more minutes..."),
                    new (AmCull, "It's just you and me right now. We have a goal to complete.", true),
                    new (AmLuna, "squint", "Different from the usual one?"),
                    new (AmCull, "Quite. We are gonna deal with your grief today.", true),
                    new (AmLuna, "squint", "Huh? How so?"),
                    new (AmCull, "I can resurrect those that have passed, even if only temporarily.", true),
                    new (AmCull, "This can help you make peace.", true),
                    new (AmLuna, "I get to see Kass again?! What do I have to do?!"),
                    new (AmCull, "nervous","You might not like it...", true),
                    new (AmLuna, "angry","Tell me."),
                    new (AmCull, "We have to fight the literal personification of your grief.", true),
                    new (AmLuna, "squint", "That sounds hard."),
                    new (AmCull, "It very well could be. I need you to be absolutely ready.", true),
                    new (AmLuna, "gameover","..."),
                    new (AmLuna, "angry","Bring it on."),
                    new (new MemoryFight()
                    {
                        cards = new List<Card>
                        {
                            new BasicShotDualCard(),
                            new BasicDodgeDualCard(),
                            new BasicShieldDualCard(),
                            new HarvestCard() {upgrade = Upgrade.A},
                            new QuickCastCard(),
                            new InfiniteShineCard() {upgrade = Upgrade.B},
                            new ShinyShotCard(),
                            new BulletWardCard() {upgrade = Upgrade.A},
                            new PiercingLightCard(),
                            new BoonCard() {upgrade = Upgrade.A}
                        }, 
                        artifacts = new List<Artifact>
                        {
                            new SolarPendantArtifact(),
                            new BackupCrystalArtifact(),
                            new SpellShaperArtifact(),
                            new WarpMastery(),
                            new Crosslink()
                        },
                        decks = new List<Deck>
                        {
                            ModEntry.Instance.CullDeck.Deck,
                            ModEntry.Instance.LunaDeck.Deck,
                        },
                        enemy = new DepressionEnemy(),
                        ship = ModEntry.Instance.AthenaShip.Configuration.Ship,
                        removeArtifacts = [new ShieldPrep()],
                        hullIncrease = 10,
                    }),
                ]
            }},
            {"Depression_Power_Up", new(){
                type = NodeType.@event,
                allPresent = [AmLuna, AmCull],
                nonePresent = [AmJay, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmLuna, "nervous", "How are we supposed to kill it now?!" ),
                    new (AmCull,"angry","Just survive! Those perfect shields can't last forever!" ),
                ]
            }},
            {"Depression_Callout_Multi_0", new(){
                type = NodeType.combat,
                allPresent = [AmLuna, AmCull, AmVoid],
                nonePresent = [AmJay, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "1 C0UL??D H4\\/E <c=part>SAVED HER</c>." ),
                ]
            }},
            {"Depression_Callout_Multi_1", new(){
                type = NodeType.combat,
                allPresent = [AmLuna, AmCull, AmVoid],
                nonePresent = [AmJay, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "1'??L VI5IT 4S <c=part>OFTEN AS I CAN.</c>" ),
                ]
            }},
            {"Depression_Callout_Multi_2", new(){
                type = NodeType.combat,
                allPresent = [AmLuna, AmCull, AmVoid],
                nonePresent = [AmJay, /*AmCenti, AmEva*/],
                dialogue = [
                    new (AmVoid, "<c=part>  </c>" ),
                ]
            }},
            {"Luna_Closure", new(){
                type = NodeType.@event,
                introDelay = false,
                bg = "BGBattleMemory",
                lookup = [
                    "after_void"
                ],
                allPresent = [AmLuna, AmCull, AmVoid],
                nonePresent = [AmJay, /*AmCenti, AmEva*/],
                requiredScenes = ["Luna_Memory_3"],
                dialogue = [
                    
                ]
            }},
        });
    }
}