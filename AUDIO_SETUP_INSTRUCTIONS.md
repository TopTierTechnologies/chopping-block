# 🎵 Audio Setup Instructions - The Chopping Block

## ✅ What's Already Done (By Claude)

- ✅ Created **AudioManager.cs** (singleton audio controller)
- ✅ Integrated audio into **4 game scripts** (FoodItem, MainMenuManager, GameManager, UnlockBannerManager)
- ✅ Created **PowerShell download script** (DownloadAudio.ps1)
- ✅ Created **Unity Editor setup script** (Assets/Scripts/Editor/AudioManagerSetup.cs)
- ✅ Imported **GameOverSound.mp3** (your provided file)
- ✅ Created folder structure (Assets/Audio/Music, Assets/Audio/SFX)

---

## 🚀 Quick Setup (Choose ONE Option)

### **Option A: Automated (Recommended - 2 minutes)**

**Step 1: Download Audio Files**
1. Right-click `DownloadAudio.ps1` in File Explorer
2. Select **"Run with PowerShell"**
3. Wait for download to complete (auto-downloads free kid-friendly audio)
4. Press any key to close

**Step 2: Auto-Setup in Unity**
1. Open Unity Editor
2. Go to **Tools > Setup AudioManager** (menu at top)
3. Click **"Run Auto-Setup"** button
4. Done! AudioManager is configured

**Step 3: Test**
1. Press **Play** in Unity
2. Listen for menu music
3. Navigate to Gameplay scene → tap foods → hear sounds
4. Lose all lives → hear gentle game over sound

---

### **Option B: With Unity MCP (Claude Can Do It All!)**

If you want Claude to handle EVERYTHING automatically:

**Step 1: Install Unity MCP Server**
1. Open Unity Editor
2. Go to **Window > Package Manager**
3. Click **+ (Add package from git URL)**
4. Paste: `https://github.com/CoplayDev/unity-mcp.git?path=/MCPForUnity#main`
5. Press Enter, wait for import
6. Go to **Window > MCP for Unity**
7. Click **Start Server**
8. Select **"Claude Desktop"** from dropdown
9. Click **Configure**
10. Tell Claude: "Unity MCP is ready!"

**Step 2: Claude Does Everything**
Claude can now:
- Download audio files
- Create AudioManager GameObject
- Assign all audio clips
- Test and verify
- Fix any errors

---

## 📁 File Locations

**Audio Files (After Download):**
```
Assets/Audio/
├── Music/
│   ├── MenuMusic.mp3 (Wallpaper by Kevin MacLeod)
│   └── GameplayMusic.mp3 (Anachronist by Kevin MacLeod)
└── SFX/
    ├── TapSound.ogg (Kenney.nl - bong/pluck sound)
    ├── UnlockSound.ogg (Kenney.nl - confirmation sound)
    ├── ButtonClick.ogg (Kenney.nl - click sound)
    └── GameOverSound.mp3 (Your provided sound)
```

**Code Files:**
```
Assets/Scripts/
├── AudioManager.cs (Main audio controller)
├── FoodItem.cs (Modified - plays tap sound)
├── MainMenuManager.cs (Modified - plays menu music, toggle mute)
├── GameManager.cs (Modified - plays gameplay music, game over sound)
├── UnlockBannerManager.cs (Modified - plays unlock sound)
└── Editor/
    └── AudioManagerSetup.cs (Auto-setup tool)
```

---

## 🎓 Attribution Required

**You MUST add this to your game's credits/about screen:**

```
Music by Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 4.0 License
http://creativecommons.org/licenses/by/4.0/

Sound effects from Kenney.nl (CC0)
https://www.kenney.nl
```

---

## 🐛 Troubleshooting

**PowerShell script won't run?**
- Right-click script → Properties → Check "Unblock" → Apply
- Or run PowerShell as Administrator

**No audio in Unity?**
- Check AudioManager GameObject exists in MainMenu scene
- Check audio clips are assigned in Inspector
- Check volume isn't muted (AudioManager settings)
- Check your computer volume is up

**Download failed?**
- Manually download from:
  - Kenney: https://www.kenney.nl/assets/interface-sounds
  - Music: https://incompetech.com/music/royalty-free/music.html

**Editor script not showing?**
- Wait for Unity to compile scripts
- Check Console for errors
- Refresh Assets folder (Ctrl+R)

---

## ✨ What Happens When You Play

1. **MainMenu Scene:**
   - Menu music plays automatically
   - Sound toggle button mutes/unmutes

2. **Gameplay Scene:**
   - Gameplay music starts when game begins
   - Tap foods → hear cheerful tap sound
   - Unlock new food → hear celebratory sound
   - Run out of lives → hear gentle game over sound (kid-friendly)

3. **Educational Experience:**
   - All sounds are positive and encouraging
   - Audio reinforces healthy food interaction
   - No scary or punishing sounds
   - Upbeat but not distracting from learning

---

## 📱 Next Steps (Beta Release)

After audio is working:
1. Set up Unity Gaming Services (Cloud Save + Analytics)
2. Configure Android build settings
3. Create Google Play Console account ($25)
4. Build and test on Android device
5. Submit to Play Store beta testing

**Company Info for Android Build:**
- Company Name: **404-Found**
- Package Name: **com.404found.choppingblock**
- Product Name: **The Chopping Block**

Full plan: `C:\Users\josho\.claude\plans\cryptic-churning-alpaca.md`

---

## 💬 Need Help?

If you run into issues, Claude can:
- Debug errors in Console
- Fix code issues
- Explain what's happening
- Help with next steps

Just describe the problem and share any error messages!
