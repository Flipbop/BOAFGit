using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nickel;
using Nickel.Common;
using Shockah.Kokoro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Flipbop.BOAF;

public sealed class ModEntry : SimpleMod
{
	internal static ModEntry Instance { get; private set; } = null!;
	internal readonly IBOAFApi Api = new ApiImplementation();

	internal IHarmony Harmony { get; }
	internal IKokoroApi.IV2 KokoroApi { get; }
	internal IDuoArtifactsApi? DuoArtifactsApi { get; }
	public LocalDB localDB { get; set; } = null!;
	internal ILocalizationProvider<IReadOnlyList<string>> AnyLocalizations { get; }
	internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> Localizations { get; }
	
	internal IDeckEntry CullDeck { get; }
	internal IPlayableCharacterEntryV2 CullCharacter { get; }
	internal IStatusEntry SoulEnergyStatus { get; }
	internal IStatusEntry FearStatus { get; }
	internal IStatusEntry SoulDrainStatus { get; }
	internal IStatusEntry EmpoweredStatus { get; }
	internal IStatusEntry CloakedStatus { get; }
	internal ISpriteEntry placeholderSprite { get; }
	internal ISpriteEntry CullFullBody { get; set; }

	internal ISpriteEntry harvestAttackSprite { get; }
	internal Spr UncommonCullBorder { get; }
	internal Spr RareCullBorder { get; }


	public IModHelper helper { get; }
	
	
	internal static IReadOnlyList<Type> CommonCardTypes { get; } = [
		typeof(QuickCastCard),
		typeof(HarvestCard),
		typeof(WillOWispCard),
		typeof(FontOfStrengthCard),
		typeof(TelekinesisCard),
		typeof(NecromancyCard),
		typeof(ExcessiveForceCard),
		typeof(RealignCard),
		typeof(FlightyCard),
	];

	internal static IReadOnlyList<Type> UncommonCardTypes { get; } = [
		typeof(BargainCard),
		typeof(StunningStrikeCard),
		//typeof(WispArrayCard),
		//typeof(SoulBlastCard),
		typeof(TauntCard),
		//typeof(PlayingWithFireCard), 
		typeof(NoxoiusCloudCard),
	];

	internal static IReadOnlyList<Type> RareCardTypes { get; } = [
		typeof(VanishCard),
		//typeof(CripppleCard),
		typeof(ReapCard),
		//typeof(UnstableSpiritCard),
		typeof(DeathTouchCard),
	];

	internal static IReadOnlyList<Type> SpecialCardTypes { get; } = [
		typeof(HarmlessSiphonCard),
	];

	internal static IEnumerable<Type> AllCardTypes { get; }
		= [..CommonCardTypes, ..UncommonCardTypes, ..RareCardTypes, typeof(CullExeCard), ..SpecialCardTypes];

	internal static IReadOnlyList<Type> CommonArtifacts { get; } = [
		typeof(MercifulReaperArtifact),
		typeof(ThreateningAuraArtifact),
		typeof(OverclockedSiphonArtifact),
		typeof(SoulReservesArtifact),
		typeof(EnhancedFocusArtifact), 
	];

	internal static IReadOnlyList<Type> BossArtifacts { get; } = [
		typeof(AnimismArtifact),
		typeof(CursedLanternArtifact),
		typeof(EnchantedScytheArtifact), 
	];

	internal static IReadOnlyList<Type> DuoArtifacts { get; } = [
/*		typeof(CleoBooksArtifact),
		typeof(CleoCatArtifact),
		typeof(CleoDizzyArtifact),
		typeof(CleoDrakeArtifact),
		typeof(CleoIsaacArtifact),
		typeof(CleoMaxArtifact),
		typeof(CleoPeriArtifact),
		typeof(CleoRiggsArtifact), */
	];

	internal static IReadOnlyList<Type> StarterArtifacts { get; } = [
		typeof(SoulSiphonArtifact),
	];

	internal static IReadOnlyList<Type> MidrowObjects { get; } =
	[
		typeof(Wisp),
		typeof(SkullBomb)
	];
	
	internal static IEnumerable<Type> AllArtifactTypes
		=> [..CommonArtifacts, ..BossArtifacts, ..StarterArtifacts];

