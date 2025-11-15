using System.Reflection;
using HarmonyLib;
using Nickel;


namespace Flipbop.BOAF;

public class Backgrounds
{
    public class BGJayWorkshop : BG {
        private static bool explosion = false;
        private static  bool alarm = false;
        private static bool sadness = false;

        public BGJayWorkshop()
        {
            ApplyPatches();
        }
        
        public override void OnAction(State s, string action) {
            if (action == "explosion")
            {
                explosion = true;
                alarm = false;
            }
            if (action == "alarm") alarm = true;
            if (action == "sadness")
            {
                explosion = false;
                sadness = true;
            }
        }

        public override void Render(G g, double t, Vec offset) {
            Draw.Sprite(ModEntry.Instance.BGJayWorkshopSprite.Sprite, 0, 0);
            //Glow.Draw(new Vec(240, 0), 1000, new Color(1, 0, 1).gain(0.3));
            BGComponents.Letterbox();

            if (explosion) Audio.Auto(FSPRO.Event.Hits_ShipExplosion);
            if (alarm) Audio.Auto(FSPRO.Event.Scenes_CoreAlarm);

        }
        private void ApplyPatches() {
            ModEntry.Instance.Harmony.Patch(
                original: AccessTools.DeclaredMethod(typeof(Route), nameof(Route.GetMusic)),
                postfix: new HarmonyMethod(MethodBase.GetCurrentMethod()!.DeclaringType!, nameof(Music_Override))
        );}
        
        public static void Music_Override(ref MusicState? __result) {
            if (sadness) __result = new MusicState { scene = Song.Riggs };
            if (explosion) __result = new MusicState { scene = Song.Silence };
            if (alarm) __result = new MusicState { scene = Song.Silence };
            __result = new MusicState { scene = Song.Riggs };
        }
    }
}