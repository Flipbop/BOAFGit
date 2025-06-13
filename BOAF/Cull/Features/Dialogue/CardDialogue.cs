using Nickel;
using System.Collections.Generic;

namespace Flipbop.BOAF;

internal sealed class CardDialogue : BaseDialogue
{
	public CardDialogue() : base(locale => ModEntry.Instance.Package.PackageRoot.GetRelativeFile($"i18n/dialogue-card-{locale}.json").OpenRead())
	{
		var cullDeck = ModEntry.Instance.CullDeck.Deck;
		var cullType = ModEntry.Instance.CullCharacter.CharacterType;
		var newNodes = new Dictionary<IReadOnlyList<string>, StoryNode>();

		ModEntry.Instance.Helper.Events.OnModLoadPhaseFinished += (_, phase) =>
		{
			if (phase != ModLoadPhase.AfterDbInit)
				return;
			InjectStory(newNodes, [], [], NodeType.combat);
		};
		ModEntry.Instance.Helper.Events.OnLoadStringsForLocale += (_, e) => InjectLocalizations(newNodes, [], [], e);

		newNodes[["Played", "SmallRepairs"]] = new()
		{
			lookup = [$"Played::{new SmallRepairsCard().Key()}"],
			priority = true,
			oncePerRun = true,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
			],
		};

		for (var i = 0; i < 3; i++)
			newNodes[["Played", "ApologizeNextLoop", i.ToString()]] = new()
			{
				lookup = [$"Played::{new ApologizeNextLoopCard().Key()}"],
				priority = true,
				oncePerRun = true,
				oncePerCombatTags = [$"Played::{new ApologizeNextLoopCard().Key()}"],
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};

		for (var i = 0; i < 2; i++)
			newNodes[["Played", "SeekerBarrage", i.ToString()]] = new()
			{
				lookup = [$"Played::{new SeekerBarrageCard().Key()}"],
				priority = true,
				oncePerRun = true,
				oncePerCombatTags = [$"Played::{new SeekerBarrageCard().Key()}"],
				allPresent = [cullType],
				lines = [
					new Say { who = cullType, loopTag = "neutral" },
				],
			};
	}
}
