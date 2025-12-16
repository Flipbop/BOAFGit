using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Reflection;
using System;


namespace Flipbop.BOAF;

internal sealed class CometShowCard : Card, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Cards.RegisterCard(MethodBase.GetCurrentMethod()!.DeclaringType!.Name, new()
		{
			CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				deck = ModEntry.Instance.LunaDeck.Deck,
				rarity = ModEntry.GetCardRarity(MethodBase.GetCurrentMethod()!.DeclaringType!),
				upgradesTo = [Upgrade.A, Upgrade.B]
			},
			Art = StableSpr.cards_colorless,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Luna","card", "CometShow", "name"]).Localize
		});
	}

	public override CardData GetData(State state)
		=> new()
		{
			artTint = "FFFFFF",
			cost = upgrade == Upgrade.B ? 3 : 2,
		};

	public override List<CardAction> GetActions(State s, Combat c)
		=> upgrade switch
		{
			Upgrade.A => [
				new ASpawn(){thing = new Asteroid(), offset = -2},
				new ASpawn(){thing = new Comet(), offset = -1},
				new ASpawn(){thing = new Comet()},
				new ASpawn(){thing = new Comet(), offset = 1},
				new ASpawn(){thing = new Asteroid(), offset = -2},
			],
			Upgrade.B => [
				new ASpawn(){thing = new Comet() {bubbleShield = true}, offset = -1},
				new ASpawn(){thing = new Comet() {bubbleShield = true}},
				new ASpawn(){thing = new Comet() {bubbleShield = true}, offset = 1},
			],
			_=>[
				new ASpawn(){thing = new Comet(), offset = -1},
				new ASpawn(){thing = new Comet()},
				new ASpawn(){thing = new Comet(), offset = 1},
			]
		};
	
	/*private sealed class ASelectiveSensors : CardAction
	{
		public override Route? BeginWithRoute(G g, State s, Combat c)
			=> new ActionRoute();
	}

	private sealed class ActionRoute : Route
	{
		public override bool GetShowOverworldPanels()
			=> true;

		public override bool CanBePeeked()
			=> false;

		public override void Render(G g)
		{
			base.Render(g);

			if (g.state.route is not Combat combat)
			{
				g.CloseRoute(this);
				return;
			}

			Draw.Rect(0, 0, MG.inst.PIX_W, MG.inst.PIX_H, Colors.black.fadeAlpha(0.5));

			var keyPrefix = $"{typeof(ModEntry).Namespace!}::{nameof(SelectiveSensorsCard)}";
			for (var i = 0; i < combat.otherShip.parts.Count; i++)
			{
				var part = combat.otherShip.parts[i];
				if (part.intent is null)
					continue;

				if (g.boxes.FirstOrDefault(b => b.key is { } key && key.k == StableUK.part && key.v == i && key.str == "combat_ship_enemy") is not { } realBox)
					continue;

				g.Push(rect: new Rect(realBox.rect.x - i * 16 + 1, realBox.rect.y, realBox.rect.w, realBox.rect.h));

				combat.otherShip.RenderPartUI(g, combat, part, i, keyPrefix, isPreview: false);

				if (g.boxes.FirstOrDefault(b => b.key is { } key && key.k == StableUK.part && key.v == i && key.str == keyPrefix) is { } box)
				{
					var partIndex = i;
					box.onMouseDown = new MouseDownHandler(() => OnPartSelected(g, combat.otherShip, partIndex));
					if (box.IsHover())
					{
						if (!Input.gamepadIsActiveInput)
							MouseUtil.DrawGamepadCursor(box);
						part.hilight = true;
					}
				}

				g.Pop();
			}

			var centerX = g.state.ship.x + g.state.ship.parts.Count / 2.0;
			foreach (var (worldX, @object) in combat.stuff)
			{
				if (Math.Abs(worldX - centerX) > 10)
					continue;
				if (g.boxes.FirstOrDefault(b => b.key is { } key && key.k == StableUK.midrow && key.v == worldX) is not { } realBox)
					continue;
				if ((@object.GetActions(g.state, combat)?.Count ?? 0) == 0)
					continue;

				var box = g.Push(new UIKey(MidrowExecutionUK, worldX), realBox.rect, onMouseDown: new MouseDownHandler(() => OnMidrowSelected(g, @object)));
				@object.Render(g, box.rect.xy);
				if (box.rect.x is > 60.0 and < 464.0 && box.IsHover())
				{
					if (!Input.gamepadIsActiveInput)
						MouseUtil.DrawGamepadCursor(box);
					g.tooltips.Add(box.rect.xy + new Vec(16.0, 24.0), @object.GetTooltips());
					@object.hilight = 2;
				}
				g.Pop();
			}

			SharedArt.ButtonText(
				g,
				new Vec(MG.inst.PIX_W - 69, MG.inst.PIX_H - 31),
				CancelExecutionUK,
				ModEntry.Instance.Localizations.Localize(["card", "RemoteExecution", "ui", "cancel"]),
				onMouseDown: new MouseDownHandler(() => g.CloseRoute(this))
			);
		}

		private void OnPartSelected(G g, Ship ship, int partIndex)
		{
			if (g.state.route is not Combat combat)
			{
				g.CloseRoute(this);
				return;
			}

			var queue = new List<CardAction>(combat.cardActions);
			combat.cardActions.Clear();

			var part = ship.parts[partIndex];
			part.intent?.Apply(g.state, combat, ship, partIndex);
			part.intent = null;

			combat.cardActions.AddRange(queue);
			g.CloseRoute(this);
		}

		private void OnMidrowSelected(G g, StuffBase @object)
		{
			if (g.state.route is not Combat combat)
			{
				g.CloseRoute(this);
				return;
			}

			combat.QueueImmediate(@object.GetActions(g.state, combat));
			g.CloseRoute(this);
		}
	}*/

}
