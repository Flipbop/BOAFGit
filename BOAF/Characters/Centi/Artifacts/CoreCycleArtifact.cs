using System;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Flipbop.BOAF;

internal sealed class CoreCycleArtifact : Artifact, IRegisterable
{
	public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
	{
		helper.Content.Artifacts.RegisterArtifact("CoreCycle", new()
		{
			ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
			Meta = new()
			{
				owner = ModEntry.Instance.CentiDeck.Deck,
				pools = ModEntry.GetArtifactPools(MethodBase.GetCurrentMethod()!.DeclaringType!)
			},
			Sprite = helper.Content.Sprites.RegisterSprite(ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Centi/Artifacts/CoreCycle.png")).Sprite,
			Name = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "CoreCycle", "name"]).Localize,
			Description = ModEntry.Instance.AnyLocalizations.Bind(["Centi","artifact", "CoreCycle", "description"]).Localize
		});
	}

	public override void OnCombatStart(State state, Combat combat)
	{
		var rand = new Rand(state.rngCurrentEvent.seed);

		List<int> source = new List<int>();
		for (int key = state.ship.x - 1; key < state.ship.x + state.ship.parts.Count<Part>() + 1; ++key)
		{
			if (!combat.stuff.ContainsKey(key))
				source.Add(key);
		}
		List<int> list = source.Shuffle<int>(state.rngActions).Take<int>(2).ToList<int>();
		foreach (int num in list)
		{
			Dictionary<int, StuffBase> stuff = combat.stuff;
			int key = num;
			
			var potentialCore = new WeightedRandom<Asteroid>();
			potentialCore.Add(new(25,new DemonCore()));
			potentialCore.Add(new(25,new AquaCore()));
			potentialCore.Add(new(25,new StoneCore()));
			potentialCore.Add(new(8,new LavaCore()));
			potentialCore.Add(new(8,new MossCore()));
			potentialCore.Add(new(8,new BrimstoneCore()));
			potentialCore.Add(new(1,new InfinityCore()));
			
			var core = potentialCore.Next(rand);
			core.targetPlayer = false;
			core.x = num;
			core.xLerped = (double) num;
			stuff.Add(key, (StuffBase) core);
		}
		if (list.Count <= 0)
			return;
		this.Pulse();
	}
	
}

internal record struct WeightedItem<T>(
	double Weight,
	T Item
);

internal sealed class WeightedRandom<T>
{
	public IReadOnlyList<WeightedItem<T>> Items
		=> ItemStorage;

	public double WeightSum { get; private set; }

	private readonly List<WeightedItem<T>> ItemStorage = [];

	public WeightedRandom()
	{
	}

	public WeightedRandom(IEnumerable<WeightedItem<T>> items)
	{
		this.ItemStorage = items.ToList();
		this.WeightSum = this.ItemStorage.Sum(item => item.Weight);
	}

	public void Add(WeightedItem<T> item)
	{
		if (item.Weight <= 0)
			return;
		ItemStorage.Add(item);
		WeightSum += item.Weight;
	}

	public T Next(Rand random, bool consume = false)
	{
		switch (this.ItemStorage.Count)
		{
			case 0:
				throw new IndexOutOfRangeException("Cannot choose a random element, as the list is empty.");
			case 1:
			{
				var result = this.ItemStorage[0].Item;
				if (consume)
				{
					this.WeightSum = 0;
					this.ItemStorage.RemoveAt(0);
				}
				return result;
			}
		}

		var weightedRandom = random.Next() * WeightSum;
		for (var i = 0; i < ItemStorage.Count; i++)
		{
			var item = ItemStorage[i];
			weightedRandom -= item.Weight;

			if (weightedRandom <= 0)
			{
				if (consume)
				{
					WeightSum -= ItemStorage[i].Weight;
					ItemStorage.RemoveAt(i);
				}
				return item.Item;
			}
		}
		throw new InvalidOperationException("Invalid state.");
	}

	public IEnumerable<T> GetConsumingEnumerable(Rand random)
	{
		int count;
		while ((count = ItemStorage.Count) != 0)
		{
			if (count == 1)
			{
				var item = ItemStorage[0];
				WeightSum = 0;
				ItemStorage.RemoveAt(0);
				yield return item.Item;
				yield break;
			}
			
			var weightedRandom = random.Next() * this.WeightSum;
			for (var i = 0; i < this.ItemStorage.Count; i++)
			{
				var item = this.ItemStorage[i];
				weightedRandom -= item.Weight;

				if (weightedRandom <= 0)
				{
					this.WeightSum -= this.ItemStorage[i].Weight;
					this.ItemStorage.RemoveAt(i);
					yield return item.Item;
					break;
				}
			}
		}
	}
}

internal static class WeightedRandomClassExt
{
	public static T? NextOrNull<T>(this WeightedRandom<T> weightedRandom, Rand random, bool consume = false)
		where T : class
	{
		if (weightedRandom.Items.Count == 0)
			return null;
		return weightedRandom.Next(random, consume);
	}
}

internal static class WeightedRandomStructExt
{
	public static T? NextOrNull<T>(this WeightedRandom<T> weightedRandom, Rand random, bool consume = false)
		where T : struct
	{
		if (weightedRandom.Items.Count == 0)
			return null;
		return weightedRandom.Next(random, consume);
	}
}
