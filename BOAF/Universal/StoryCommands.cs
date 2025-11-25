using System;
using System.Collections.Generic;
using System.Linq;

namespace Flipbop.BOAF;
    
    public static class StoryCommands {

        /*private static void PopulateFinaleRun(
            G g,
            HashSet<Deck> chars, 
            StarterShip shipTemplate,
            MapBase newMap,
            int difficulty,
            List<Card>? additionalCards = null,
            List<Artifact>? additionalArtifs = null,
            uint? seed = null) {
            StarterShip shipTemplate2 = shipTemplate;
            MapBase newMap2 = newMap;
            g.state.ChangeRoute(delegate {
                IEnumerable<Deck> chars2 = chars;
                g.state.SeedRand((uint)(((int?)seed) ?? Mutil.NextRandInt()));
                g.state.storyVars.ResetAfterRun();
                g.state.artifacts.Clear();
                g.state.ship = Mutil.DeepCopy(shipTemplate2.ship);
                if (difficulty >= 1) {
                    g.state.SendArtifactToChar(new HARDMODE {
                        difficulty = difficulty
                    });
                }
                g.state.deck.Clear();

                foreach (Artifact item in shipTemplate2.artifacts.Select((Artifact r) => Mutil.DeepCopy(r))) {
                    g.state.SendArtifactToChar(item);
                }

                
                foreach (Card item2 in shipTemplate2.cards.Select((Card card) => Mutil.DeepCopy(card))) {
                    g.state.SendCardToDeck(item2);
                } 

                g.state.characters = (from ch in chars2
                              orderby ch
                              select ch into deck
                              select new Character {
                                  type = ((deck == Deck.colorless) ? "comp" : deck.Key()),
                                  deckType = deck
                              }).ToList();
                g.state.bigStats.RecordRunStart(g.state);

                
                foreach (Deck item3 in chars2) {
                    if (StarterDeck.starterSets.TryGetValue(item3, out var value)) {
                        foreach (Card item4 in value.cards.Select((Card c) => c.CopyWithNewId())) {
                            g.state.SendCardToDeck(item4);
                        }
                        /* 
                        foreach (Artifact item5 in value.artifacts.Select((Artifact r) => Mutil.DeepCopy(r))) {
                            SendArtifactToChar(item5);
                        } 
                    }
                }

                if (additionalCards != null) {
                    foreach (Card addCard in additionalCards)
                        g.state.SendCardToDeck(addCard);
                }
                if (difficulty >= 2) {
                    g.state.SendCardToDeck(new CorruptedCore());
                }
                if (additionalArtifs != null) {
                    foreach (Artifact addArtif in additionalArtifs)
                        g.state.SendArtifactToChar(addArtif);
                }

                State state = g.state;

                state.GoToZone(newMap);
                state.ShuffleDeck();

                g.state.hideCardTooltips = false;
                return g.state.MakeZoneIntroDialogue();
            });
        }

        public static bool UnlockFinaleMem(G g) {
            if (g.state.characters.Any((Character ch) => ch.deckType == ManifHelper.GetDeck("ilya")) &&
                g.state.storyVars.memoryUnlockLevel.GetValueOrDefault(ManifHelper.GetDeck("jost")) < 2) {
                g.state.storyVars.UnlockOneMemory(ManifHelper.GetDeck("jost"));
            } else if (g.state.characters.Any((Character ch) => ch.deckType == ManifHelper.GetDeck("gauss")) &&
                g.state.storyVars.memoryUnlockLevel.GetValueOrDefault(ManifHelper.GetDeck("jost")) < 3) {
                g.state.storyVars.UnlockOneMemory(ManifHelper.GetDeck("jost"));
            } else if (g.state.characters.Any((Character ch) => ch.deckType == ManifHelper.GetDeck("isa")) &&
                g.state.storyVars.memoryUnlockLevel.GetValueOrDefault(ManifHelper.GetDeck("sorrel")) < 1) {
                g.state.storyVars.UnlockOneMemory(ManifHelper.GetDeck("sorrel"));
            } else if (g.state.characters.Any((Character ch) => ch.deckType == ManifHelper.GetDeck("jost")) &&
                g.state.storyVars.memoryUnlockLevel.GetValueOrDefault(ManifHelper.GetDeck("sorrel")) < 2) {
                g.state.storyVars.UnlockOneMemory(ManifHelper.GetDeck("sorrel"));
            } else if (g.state.characters.Any((Character ch) => ch.deckType == ManifHelper.GetDeck("nola")) &&
                g.state.storyVars.memoryUnlockLevel.GetValueOrDefault(ManifHelper.GetDeck("sorrel")) < 3) {
                g.state.storyVars.UnlockOneMemory(ManifHelper.GetDeck("sorrel"));
            }
            return true;
        }*/
    }
    
    public class MemoryFight : Instruction
    {
        public required List<Card> cards;
        public List<Artifact> artifacts = null!;
        public required List<Deck> decks;
        public required AI enemy;
        public required StarterShip ship;
        public List<Artifact> removeArtifacts = null!;
        public int hullIncrease = 0;

        public override bool Execute(G g, IScriptTarget target, ScriptCtx ctx)
        {
            g.state.PopulateRun(ship, new MemoryMap(true) {nodes = new []
                {
                    mapTuple(0, 0, null, new MapBattle() { battleType = BattleType.Boss, ai = enemy }),
                },   
                currentLocation = new Vec(0, 0),}, decks, difficulty: 1);
            g.state.deck.Clear();
            foreach (Card card in cards) g.state.deck.Add(card);
            foreach (Artifact artifact in ship.artifacts.ToList())
            {
                foreach (Artifact artifactRemove in removeArtifacts)
                {
                    if  (artifact.Equals(artifactRemove)) ship.artifacts.Remove(artifactRemove);
                }
            }
            if (artifacts != null) {
                foreach (Artifact addArtif in artifacts)
                    g.state.SendArtifactToChar(addArtif);
            }
            g.state.ship.hullMax += hullIncrease;
            g.state.ship.hull += hullIncrease;
            return true;
        }
        
        private static Tuple<Vec, Marker> mapTuple(int x, int y, int? pathY, MapNodeContents content) {
            HashSet<int> paths = new HashSet<int>();
            if (pathY.HasValue)
                paths.Add(pathY.Value);
            return new Tuple<Vec, Marker>(
                new Vec(x, y), new Marker() {
                    paths = paths,
                    contents = content,
                }
            );
        }
    }

    public class EndMemoryFight : Instruction
    {
        public override bool Execute(G g, IScriptTarget target, ScriptCtx ctx)
        {
            g.state.rewardsQueue.Clear();
            g.state.TryCloseRoute(g, g.state.route, null);
            g.state.RemoveAllTempCards();
            g.state.ChangeRoute(() => g.state.MakeRunWinRoute());
            return true;
        }
    }

    public class SetMemoryLevel : Instruction
    {
        public required Deck chararcter;
        public required int level;

        public override bool Execute(G g, IScriptTarget target, ScriptCtx ctx)
        {
            g.state.storyVars.memoryUnlockLevel[chararcter] = level;
            return true;
        }
    }

    public class CheckMemoryLevel : Instruction
    {
        public required Deck chararcter;
        public required int level;

        public override bool Execute(G g, IScriptTarget target, ScriptCtx ctx)
        {
            if (g.state.storyVars.memoryUnlockLevel[chararcter] != level)
            {
                g.state.storyVars.memoryUnlockLevel[chararcter] = level;
                g.state.ChangeRoute(g.state.MakeRunWinRoute);
            }
            return true;
        }
    }
