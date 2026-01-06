using HarmonyLib;
using Microsoft.Extensions.Logging;
using Nanoray.PluginManager;
using Nickel;
using Nickel.Common;
using Shockah.Kokoro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
	internal List<IModSettingsApi.IModSetting> SettingsEntries = [];

	internal ModSettings ModSettings = new();

	
	#region Cull
	internal IDeckEntry CullDeck { get; }
	internal IPlayableCharacterEntryV2 CullCharacter { get; }
	internal IStatusEntry SoulEnergyStatus { get; }
	internal IStatusEntry FearStatus { get; }
	internal IStatusEntry SoulDrainStatus { get; }
	internal IStatusEntry EmpoweredStatus { get; }
	internal IStatusEntry CloakedStatus { get; }
	internal ISpriteEntry CullFullBody { get; set; }

	internal ISpriteEntry harvestAttackSprite { get; }
	internal ISpriteEntry soulEnergySprite { get; }
	internal ISpriteEntry soulDrainSprite { get; }
	internal ISpriteEntry fearSprite { get; }
	internal ISpriteEntry empoweredSprite { get; }
	internal ISpriteEntry cloakedSprite { get; }
	internal Spr UncommonCullBorder { get; }
	internal Spr RareCullBorder { get; }
	internal List<Spr> cullNeutralAnim { get; }
	internal List<Spr> cullGlowAnim { get; }
	internal ISpriteEntry WispSprite { get; }
	internal ISpriteEntry WispIcon { get; }
	internal ISpriteEntry DormantWispIcon { get; }
	internal ISpriteEntry DormantWispSprite { get; }
	internal ISpriteEntry GreaterWispSprite { get; }
	internal ISpriteEntry GreaterWispIcon { get; }
	internal ISpriteEntry DormantGreaterWispIcon { get; }
	internal ISpriteEntry DormantGreaterWispSprite { get; }

	#endregion
	#region Jay
	internal IDeckEntry JayDeck { get; }
	internal IPlayableCharacterEntryV2 JayCharacter { get; }
	internal ISpriteEntry JayFullBody { get; set; }
	internal ISpriteEntry reconfigureSprite { get; }
	internal ISpriteEntry rebuildCannonSprite { get; }
	internal ISpriteEntry rebuildCockpitSprite { get; }
	internal ISpriteEntry rebuildWingSprite { get; }
	internal ISpriteEntry rebuildBaySprite { get; }
	internal ISpriteEntry rebuildScaffoldSprite { get; }
	internal ISpriteEntry rebuildCommsSprite { get; }
	internal ISpriteEntry rebuildSprite { get; }


	internal ISpriteEntry detectSprite { get; }
	internal IStatusEntry SignalBoosterStatus { get; }
	internal IStatusEntry LessEnergyAllTurnsStatus { get; }
	internal ISpriteEntry signalBoosterSprite { get; }
	internal ISpriteEntry lessEnergyAllTurnsSprite { get; }
	internal string rebuiltCannonSprite { get; }
	internal string rebuiltCockpitSprite { get; }
	internal string rebuiltBaySprite { get; }
	internal string rebuiltScaffoldSprite { get; }
	internal string rebuiltWingSprite { get; }
	internal string rebuiltCommsSprite { get; }
	internal INonPlayableCharacterEntryV2 ValvCharacter { get; }
	
	#endregion
	#region Luna
	internal IDeckEntry LunaDeck { get; }
	internal IPlayableCharacterEntryV2 LunaCharacter { get; }
	internal ISpriteEntry LunaFullBody { get; set; }
	internal IStatusEntry StardustStatus { get; }
	internal IStatusEntry ResidualDustStatus { get; }
	internal ISpriteEntry stardustSprite { get; }
	internal ISpriteEntry residualDustSprite { get; }
	internal ISpriteEntry stardustCostSprite { get; }

	#endregion
	
	#region Ships
	internal IShipEntry ThanatosShip { get; }
	internal IShipEntry VulcanShip { get; }
	internal IShipEntry AthenaShip { get; }

	#endregion
	public ISpriteEntry BGJayWorkshopSprite { get; }
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
		
		typeof(ReorganizeCard),
		typeof(SensoryShotCard),
		typeof(AmplifierCard),
		typeof(ReadTheContractCard),
		typeof(CommandCenterCard),
		typeof(CommsHubCard),
		typeof(ControlZCard),
		typeof(JumpTheLineCard),
		typeof(ShiftCard),
		
		typeof(ShinyShotCard),
		typeof(StarryShieldCard),
		typeof(EnergySapCard),
		typeof(PiercingLightCard),
		typeof(SurgeCard),
		typeof(SolarPowerCard),
		typeof(PremeditateCard),
		typeof(ShillelaghCard),
		typeof(BulletWardCard),
	];

	internal static IReadOnlyList<Type> UncommonCardTypes { get; } = [
		typeof(BargainCard),
		typeof(StunningStrikeCard),
		typeof(WispArrayCard),
		typeof(SoulBlastCard),
		typeof(TauntCard),
		typeof(PlayingWithFireCard), 
		typeof(NoxoiusCloudCard),
		
		typeof(HeavyArmoringCard),
		typeof(OptimizeCard),
		typeof(EscapePlanCard),
		typeof(LaunchCodesCard),
		typeof(SignalRelayCard),
		typeof(MixItUpCard), 
		typeof(ShootingGalleryCard),
		
		typeof(MoteCard),
		typeof(MoonbeamCard),
		typeof(InstantFreezeCard),
		typeof(HarmingSpellCard),
		typeof(CradlesCometCard),
		typeof(GatherCard), 
		typeof(NorthStarCard),
	];

	internal static IReadOnlyList<Type> RareCardTypes { get; } = [
		typeof(VanishCard),
		typeof(CripppleCard),
		typeof(ReapCard),
		typeof(UnstableSpiritCard),
		typeof(DeathTouchCard),
		
		typeof(CannonConstructorCard),
		typeof(FactoryResetCard),
		typeof(BareMinimumCard),
		typeof(OveruseCard),
		typeof(SelectiveSensorsCard),
		
		typeof(CometShowCard),
		typeof(InfiniteShineCard),
		typeof(CosmicCollectionCard),
		typeof(NebulaCard),
		typeof(SpaceTimeCard),
	];

	internal static IReadOnlyList<Type> SpecialCardTypes { get; } = [
		typeof(HarmlessSiphonCard),
		
		typeof(InspectionCard),
		
		
		
		typeof(BasicShotDualCard),
		typeof(BasicShieldDualCard),
		typeof(BasicDodgeDualCard),
		typeof(AthenaTacticsCard),
		
		typeof(AngerCard),
		/*typeof(DepressionCard),
		typeof(DenialCard),
		typeof(BargainingCard),
		typeof(AcceptanceCard)*/
	];
	
	internal static IReadOnlyList<Type> EXECardTypes { get; } = [
		typeof(CullExeCard),
		typeof(JayExeCard),
		typeof(LunaExeCard),
		/*typeof(CentiExeCard)
		typeof(EvaExeCard)*/
	];

	internal static IEnumerable<Type> AllCardTypes { get; }
		= [..CommonCardTypes, ..UncommonCardTypes, ..RareCardTypes, ..EXECardTypes, ..SpecialCardTypes];

	internal static IReadOnlyList<Type> CommonArtifacts { get; } = [
		typeof(MercifulReaperArtifact),
		typeof(ThreateningAuraArtifact),
		typeof(OverclockedSiphonArtifact),
		typeof(SoulReservesArtifact),
		typeof(EnhancedFocusArtifact),
		
		typeof(CodeInspectionArtifact),
		typeof(FinalTestArtifact),
		typeof(CellTowerArtifact),
		typeof(ReactiveMaterialsArtifact),
		
		typeof(ComponentPouchArtifact),
		typeof(StellarCharmArtifact),
		typeof(LetterOfAcceptanceArtifact),
		typeof(BackupCrystalArtifact),
		typeof(SolarPendantArtifact),
	];

	internal static IReadOnlyList<Type> BossArtifacts { get; } = [
		typeof(AnimismArtifact),
		typeof(CursedLanternArtifact),
		typeof(EnchantedScytheArtifact), 
		
		typeof(BlueprintsArtifact),
		typeof(EnhancedSensorsArtifact),
		typeof(BeltFeedArtifact),
		
		typeof(ChronomancyArtifact),
		typeof(SpellShaperArtifact),
		
		typeof(ReaperCannonsArtifact),
		typeof(KineticReboundArtifact),
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
		typeof(LunarPendantArtifact),
		
		typeof(HunterCannonsArtifact),
		typeof(VulcanPlatingArtifact),
		
		typeof(BattleTacticsArtifact),
		typeof(EndlessPreparationsArtifact),
		
	];

	internal static IReadOnlyList<Type> MidrowObjects { get; } =
	[
		typeof(Wisp),
		typeof(GreaterWisp),
		typeof(DormantWisp),
		typeof(DormantGreaterWisp),
		typeof(SkullBomb),
		
		typeof(Comet),
	];

	internal static IReadOnlyList<Type> EnemyTypes { get; } =
	[
		typeof(AngerEnemy),
		//typeof(DepressionEnemy),
		//typeof(BargainingEnemy),
		//typeof(DenialEnemy),
		//typeof(AcceptanceEnemy),
		//typeof(DeathEnemy),
	];
	
	internal static IEnumerable<Type> AllArtifactTypes
		=> [..CommonArtifacts, ..BossArtifacts, ..StarterArtifacts];

	internal static readonly IEnumerable<Type> RegisterableTypes
		= [..AllCardTypes, ..AllArtifactTypes, ..MidrowObjects,];

	internal static readonly IEnumerable<Type> LateRegisterableTypes
		= [..DuoArtifacts];

	public ModEntry(IPluginPackage<IModManifest> package, IModHelper helper, ILogger logger) : base(package, helper, logger)
	{
		harvestAttackSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/HarvestAttack.png"));
		soulEnergySprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Status/SoulEnergy.png"));
		soulDrainSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Status/SoulDrain.png"));
		fearSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Status/Fear.png"));
		empoweredSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Status/Empowered.png"));
		cloakedSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Status/Cloaked.png"));
		cullNeutralAnim = Enumerable.Range(0, 4)
			.Select(i =>
				helper.Content.Sprites
					.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Neutral/{i}.png"))
					.Sprite)
			.ToList();
		cullGlowAnim = Enumerable.Range(0, 4)
			.Select(i =>
				helper.Content.Sprites
					.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Cull/Character/Glow/{i}.png")).Sprite)
			.ToList();
		WispSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/Wisp.png"));
		WispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/WispIcon.png"));
		DormantWispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/DormantWispIcon.png"));
		DormantWispSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/DormantWisp.png"));
		GreaterWispSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/GreaterWisp.png"));
		GreaterWispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/GreaterWispIcon.png"));
		DormantGreaterWispIcon = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Icons/DormantGreaterWispIcon.png"));
		DormantGreaterWispSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/Midrow/DormantGreaterWisp.png"));

		reconfigureSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/Reconfigure.png"));
		rebuildSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/Rebuild.png"));
		rebuildCannonSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/RebuildCannon.png"));
		rebuildCockpitSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/RebuildCockpit.png"));
		rebuildCommsSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/RebuildComms.png"));
		rebuildBaySprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/RebuildBay.png"));
		rebuildScaffoldSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/RebuildScaffold.png"));
		rebuildWingSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/RebuildWing.png"));
		detectSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Icons/Detect.png"));
		signalBoosterSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Status/SignalBooster.png"));
		lessEnergyAllTurnsSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Status/EnergyAllTurns.png"));
		rebuiltWingSprite = helper.Content.Ships.RegisterPart("RebuiltWing", new() { Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Ship/Rebuild/RebuiltWing.png")).Sprite }).UniqueName;
		rebuiltCannonSprite = helper.Content.Ships.RegisterPart("RebuiltCannon", new() { Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Ship/Rebuild/RebuiltCannon.png")).Sprite }).UniqueName;
		rebuiltCockpitSprite = helper.Content.Ships.RegisterPart("RebuiltCockpit", new() { Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Ship/Rebuild/RebuiltCockpit.png")).Sprite }).UniqueName;
		rebuiltBaySprite = helper.Content.Ships.RegisterPart("RebuiltBay", new() { Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Ship/Rebuild/RebuiltBay.png")).Sprite }).UniqueName;
		rebuiltScaffoldSprite = helper.Content.Ships.RegisterPart("RebuiltScaffold", new() { Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Ship/Rebuild/RebuiltScaffold.png")).Sprite }).UniqueName;
		rebuiltCommsSprite = helper.Content.Ships.RegisterPart("RebuiltComms", new() { Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Ship/Rebuild/RebuiltComms.png")).Sprite }).UniqueName;

		stardustSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Status/Stardust.png"));
		residualDustSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Status/ResidualDust.png"));
		stardustCostSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Icons/StardustCost.png"));
		
		BGJayWorkshopSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Backgrounds/BGJayWorkshop.png"));
		this.helper = helper;
		
		Instance = this;
		Harmony = helper.Utilities.Harmony;
		KokoroApi = helper.ModRegistry.GetApi<IKokoroApi>("Shockah.Kokoro")!.V2;
		DuoArtifactsApi = helper.ModRegistry.GetApi<IDuoArtifactsApi>("Shockah.DuoArtifacts");
		ModSettings = helper.Storage.LoadJson<ModSettings>(helper.Storage.GetMainStorageFile("json"));

		helper.Events.OnModLoadPhaseFinished += (_, phase) =>
		{
			if (phase != ModLoadPhase.AfterDbInit)
				return;
			foreach (var registerableType in LateRegisterableTypes)
				AccessTools.DeclaredMethod(registerableType, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);
			foreach (Type type in EnemyTypes) {
				AccessTools.DeclaredMethod(type, nameof(IRegisterableEnemy.Register))?.Invoke(null, [helper]);
			}
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
		StardustManager.ApplyPatches(Harmony, logger);
		ResidualDustManager.ApplyPatches(Harmony, logger);
		
		CullDeck = helper.Content.Decks.RegisterDeck("Cull", new()
		{
			Definition = new() { color = new("272727"), titleColor = Colors.white },
			DefaultCardArt = StableSpr.cards_colorless,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/FrameCommon.png")).Sprite,
			Name = this.AnyLocalizations.Bind(["Cull","character", "name"]).Localize,
			ShineColorOverride = _ => new Color(0, 0, 0),
		});
		JayDeck = helper.Content.Decks.RegisterDeck("Jay", new()
		{
			Definition = new() { color = new("001ab7"), titleColor = Colors.white },
			DefaultCardArt = StableSpr.cards_colorless,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/CardFrame.png")).Sprite,
			Name = this.AnyLocalizations.Bind(["Jay","character", "name"]).Localize,
		});
		LunaDeck = helper.Content.Decks.RegisterDeck("Luna", new()
		{
			Definition = new() { color = new("a661cb"), titleColor = Colors.black },
			DefaultCardArt = StableSpr.cards_colorless,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/CardFrame.png")).Sprite,
			Name = this.AnyLocalizations.Bind(["Luna","character", "name"]).Localize,
		});
		
		foreach (var registerableType in RegisterableTypes)
			AccessTools.DeclaredMethod(registerableType, nameof(IRegisterable.Register))?.Invoke(null, [package, helper]);
		
		#region Cull Character
		
		
		UncommonCullBorder = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/FrameUncommon.png")).Sprite;
		RareCullBorder = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/FrameRare.png")).Sprite;
		CullCharacter = helper.Content.Characters.V2.RegisterPlayableCharacter("Cull", new()
		{
			Deck = CullDeck.Deck,
			Description = this.AnyLocalizations.Bind(["Cull","character", "description"]).Localize,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Cull/CharacterFrame.png")).Sprite,
			NeutralAnimation = new()
			{
				CharacterType = CullDeck.UniqueName,
				LoopTag = "neutral",
				Frames = cullNeutralAnim
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
			Frames = cullGlowAnim
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
				icon = soulEnergySprite.Sprite,
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
				icon = fearSprite.Sprite,
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
				icon = soulDrainSprite.Sprite,
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
				icon = empoweredSprite.Sprite,
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
				icon = cloakedSprite.Sprite,
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
		# region Jay Character
		

		JayCharacter = helper.Content.Characters.V2.RegisterPlayableCharacter("Jay", new()
		{
			Deck = JayDeck.Deck,
			Description = this.AnyLocalizations.Bind(["Jay","character", "description"]).Localize,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/CharacterFrame.png")).Sprite,
			NeutralAnimation = new()
			{
				CharacterType = JayDeck.UniqueName,
				LoopTag = "neutral",
				Frames = Enumerable.Range(0, 4)
					.Select(i =>
						helper.Content.Sprites
							.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/Neutral/{i}.png"))
							.Sprite)
					.ToList()
			},
			MiniAnimation = new()
			{
				CharacterType = JayDeck.UniqueName,
				LoopTag = "mini",
				Frames = [
					helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Character/mini.png")).Sprite
				]
			},
			Starters = new()
			{
				cards = [
					new ReorganizeCard(),
					new SensoryShotCard()
				]
			},
			SoloStarters = new StarterDeck()
			{
				cards = [
					new ReorganizeCard(),
					new SensoryShotCard(),
					new AmplifierCard(),
					new ControlZCard(),
					new CannonColorless(),
					new BasicShieldColorless()
					],
			},
			ExeCardType = typeof(JayExeCard)
		});
		
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "gameover",
			Frames = Enumerable.Range(0, 1)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/GameOver/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "squint",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/Squint/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "nervous",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/Nervous/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "angry",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/Angry/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "tear",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/Cry/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "sad",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/Sad/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "sob",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/Sob/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "damaged",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/Damaged/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = JayDeck.UniqueName,
			LoopTag = "damagedcry",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Jay/Character/DamagedCry/{i}.png")).Sprite)
				.ToList()
		});
		
		SignalBoosterStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("SignalBooster", new()
		{
			Definition = new()
			{
				icon = signalBoosterSprite.Sprite,
				color = new("00eeff"),
				isGood = true,
			},
			Name = AnyLocalizations.Bind(["Jay", "status", "SignalBooster", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Jay", "status", "SignalBooster", "description"])
				.Localize
		});
		LessEnergyAllTurnsStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("LessEnergyAllTurns", new()
		{
			Definition = new()
			{
				icon = lessEnergyAllTurnsSprite.Sprite,
				color = new("9c1824"),
				isGood = false,
			},
			Name = AnyLocalizations.Bind(["Jay", "status", "LessEnergyAllTurns", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Jay", "status", "LessEnergyAllTurns", "description"])
				.Localize
		});
		
		ValvCharacter = helper.Content.Characters.V2.RegisterNonPlayableCharacter("Valv", new NonPlayableCharacterConfigurationV2()
		{
			CharacterType = "valv",
			Name = AnyLocalizations.Bind(["Jay","character", "nameValv"]).Localize,
			
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2()
		{
			CharacterType = ValvCharacter.CharacterType,
			LoopTag = "neutral",
			Frames = Enumerable.Range(0, 4)
				.Select(i =>
					helper.Content.Sprites
						.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Valv/Neutral/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2()
		{
			CharacterType = ValvCharacter.CharacterType,
			LoopTag = "angry",
			Frames = Enumerable.Range(0, 4)
				.Select(i =>
					helper.Content.Sprites
						.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Valv/Mad/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2()
		{
			CharacterType = ValvCharacter.CharacterType,
			LoopTag = "nervous",
			Frames = Enumerable.Range(0, 4)
				.Select(i =>
					helper.Content.Sprites
						.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Valv/Nervous/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2()
		{
			CharacterType = ValvCharacter.CharacterType,
			LoopTag = "dead",
			Frames = Enumerable.Range(0, 1)
				.Select(i =>
					helper.Content.Sprites
						.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Valv/Dead/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2()
		{
			CharacterType = ValvCharacter.CharacterType,
			LoopTag = "ghost",
			Frames = Enumerable.Range(0, 4)
				.Select(i =>
					helper.Content.Sprites
						.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Valv/Ghost/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2()
		{
			CharacterType = ValvCharacter.CharacterType,
			LoopTag = "ghostsad",
			Frames = Enumerable.Range(0, 4)
				.Select(i =>
					helper.Content.Sprites
						.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Valv/GhostSad/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2()
		{
			CharacterType = ValvCharacter.CharacterType,
			LoopTag = "ghostmad",
			Frames = Enumerable.Range(0, 4)
				.Select(i =>
					helper.Content.Sprites
						.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Valv/GhostMad/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new CharacterAnimationConfigurationV2()
		{
			CharacterType = ValvCharacter.CharacterType,
			LoopTag = "fade",
			Frames = Enumerable.Range(0, 4)
				.Select(i =>
					helper.Content.Sprites
						.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Valv/Fade/{i}.png")).Sprite)
				.ToList()
		});
		
		Vault.charsWithLore.Add(JayDeck.Deck);
		JayFullBody = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Jay/Character/FullBody.png"));
		BGRunWin.charFullBodySprites.Add(JayDeck.Deck, JayFullBody.Sprite);
		# endregion
		#region Luna Character 
		
		
		LunaCharacter = helper.Content.Characters.V2.RegisterPlayableCharacter("Luna", new()
		{
			Deck = LunaDeck.Deck,
			Description = this.AnyLocalizations.Bind(["Luna","character", "description"]).Localize,
			BorderSprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/CharacterFrame.png")).Sprite,
			NeutralAnimation = new()
			{
				CharacterType = LunaDeck.UniqueName,
				LoopTag = "neutral",
				Frames = Enumerable.Range(0, 4)
					.Select(i =>
						helper.Content.Sprites
							.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Luna/Character/Neutral/{i}.png"))
							.Sprite)
					.ToList()
			},
			MiniAnimation = new()
			{
				CharacterType = LunaDeck.UniqueName,
				LoopTag = "mini",
				Frames = [
					helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Character/mini.png")).Sprite
				]
			},
			Starters = new()
			{
				cards = [
					new StarryShieldCard(),
					new ShinyShotCard()
				],
				artifacts = [new LunarPendantArtifact()]
			},
			SoloStarters = new StarterDeck()
			{
				cards = [
					new StarryShieldCard(),
					new ShinyShotCard(),
					new SurgeCard(),
					new PiercingLightCard(),
					new DodgeColorless(),
					new BasicShieldColorless()
					],
			},
			
			ExeCardType = typeof(LunaExeCard)
		});
		
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = LunaDeck.UniqueName,
			LoopTag = "gameover",
			Frames = Enumerable.Range(0, 1)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Luna/Character/GameOver/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = LunaDeck.UniqueName,
			LoopTag = "squint",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Luna/Character/Squint/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = LunaDeck.UniqueName,
			LoopTag = "nervous",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Luna/Character/Nervous/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = LunaDeck.UniqueName,
			LoopTag = "angry",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Luna/Character/Angry/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = LunaDeck.UniqueName,
			LoopTag = "tear",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Luna/Character/Cry/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = LunaDeck.UniqueName,
			LoopTag = "sad",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Luna/Character/Sad/{i}.png")).Sprite)
				.ToList()
		});
		helper.Content.Characters.V2.RegisterCharacterAnimation(new()
		{
			CharacterType = LunaDeck.UniqueName,
			LoopTag = "sob",
			Frames = Enumerable.Range(0, 4)
				.Select(i => helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile($"assets/Luna/Character/Sob/{i}.png")).Sprite)
				.ToList()
		});
		
		
		
		StardustStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("Stardust", new()
		{
			Definition = new()
			{
				icon = stardustSprite.Sprite,
				color = new("a661cb"),
				isGood = true,
			},
			Name = AnyLocalizations.Bind(["Luna", "status", "Stardust", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Luna", "status", "Stardust", "description"])
				.Localize
		});
		ResidualDustStatus = ModEntry.Instance.Helper.Content.Statuses.RegisterStatus("ResidualDust", new()
		{
			Definition = new()
			{
				icon = residualDustSprite.Sprite,
				color = new("2134a8"),
				isGood = true,
			},
			Name = AnyLocalizations.Bind(["Luna", "status", "ResidualDust", "name"]).Localize,
			Description = AnyLocalizations.Bind(["Luna", "status", "ResidualDust", "description"])
				.Localize
		});
		
		//Vault.charsWithLore.Add(LunaDeck.Deck);
		LunaFullBody = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Luna/Character/FullBody.png"));
		BGRunWin.charFullBodySprites.Add(LunaDeck.Deck, LunaFullBody.Sprite);
		# endregion
		
		#region Ships
		ThanatosShip = helper.Content.Ships.RegisterShip("Thanatos", new ShipConfiguration()
        {
            Ship = new StarterShip()
            {
                ship = new Ship()
                {
                    hull = 7,
                    hullMax = 7,
                    shieldMaxBase = 3,
                    parts =
                    {
                        new Part
                        {
                            type = PType.cannon,
                            skin = "wing_ares",
                        },
                        new Part
                        {
                            type = PType.wing,
                            skin = "wing_player",
                        },
                        new Part
                        {
                            type = PType.cockpit,
                            skin = "cockpit_artemis",
                        },
                        new Part
                        {
                            type = PType.missiles,
                            skin = "missiles_artemis",
                        },
                        new Part
                        {
                            type = PType.wing,
                            skin = "wing_player",
                            flip = true,
                        },
                        new Part
                        {
                            type = PType.cannon,
                            skin = "wing_ares",
                            active = false,
                            flip = true,
                        }
                    }
                },
                cards =
                {
                    new BasicShieldColorless(),
                    new DodgeColorless(),
                    new CannonColorless(),
                    new CannonColorless()
                },
                artifacts =
                {
                    new ShieldPrep(),
                    new HunterCannonsArtifact()
                }
            },
            ExclusiveArtifactTypes = new HashSet<Type>()
            {
                typeof(HunterCannonsArtifact),
                typeof(ReaperCannonsArtifact)
            },
            //UnderChassisSprite = "chassis_boxy",
            Name = AnyLocalizations.Bind(["ship", "Thanatos", "name"]).Localize,
            Description = AnyLocalizations.Bind(["ship", "Thanatos", "description"]).Localize
        });
		VulcanShip = helper.Content.Ships.RegisterShip("Vulcan", new ShipConfiguration()
        {
            Ship = new StarterShip()
            {
                ship = new Ship()
                {
                    hull = 8,
                    hullMax = 8,
                    shieldMaxBase = 8,
                    parts =
                    {
                        new Part
                        {
                            type = PType.missiles,
                            skin = "missiles_artemis",
                        },
                        new Part
                        {
                            type = PType.wing,
                            skin = "wing_player",
                        },
                        new Part
                        {
                            type = PType.cockpit,
                            skin = "cockpit_artemis",
                        },
                        new Part
                        {
                            type = PType.cannon,
                            skin = "cannon_artemis",
                        },
                        new Part
                        {
                            type = PType.wing,
                            skin = "wing_player",
                            flip = true,
                        },
                        new Part
                        {
	                        type = PType.wing,
	                        skin = "wing_player",
	                        flip = true
                        },
                    }
                },
                cards =
                {
                    new BasicShieldColorless(),
                    new DodgeColorless(),
                    new CannonColorless()
                },
                artifacts =
                {
                    new ShieldPrep(),
                    new VulcanPlatingArtifact()
                }
            },
            ExclusiveArtifactTypes = new HashSet<Type>()
            {
	            typeof(VulcanPlatingArtifact),
	            typeof(KineticReboundArtifact)
            },
            //UnderChassisSprite = "chassis_boxy",
            Name = AnyLocalizations.Bind(["ship", "Vulcan", "name"]).Localize,
            Description = AnyLocalizations.Bind(["ship", "Vulcan", "description"]).Localize
        });
		AthenaShip = helper.Content.Ships.RegisterShip("Athena", new ShipConfiguration()
        {
            Ship = new StarterShip()
            {
                ship = new Ship()
                {
                    hull = 6,
                    hullMax = 6,
                    shieldMaxBase = 6,
                    parts =
                    {
                        new Part
                        {
                            type = PType.wing,
                            skin = "wing_player",
                        },
                        new Part
                        {
                            type = PType.cockpit,
                            skin = "cockpit_artemis",
                        },
                        new Part
                        {
                            type = PType.missiles,
                            skin = "missiles_artemis",
                        },
                        new Part
                        {
	                        type = PType.cannon,
	                        skin = "wing_ares",
                        },
                        new Part
                        {
                            type = PType.wing,
                            skin = "wing_player",
                            flip = true,
                        },
                    }
                },
                cards =
                {
	                new BasicShotDualCard(),
	                new BasicShotDualCard(),
	                new BasicDodgeDualCard(),
	                new BasicShieldDualCard(),
                },
                artifacts =
                {
                    new ShieldPrep(),
                    new BattleTacticsArtifact(),
                }
            },
            ExclusiveArtifactTypes = new HashSet<Type>()
            {
                typeof(BattleTacticsArtifact),
                typeof(EndlessPreparationsArtifact)
            },
            //UnderChassisSprite = "chassis_boxy",
            Name = AnyLocalizations.Bind(["ship", "Athena", "name"]).Localize,
            Description = AnyLocalizations.Bind(["ship", "Athena", "description"]).Localize
        });
		#endregion
		
		DB.backgrounds.Add("BGJayWorkshop", typeof(Backgrounds.BGJayWorkshop));
		
		DB.backgrounds.Add("BGBattleMemory", typeof(Backgrounds.BGBattleMemory));
		DB.backgrounds.Add("BGRunWinCustom", typeof(Backgrounds.BGRunWinCustom));

		helper.ModRegistry.AwaitApi<IMoreDifficultiesApi>(
			"TheJazMaster.MoreDifficulties",
			new SemanticVersion(1, 3, 0),
			api =>
			{
				api.RegisterAltStarters(
					deck: CullDeck.Deck,
					starterDeck: new StarterDeck
					{
						artifacts =
						[
							new SoulSiphonArtifact()
						],
						cards =
						[
							new RealignCard(),
							new WillOWispCard()
						]
					}
				);
				api.RegisterAltStarters(
					deck: JayDeck.Deck,
					starterDeck: new StarterDeck
					{
						cards =
						[
							new ShiftCard(),
							new ReadTheContractCard()
						]
					}
				);
				api.RegisterAltStarters(
					deck: LunaDeck.Deck,
					starterDeck: new StarterDeck
					{
						artifacts =
						[
							new LunarPendantArtifact()
						],
						cards =
							[
								new BulletWardCard(),
								new ShillelaghCard()
							]
					} 
					);
			});
		
		_ = new CombatDialogueAll();
		_ = new EventDialogueAll();
		
		_ = new SoulEnergyManager();
		_ = new FearManager();
		_ = new SoulDrainManager();
		_ = new EmpoweredManager();
		_ = new CloakedManager();
		_ = new CardDialogueCull();
		_ = new MemoryDialogueCull();		
		_ = new StoryDialogueCull();
		_ = new SoulPortraitManager();

		_ = new LessEnergyAllTurnsManager();
		_ = new APartModManager();
		_ = new AFactoryResetManager();
		_ = new CardDialogueJay();
		_ = new MemoryDialogueJay();		
		_ = new StoryDialogueJay();

		_ = new StardustManager();
		_ = new ResidualDustManager();
		_ = new StardustCostManager();
		_ = new CardDialogueLuna();
		_ = new MemoryDialogueLuna();		
		_ = new StoryDialogueLuna();
		
		_ = new Backgrounds();
		
		//SetUpModSettings(helper);
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
	
	private void SetUpModSettings(IModHelper helper) {
		if (helper.ModRegistry.GetApi<IModSettingsApi>("Nickel.ModSettings") is { } settingsApi) {
			settingsApi.RegisterModSettings(settingsApi.MakeList(SettingsEntries)
				.SubscribeToOnMenuClose(_ => {
					helper.Storage.SaveJson(helper.Storage.GetMainStorageFile("json"), ModSettings);
				}));
		}
	}
}
class ModSettings {
	public readonly Dictionary<string, bool> enemiesDisabled = [];
}
