# 📱 Android Build Configuration - The Chopping Block
## 404-Found

---

## Quick Reference - Copy/Paste Ready

### Player Settings (Edit > Project Settings > Player > Android)

**Identification:**
```
Company Name: 404-Found
Product Name: The Chopping Block
Package Name: com.404found.choppingblock
Version: 1.0.0
Bundle Version Code: 1
```

**Other Settings:**
```
Scripting Backend: IL2CPP
API Compatibility Level: .NET Standard 2.1
Target Architectures: ARM64 ✓ (ARM64 ONLY - required by Google Play)
Minimum API Level: Android 7.0 'Nougat' (API level 24)
Target API Level: Automatic (highest installed)
```

**Publishing Settings:**
```
Build: Release
Minify: Release
Strip Engine Code: Enabled
Managed Stripping Level: Medium
Use incremental GC: Enabled
```

---

## Build Settings (Edit > Build Settings)

```
Platform: Android
Texture Compression: ASTC
Build System: Gradle
Export Project: Unchecked
```

**Active Scenes (in order):**
1. ✓ MainMenu.unity
2. ✓ Classic.unity
3. ✓ Gameplay.unity
4. ✓ Settings.unity
5. ✓ TrophyCase.unity

---

## Google Play Console Info

**Account:**
- Developer Name: 404-Found
- Registration Fee: $25 (one-time)
- URL: https://play.google.com/console

**App Listing:**
```
App Name: The Chopping Block
Short Description (80 chars max):
  "Teach kids healthy eating through fun fruit & vegetable tapping gameplay!"

Category: Educational
Target Audience: Kids (PEGI 3 / Everyone)
Content Rating: Everyone
Price: Free
```

**Store Listing Assets Needed:**
- App Icon: 512x512 PNG
- Feature Graphic: 1024x500 PNG
- Screenshots: Minimum 2, recommend 4-8 (phone + tablet)
- Promo Video: Optional (YouTube link)

---

## Keystore Info (SAVE THIS SAFELY!)

**Create New Keystore:**
```
Location: D:\Chopping Block\Chopping Block (1)\404Found_TheChoppingBlock.keystore
Keystore Password: [CREATE STRONG PASSWORD - SAVE IT!]
Alias: choppingblock
Alias Password: [CREATE STRONG PASSWORD - SAVE IT!]
```

⚠️ **CRITICAL:** Keep keystore file and passwords safe!
- You NEED this for ALL future updates
- If lost, you cannot update your app on Google Play
- Store in secure password manager + backup

---

## Attribution Text (Required in Game)

**Credits/About Screen:**
```
The Chopping Block
© 2025 404-Found

Music by Kevin MacLeod (incompetech.com)
Licensed under Creative Commons: By Attribution 4.0
http://creativecommons.org/licenses/by/4.0/

Sound effects from Kenney.nl (CC0)
https://www.kenney.nl

Made with Unity
```

---

## Build Steps (Quick Reference)

### 1. First Build - APK for Testing
```
1. File > Build Settings
2. Switch Platform to Android (wait for re-import)
3. Click "Build"
4. Save as: TheChoppingBlock_v1.0_test.apk
5. Install on Android device via USB or adb
6. Test everything works
```

### 2. Release Build - AAB for Google Play
```
1. File > Build Settings
2. Build App Bundle (Google Play)
3. Click "Build"
4. Save as: TheChoppingBlock_v1.0.aab
5. Upload to Google Play Console (Internal Testing track first)
```

---

## Testing Checklist

**Before Upload to Google Play:**
- [ ] Audio works (music, SFX, mute toggle)
- [ ] Food tapping works on touch
- [ ] Score tracking works
- [ ] Lives system works
- [ ] Food unlocking works (score + coins)
- [ ] Trophy Case displays correctly
- [ ] Coins persist after closing app
- [ ] No crashes or errors
- [ ] Runs smoothly (60 FPS target)
- [ ] Works on different screen sizes
- [ ] Adaptive icon looks good
- [ ] Splash screen displays

**Cloud Features (if enabled):**
- [ ] Cloud save syncs on WiFi
- [ ] Works offline (falls back to local)
- [ ] Analytics events sending
- [ ] No cloud-related errors

---

## Launch Timeline

**Internal Testing (1-2 weeks):**
- Upload AAB to Internal Testing track
- Invite up to 100 testers
- Get feedback, fix bugs
- Instant approval for updates

**Closed Testing (Optional):**
- Larger testing group
- More user feedback
- Test with real kids/parents

**Production Release:**
- Submit for review (1-3 days typically)
- Google reviews app
- Once approved → LIVE on Google Play!

---

## Post-Launch

**Version Updates:**
- Increment Bundle Version Code: 1 → 2 → 3 (every update)
- Update Version Name: 1.0.0 → 1.1.0 (feature updates)
- Sign with SAME keystore
- Upload new AAB to Google Play Console

**Analytics:**
- Check Unity Analytics dashboard
- Track: MAU, retention, crashes, user behavior
- Optimize based on data

**iOS Later:**
- Requires Mac + Xcode
- Apple Developer Program ($99/year)
- Similar process via App Store Connect

---

## Support & Resources

**Unity Forums:** https://forum.unity.com/
**Google Play Help:** https://support.google.com/googleplay/android-developer
**Unity Gaming Services:** https://unity.com/solutions/gaming-services

**404-Found Contact:**
(Add your support email/website here)

---

## Notes

- Package name **cannot** be changed after first upload
- Keep all builds and keystores backed up
- Test on multiple Android devices if possible
- PEGI 3/Everyone rating is appropriate for educational kids' game
- Consider adding privacy policy URL (required if collecting data)

---

**Last Updated:** 2025-02-19
**For:** The Chopping Block Beta Release
**By:** 404-Found
