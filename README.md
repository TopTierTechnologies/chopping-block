# The Chopping Block

An interactive educational mobile game designed to teach children about healthy eating through gameplay.

**Developer:** 404 Found — Florida A&M University, Group #2
**Platform:** Android (Google Play)
**Engine:** Unity 6 (6000.3.6f1), Universal Render Pipeline
**Status:** Alpha — Beta release in progress
**Total Project Budget:** $45

---

## Problem Statement

Childhood nutrition habits are in decline. According to the CDC and NCBI:

- Only 23% of children eat fruits and vegetables daily
- Nearly 40% of daily caloric intake comes from nutritionally empty foods
- Poor early eating habits correlate with obesity, cognitive delays, and weakened immune function

Existing educational tools are passive — textbooks, posters, and static apps that fail to engage children in the age group most influenced by interactive media.

---

## Our Solution

The Chopping Block reframes nutrition education as an active, rewarding experience. Players tap falling fruits and vegetables to score points, unlock new foods, and collect educational facts about each item. The game does not teach at children — it lets them discover healthy foods through play.

**Core educational loop:**
1. Tap a food item during gameplay
2. Earn points and coins
3. Unlock new foods with coins or score milestones
4. View the food's details in the Trophy Case — season, food group, origin, fun fact, nutrients, and calories

Every food unlock is an opportunity to learn. The Trophy Case functions as a growing collection of knowledge the player has earned through gameplay.

---

## Game Modes

| Mode | Status | Description |
|---|---|---|
| Classic | Functional | Tap falling foods, avoid missing them. 3 lives, score-based progression. |
| Countdown | Planned | 60-second time attack for highest score. |
| Quiz | Planned | Answer nutrition questions about seasonal foods. |

---

## Target Audience

**Primary:** Children ages 8-12 (grades 3-7)
**Secondary:** Parents, educators, and school health professionals

Content rating: PEGI 3 / Everyone. No violence, no mature content, no real-money transactions.

---

## Features (Beta Scope)

- Classic gameplay with lives, scoring, and food spawning
- Six unlockable foods with complete educational data (season, nutrients, calories, origin, fun facts)
- Coin economy — earned through gameplay, spent to unlock foods
- Trophy Case — visual collection showing all foods, locked and unlocked, with educational detail view
- Audio system — background music and sound effects, kid-friendly and upbeat, with volume and mute controls
- Settings screen — volume sliders, graphics quality, audio attribution
- Mode Selection screen — Classic accessible, future modes shown as coming soon
- Game Over screen — displays final score, personal best, and coins earned
- Persistent progress — all unlocks, coins, and settings saved locally across sessions
- Git version control with full project history on GitHub

---

## Technical Architecture

**Engine:** Unity 6 (6000.3.6f1)
**Language:** C#
**Rendering:** Universal Render Pipeline (URP)
**Input:** Unity New Input System
**Persistence:** PlayerPrefs (local), Unity Gaming Services planned for cloud sync
**Backend planned:** Firebase (authentication, cloud save) — deferred to post-beta

**Core Scripts:**

| Script | Purpose |
|---|---|
| GameManager.cs | Game loop, scoring, lives, high score tracking |
| FoodManager.cs | Food database, unlock state, score-based unlock checks |
| FoodSpawner.cs | Physics-based food spawning with randomized forces |
| FoodItem.cs | Individual food tap detection and interaction |
| TapDetector.cs | Unity Input System touch and mouse detection |
| AudioManager.cs | Singleton audio controller, music and SFX, volume persistence |
| MainMenuManager.cs | Navigation, coin display, sound toggle |
| TrophyCaseManager.cs | Food collection grid, details popup, coin-based unlock UI |
| UnlockBannerManager.cs | Queued unlock notification banners during gameplay |
| GameOverManager.cs | Score display and navigation on game over |
| ModeSelectManager.cs | Mode selection with coming-soon handling |
| SettingsManager.cs | Volume sliders, graphics quality, attribution display |

**Design patterns used:** Singleton, ScriptableObject data model, Coroutines, PlayerPrefs persistence, Unity Event System

---

## Food Database (Current)

All foods include: name, sprite, points value, season, food group, fun fact, calories, origin, and nutrients.

| Food | Group | Season | Unlock Method |
|---|---|---|---|
| Apple | Fruit | Fall | Default (unlocked) |
| Banana | Fruit | Summer | Score: 100 points |
| Cherry | Fruit | Summer | Cost: 15 coins |
| Bell Pepper | Vegetable | Summer | Cost: 10 coins |
| Carrot | Vegetable | Fall | Cost: 25 coins |
| Cucumber | Vegetable | Summer | Score: 250 points |

---

## Compliance

| Regulation | How We Address It |
|---|---|
| COPPA (15 U.S.C. 6501-6506) | No personal data collected from under-13. Account features use local storage only. No third-party data sharing. |
| Florida Digital Bill of Rights | No precise geolocation collected. No behavioral advertising. No dark patterns. |
| Florida Gaming Laws (Ch. 849) | All in-game currency is virtual and non-transferable. No real-money purchases. No loot boxes. |
| FDUTPA | All features and pricing clearly disclosed. No deceptive design. |

---

## Audio Credits

**Music (CC-BY — attribution required):**
- "Wallpaper" by Kevin MacLeod — Main Menu
- "Anachronist" by Kevin MacLeod — Gameplay
- Licensed under Creative Commons Attribution 4.0: creativecommons.org/licenses/by/4.0/
- Source: incompetech.com

**Sound Effects (CC0 — no attribution required):**
- Interface sounds from Kenney.nl

---

## Project Team — 404 Found

| Name | Role | Concentration |
|---|---|---|
| Joshua Omorodion | Team Lead / UX Research | Cybersecurity and Data Mining |
| Kendall Hill | Co-Lead / Quality Assurance | Cybersecurity and Data Mining |
| Nigel Buggs | UX Designer / Programmer | Cybersecurity and Data Mining |
| Mike Johnson | Business Analyst / QA | Health Informatics and Data Mining |

All members are senior IT students at Florida A&M University.

---

## Budget

| Item | Cost |
|---|---|
| Unity (game engine) | $0 |
| Visual Studio (IDE) | $0 |
| Firebase (backend) | $0 (free tier) |
| Google Play Console (one-time) | $25 |
| Audio assets | $0 (CC0 / CC-BY) |
| Food art assets | $20 |
| **Total** | **$45** |

---

## Development Timeline

| Milestone | Date | Status |
|---|---|---|
| Project kickoff | Fall 2025 | Complete |
| Core gameplay (Alpha) | January 2026 | Complete |
| Audio system | February 2026 | Complete |
| Food data and unlock system | February 2026 | Complete |
| Beta build | February 2026 | In progress |
| Google Play submission | Spring 2026 | Planned |
| iOS expansion | Post-launch | Planned |

---

## Repository

Version controlled with Git. Full history available at:
**github.com/TopTierTechnologies/chopping-block**

To set up locally:
```
git clone https://github.com/TopTierTechnologies/chopping-block.git
```
Open in Unity Hub with Unity 6 (6000.3.6f1). Unity will rebuild the Library folder on first open.

---

## Roadmap (Post-Beta)

- Countdown and Quiz game modes
- Firebase authentication and cloud save
- Expanded food database (20+ items)
- Recipe book feature
- iOS release
- Educator dashboard for classroom use
- Seasonal content updates
