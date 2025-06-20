using Nickel;
using System.Collections.Generic;

using HarmonyLib;


namespace Flipbop.BOAF;
internal sealed class EventDialogue : BaseDialogue
{

	public EventDialogue() : base(locale => ModEntry.Instance.Package.PackageRoot.GetRelativeFile($"i18n/dialogue-event-{locale}.json").OpenRead())
	{
		var cullDeck = ModEntry.Instance.CullDeck.Deck;
		var cullType = ModEntry.Instance.CullCharacter.CharacterType;
		var newNodes = new Dictionary<IReadOnlyList<string>, StoryNode>();
		var newHardcodedNodes = new Dictionary<IReadOnlyList<string>, StoryNode>();
		var saySwitchNodes = new Dictionary<IReadOnlyList<string>, Say>();
		
		ModEntry.Instance.Helper.Events.OnModLoadPhaseFinished += (_, phase) =>
		{
			if (phase != ModLoadPhase.AfterDbInit)
				return;			
			InjectStory(newNodes, newHardcodedNodes, saySwitchNodes, NodeType.@event);
		};
		ModEntry.Instance.Helper.Events.OnLoadStringsForLocale += (_, e) => 
		{
			foreach (KeyValuePair<string, StoryNode> node in DB.story.all)
			{
				if (node.Value.lookup?.Contains("shopBefore") == true && node.Value.allPresent?.Contains(cullType) == false)
				{
					node.Value.nonePresent = [cullType];
				}
			}
			InjectLocalizations(newNodes, newHardcodedNodes, saySwitchNodes, e);
		};
		
		
		newNodes[["Cull", "Shop", "0"]] = new()
		{
			lookup = ["shopBefore"],
			bg = typeof(BGShop).Name,
			allPresent = [cullType],
			priority = true,
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
				new Say { who = cullType, loopTag = "neutral", flipped = true},
			],
			choiceFunc = "NewShop",
		};
		newNodes[["Cull", "Shop", "1"]] = new()
		{
			lookup = ["shopBefore"],
			bg = typeof(BGShop).Name,
			allPresent = [cullType],
			priority = true,
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
				new Say { who = cullType, loopTag = "neutral", flipped = true},
			],
			choiceFunc = "NewShop",
		};
		
		newHardcodedNodes[["Cull", "LoseCharacterCard_{{CharacterType}}"]] = new()
		{
			oncePerRun = true,
			bg = typeof(BGSupernova).Name,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "neutral" },
			],
		};
		newHardcodedNodes[["Cull", "CrystallizedFriendEvent_{{CharacterType}}"]] = new()
		{
			oncePerRun = true,
			bg = typeof(BGCrystalizedFriend).Name,
			allPresent = [cullType],
			lines = [
				new Wait() { secs = 1.5 },
				new Say { who = cullType, loopTag = "neutral" },
			],
		};
		newHardcodedNodes[["Cull", "ChoiceCardRewardOfYourColorChoice_{{CharacterType}}"]] = new()
		{
			oncePerRun = true,
			bg = typeof(BGBootSequence).Name,
			allPresent = [cullType],
			lines = [
				new Say { who = cullType, loopTag = "squint" },
				new Say { who = "comp", loopTag = "neutral" },
			],
		};

		saySwitchNodes[["Cull", "GrandmaShop"]] = new()
		{
			who = cullType,
			loopTag = "neutral"
		};
		saySwitchNodes[["Cull", "LoseCharacterCard"]] = new()
		{
			who = cullType,
			loopTag = "nervous"
		};
		saySwitchNodes[["Cull", "CrystallizedFriendEvent"]] = new()
		{
			who = cullType,
			loopTag = "neutral"
		};
		saySwitchNodes[["Cull", "ShopKeepBattleInsult"]] = new()
		{
			who = cullType,
			loopTag = "nervous"
		};
		saySwitchNodes[["Cull", "DraculaTime"]] = new()
		{
			who = cullType,
			loopTag = "squint"
		};
		saySwitchNodes[["Cull", "Soggins_Infinite"]] = new()
		{
			who = cullType,
			loopTag = "neutral"
		};
		saySwitchNodes[["Cull", "Soggins_Missile_Shout_1"]] = new()
		{
			who = cullType,
			loopTag = "neutral"
		};
		saySwitchNodes[["Cull", "SogginsEscapeIntent_1"]] = new()
		{
			who = cullType,
			loopTag = "neutral"
		};
		saySwitchNodes[["Cull", "SogginsEscape_1"]] = new()
		{
			who = cullType,
			loopTag = "neutral"
		};
	}
}
