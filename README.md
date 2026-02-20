# The Chopping Block

A kids' educational mobile game about healthy eating, built with Unity 6.

**Developer:** TopTierTechnologies / 404-Found
**Platform:** Android (iOS coming soon)
**Engine:** Unity 6 (6000.3.6f1) with Universal Render Pipeline (URP)
**Package ID:** `com.404found.choppingblock`

---

## About the Game

The Chopping Block teaches kids about healthy eating through interactive gameplay. Players tap falling food items to learn about fruits and vegetables — what season they grow in, their nutritional value, where they come from, and fun facts. The game rewards curiosity and healthy food knowledge with coins, trophies, and unlockables.

**Target Audience:** Kids (PEGI 3 / Everyone)
**Core Loop:** Tap food → Learn fact → Earn coins → Unlock more food

---

## Getting Started

### Prerequisites

- [Unity Hub](https://unity.com/download)
- Unity 6 (6000.3.6f1) — install via Unity Hub
- Android Build Support module (for Android builds)

### Setup

1. Clone the repo:
   ```bash
   git clone https://github.com/TopTierTechnologies/chopping-block.git
   ```

2. Open Unity Hub → **Add** → browse to the cloned folder

3. Open the project in Unity 6 (6000.3.6f1)
   - First open will take a few minutes — Unity rebuilds the `Library/` folder automatically

4. Open the **MainMenu** scene to start:
   `Assets/Scenes/MainMenu.unity`

5. Press **Play** to run in the editor

---

## Project Structure

```
Assets/
├── Audio/
│   ├── Music/          # Background music (MenuMusic, GameplayMusic)
│   └── SFX/            # Sound effects (Tap, Unlock, GameOver, ButtonClick)
├── Prefabs/            # FoodItem, FoodItemCard, Apple
├── Resources/
│   └── FoodData/       # ScriptableObjects for each food (Fruit/, veggie/)
├── Scenes/             # MainMenu, Gameplay, Classic, GameOver, Settings, TrophyCase
├── Scripts/
│   ├── AudioManager.cs       # Audio singleton - manages all music and SFX
│   ├── FoodData.cs           # ScriptableObject definition for food items
│   ├── FoodItem.cs           # Food tap interaction logic
│   ├── FoodManager.cs        # Loads and manages food data
│   ├── FoodSpawner.cs        # Spawns food items during gameplay
│   ├── GameManager.cs        # Core game loop, lives, scoring
│   ├── MainMenuManager.cs    # Main menu UI and navigation
│   ├── TapDetector.cs        # Input system tap detection
│   ├── ThrophyCaseManager.cs # Trophy display logic
│   ├── UnlockBannerManager.cs# Unlock celebration banner
│   └── Editor/
│       └── AudioManagerSetup.cs # Editor tool: Tools > Setup AudioManager
├── Sprites/            # UI sprites, food sprites, backgrounds, logo
└── Settings/           # URP renderer and pipeline assets
ProjectSettings/        # Unity project config (DO NOT delete)
```

---

## Coding Standards

All scripts follow the same singleton pattern:

```csharp
public static ClassName Instance;

void Awake()
{
    if (Instance == null)
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    else
    {
        Destroy(gameObject);
        return;
    }
}
```

- **Persistence:** `PlayerPrefs` for coins (`"UserCoins"`), food unlocks (`"Food_Unlocked_"` prefix), audio (`"Audio_"` prefix)
- **Input:** Unity New Input System (`InputSystem_Actions.inputactions`)
- **Null safety:** Always call `AudioManager.Instance?.Method()` — game runs silently if AudioManager is absent
- **Headers:** Use `[Header("Section Name")]` to group inspector fields
- **SerializeField:** Use instead of public for inspector-only fields

---

## Audio

### Setup
The AudioManager GameObject lives in the **MainMenu** scene and persists across all scenes via `DontDestroyOnLoad`. All audio clips are assigned in the Inspector.

To re-run setup: **Tools > Setup AudioManager** in the Unity menu.

### Audio Credits

**Music (CC-BY — attribution required):**
- "Wallpaper" by Kevin MacLeod (incompetech.com) — Main Menu
- "Anachronist" by Kevin MacLeod (incompetech.com) — Gameplay
- Licensed under Creative Commons Attribution 4.0: http://creativecommons.org/licenses/by/4.0/

**Sound Effects (CC0 — no attribution required):**
- TapSound, UnlockSound, ButtonClick — Kenney Interface Sounds (kenney.nl)

**Game Over Sound:**
- freesound_community-negative_beeps (freesound.org)

> **Important:** Kevin MacLeod attribution must appear in the app's credits/settings screen before release.

---

## Android Build

See `ANDROID_BUILD_CONFIG.md` for full Android build checklist.

**Quick reference:**
- Company: 404-Found
- Package: `com.404found.choppingblock`
- Min SDK: Android 7.0 (API 24)
- Target SDK: Android 14 (API 34)
- Architecture: ARM64

---

## Git Workflow

```bash
# Pull latest before starting work
git pull

# After making changes
git add .
git commit -m "brief description of what you changed"
git push
```

**Branch strategy (when team grows):**
- `master` — stable, always playable
- `feature/your-feature` — new work, merge via Pull Request

---

## Roadmap

### Beta (current focus)
- [x] Core tap gameplay
- [x] Food ScriptableObject data system
- [x] Coin and unlock system
- [x] Trophy Case
- [x] Audio system (music + SFX)
- [x] Git version control + GitHub
- [ ] Settings scene (volume sliders wired to AudioManager)
- [ ] Game Over screen UI
- [ ] Kevin MacLeod attribution screen
- [ ] Android build + Google Play listing

### Post-Beta
- [ ] Unity Gaming Services (cloud save, analytics)
- [ ] iOS build + App Store
- [ ] More food items and categories
- [ ] Seasonal content
- [ ] Multiplayer / social features

---

## License

Proprietary — All rights reserved. TopTierTechnologies / 404-Found © 2025