	internal static readonly IEnumerable<Type> RegisterableTypes
		= [..AllCardTypes, ..AllArtifactTypes, ..MidrowObjects, ];

	internal static readonly IEnumerable<Type> LateRegisterableTypes
		= [..DuoArtifacts];

	public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
	{
		placeholderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/Impaired.png"));
		harvestAttackSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/HarvestAttack.png"));
		this.helper = helper;
		
		Instance = this;
		Harmony = helper.Utilities.Harmony;
		KokoroApi = helper.ModRegistry.GetApi<IKokoroApi>("Shockah.Kokoro")!.V2;
		DuoArtifactsApi = helper.ModRegistry.GetApi<IDuoArtifactsApi>("Shockah.DuoArtifacts");

		helper.Events.OnModLoadPhaseFinished += (_, phase) =>
		{
			if (phase != ModLoadPhase.AfterDbInit)
				return;
			foreach (var registerableType in LateRegisterableTypes)
				AccessTools.DeclaredMethod(registerableType, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);
			localDB = new(helper, package);
		};
		helper.Events.OnLoadStringsForLocale += (_, thing) =>
		{
			foreach (KeyValuePair<string, string> entry in localDB.GetLocalizationResults())
			{
				thing.Localizations[entry.Key] = entry.Value;
			}
		};


		this.AnyLocalizations = new JsonLocalizationProvider(
			tokenExtractor: new SimpleLocalizationTokenExtractor(),
			localeStreamFunction: locale => package.PackageRoot.GetRelativeFile($"i18n/main-{locale}.json").OpenRead()
		);
		this.Localizations = new MissingPlaceholderLocalizationProvider<IReadOnlyList<string>>(
			new CurrentLocaleOrEnglishLocalizationProvider<IReadOnlyList<string>>(this.AnyLocalizations)
		);
		
		DynamicWidthCardAction.ApplyPatches(Harmony, logger);
		SoulEnergyManager.ApplyPatches(Harmony, logger);
		AHarvestAttack.ApplyPatches(Harmony, logger);

		#region Cull Character
		CullDeck = helper.Content.Decks.RegisterDeck("Cull", new()
		{
			Definition = new() { color = new("272727"), titleColor = Colors.white },
			DefaultCardArt = StableSpr.cards_colorless,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/FrameCommon.png")).Sprite,
			Name = this.AnyLocalizations.Bind(["Cull","character", "name"]).Localize,
			ShineColorOverride = _ => new Color(0, 0, 0),
		});
		UncommonCullBorder = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/FrameUncommon.png")).Sprite;
		RareCullBorder = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/FrameRare.png")).Sprite;
		
		foreach (var registerableType in RegisterableTypes)
			AccessTools.DeclaredMethod(registerableType, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);
		
		
		CullCharacter = helper.Content.Characters.V2.RegisterPlayableCharacter("Cull", new()
		{
			Deck = CullDeck.Deck,
			Description = this.AnyLocalizations.Bind(["Cull","character", "description"]).Localize,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/CharacterFrame.png")).Sprite,
			NeutralAnimation = new()
			{
				CharacterType = CullDeck.UniqueName,
				LoopTag = "neutral",
				Frames = Enumerable.Range(0, 4)
					.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Neutral/{i}.png")).Sprite)
					.ToList()
			},
			MiniAnimation = new()
			{
				CharacterType = CullDeck.UniqueName,
				LoopTag = "mini",
				Frames = [
					helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Character/mini.png")).Sprite
				]
			},
			Starters = new()
			{
				artifacts = [
					new SoulSiphonArtifact()
				],
				cards = [
					new QuickCastCard(),
					new HarvestCard()
				]
			},
			SoloStarters = new StarterDeck()
			{
				cards = [
					new QuickCastCard(),
					new HarvestCard(),
					new RealignCard(),
					new WillOWispCard(),
					new CannonColorless(),
					new DodgeColorless()
					],
				artifacts = [new SoulSiphonArtifact()]
			},
			ExeCardType = typeof(CullExeCard)
		});
		
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "gameover",
			Frames = Enumerable.Range(0, 1)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/GameOver/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "squint",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Squint/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "glow",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Glow/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "nervous",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Nervous/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "angry",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Angry/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "tear",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Cry/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "sad",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Sad/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "sob",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Sob/{i}.png")).Sprite)
				.ToList()
		});
		
		SoulEnergyStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("SoulEnergy", new()
		{
			Definition = new()
			{
				icon = ModEntry.Instance.Helper.Content.Sprites
					.RegisterSprite(
						ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Status/SoulEnergy.png"))
					.Sprite,
				color = new("670099"),
				isGood = true,
			},
			Name = AnyLocalizations.Bind(["Cull", "status", "SoulEnergy", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Cull", "status", "SoulEnergy", "description"])
				.Localize
		});
		FearStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("Fear", new()
		{
			Definition = new()
			{
				icon = ModEntry.Instance.Helper.Content.Sprites
					.RegisterSprite(
						ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Status/Fear.png"))
					.Sprite,
				color = new("008c81"),
				isGood = false,
			},
			Name = AnyLocalizations.Bind(["Cull", "status", "Fear", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Cull", "status", "Fear", "description"])
				.Localize
		});
		SoulDrainStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("SoulDrain", new()
		{
			Definition = new()
			{
				icon = ModEntry.Instance.Helper.Content.Sprites
					.RegisterSprite(
						ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Status/SoulDrain.png"))
					.Sprite,
				color = new("b80000"),
				isGood = false,
			},
			Name = AnyLocalizations.Bind(["Cull", "status", "SoulDrain", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Cull", "status", "SoulDrain", "description"])
				.Localize
		});
		EmpoweredStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("Empowered", new()
		{
			Definition = new()
			{
				icon = ModEntry.Instance.Helper.Content.Sprites
					.RegisterSprite(
						ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Status/Empowered.png"))
					.Sprite,
				color = new("0062ff"),
				isGood = true,
			},
			Name = AnyLocalizations.Bind(["Cull", "status", "Empowered", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Cull", "status", "Empowered", "description"])
				.Localize
		});
		CloakedStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("Cloaked", new()
		{
			Definition = new()
			{
				icon = ModEntry.Instance.Helper.Content.Sprites
					.RegisterSprite(
						ModEntry.Instance.Package.PackageRoot.GetRelativeFile("assets/Cull/Status/Cloaked.png"))
					.Sprite,
				color = new("312351"),
				isGood = true,
			},
			Name = AnyLocalizations.Bind(["Cull", "status", "Cloaked", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Cull", "status", "Cloaked", "description"])
				.Localize
		});
		
		//Vault.charsWithLore.Add(CullDeck.Deck);
		CullFullBody = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Character/FullBody.png"));
		BGRunWin.charFullBodySprites.Add(CullDeck.Deck, CullFullBody.Sprite);
		#endregion

		helper.ModRegistry.AwaitApi<IMoreDifficultiesApi>(
			"TheJazMaster.MoreDifficulties",
			new SemanticVersion(1, 3, 0),
			api => api.RegisterAltStarters(
				deck: CullDeck.Deck,
				starterDeck: new StarterDeck
				{
					artifacts = [
						new SoulSiphonArtifact()
					],
					cards = [
						new RealignCard(),
						new WillOWispCard()
					]
				}
			)
		);
		
		_ = new SoulEnergyManager();
		_ = new FearManager();
		_ = new SoulDrainManager();
		_ = new EmpoweredManager();
		_ = new CloakedManager();
		_ = new CardDialogueCull();
		_ = new CombatDialogueCull();
		_ = new EventDialogueCull();
		_ = new MemoryDialogueCull();		
		_ = new StoryDialogueCull();
		
		
	}


	public override object? GetApi(IModManifest requestingMod)
		=> new ApiImplementation();

	internal static Rarity GetCardRarity(Type type)
	{
		if (RareCardTypes.Contains(type))
			return Rarity.rare;
		if (UncommonCardTypes.Contains(type))
			return Rarity.uncommon;
		return Rarity.common;
	}

	internal static ArtifactPool[] GetArtifactPools(Type type)
	{
		if (BossArtifacts.Contains(type))
			return [ArtifactPool.Boss];
		if (CommonArtifacts.Contains(type))
			return [ArtifactPool.Common];
		return [];
	}
}
