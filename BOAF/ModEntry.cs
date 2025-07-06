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
	internal ILocalizationProvider<IReadOnlyList<string>> AnyLocalizations { get; }
	internal ILocaleBoundNonNullLocalizationProvider<IReadOnlyList<string>> Localizations { get; }

	internal IDeckEntry CullDeck { get; }
	internal IPlayableCharacterEntryV2 CullCharacter { get; }
	internal IStatusEntry SoulEnergyStatus { get; }
	internal IStatusEntry FearStatus { get; }
	internal IStatusEntry SoulDrainStatus { get; }
	internal ISpriteEntry placeholderSprite { get; }

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
		typeof(WispArrayCard),
		typeof(SoulBlastCard),
		typeof(TauntCard),
		typeof(PlayingWithFireCard), 
		typeof(NoxoiusCloudCard),
	];

	internal static IReadOnlyList<Type> RareCardTypes { get; } = [
		typeof(VanishCard),
		typeof(CripppleCard),
		typeof(ReapCard),
		typeof(UnstableSpiritCard),
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

	internal static IEnumerable<Type> AllArtifactTypes
		=> [..CommonArtifacts, ..BossArtifacts, ..StarterArtifacts];

	internal static readonly IEnumerable<Type> RegisterableTypes
		= [..AllCardTypes, ..AllArtifactTypes];

	internal static readonly IEnumerable<Type> LateRegisterableTypes
		= DuoArtifacts;

	public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
	{
		placeholderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/Impaired.png"));
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

		#region Cull Character
		CullDeck = helper.Content.Decks.RegisterDeck("Cull", new()
		{
			Definition = new() { color = new("222222"), titleColor = Colors.white },
			DefaultCardArt = StableSpr.cards_colorless,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/CardFrame.png")).Sprite,
			Name = this.AnyLocalizations.Bind(["Cull","character", "name"]).Localize
		});

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
				Frames = Enumerable.Range(0, 5)
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
					]
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
			Frames = Enumerable.Range(0, 3)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Squint/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "explain",
			Frames = Enumerable.Range(0, 5)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Explain/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = CullDeck.UniqueName,
			LoopTag = "nervous",
			Frames = Enumerable.Range(0, 5)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Nervous/{i}.png")).Sprite)
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
				color = new("301934"),
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
				color = new("2A0134"),
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
				color = new("2A0134"),
				isGood = false,
			},
			Name = AnyLocalizations.Bind(["Cull", "status", "SoulDrain", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Cull", "status", "SoulDrain", "description"])
				.Localize
		});
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
						new NecromancyCard()
					]
				}
			)
		);
		
		_ = new SoulEnergyManager();
		_ = new FearManager();
		_ = new SoulDrainManager();
		_ = new DialogueExtensions();
		_ = new CombatDialogue();
		_ = new EventDialogue();
		_ = new CardDialogue();
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
