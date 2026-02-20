# PowerShell Script to Download Free Kid-Friendly Audio for The Chopping Block
# All audio is free to use (CC0 or CC-BY with attribution)

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Downloading Free Audio for The Chopping Block" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Create audio directories
$audioPath = "D:\Chopping Block\Chopping Block (1)\Assets\Audio"
$musicPath = "$audioPath\Music"
$sfxPath = "$audioPath\SFX"

Write-Host "Creating audio directories..." -ForegroundColor Yellow
New-Item -ItemType Directory -Force -Path $musicPath | Out-Null
New-Item -ItemType Directory -Force -Path $sfxPath | Out-Null
Write-Host "✓ Directories created" -ForegroundColor Green
Write-Host ""

# Download Kenney.nl Interface Sounds Pack (CC0 - Public Domain)
Write-Host "Downloading Kenney.nl Interface Sounds (CC0)..." -ForegroundColor Yellow
$kenneyUrl = "https://kenney.nl/content/3-assets/5-interface-sounds/interfacesounds.zip"
$kenneyZip = "$env:TEMP\kenney_interface_sounds.zip"
$kenneyExtract = "$env:TEMP\kenney_interface_sounds"

try {
    Invoke-WebRequest -Uri $kenneyUrl -OutFile $kenneyZip -UseBasicParsing
    Write-Host "✓ Downloaded Kenney Interface Sounds" -ForegroundColor Green

    # Extract ZIP
    Expand-Archive -Path $kenneyZip -DestinationPath $kenneyExtract -Force
    Write-Host "✓ Extracted audio pack" -ForegroundColor Green

    # Copy specific sounds we need
    Write-Host "Copying kid-friendly sound effects..." -ForegroundColor Yellow

    # Find the sounds in the extracted folder
    $kenneyAudioFolder = Get-ChildItem -Path $kenneyExtract -Recurse -Directory | Where-Object { $_.Name -like "*Audio*" -or $_.Name -like "*OGG*" } | Select-Object -First 1

    if ($kenneyAudioFolder) {
        $oggFiles = Get-ChildItem -Path $kenneyAudioFolder.FullName -Filter "*.ogg" -Recurse

        # Copy tap sound (bong or pluck - playful)
        $tapSound = $oggFiles | Where-Object { $_.Name -like "*bong_001*" -or $_.Name -like "*pluck_001*" } | Select-Object -First 1
        if ($tapSound) {
            Copy-Item $tapSound.FullName -Destination "$sfxPath\TapSound.ogg"
            Write-Host "✓ TapSound.ogg copied ($($tapSound.Name))" -ForegroundColor Green
        }

        # Copy unlock sound (confirmation - celebratory)
        $unlockSound = $oggFiles | Where-Object { $_.Name -like "*confirmation*" } | Select-Object -First 1
        if ($unlockSound) {
            Copy-Item $unlockSound.FullName -Destination "$sfxPath\UnlockSound.ogg"
            Write-Host "✓ UnlockSound.ogg copied ($($unlockSound.Name))" -ForegroundColor Green
        }

        # Copy button click sound
        $clickSound = $oggFiles | Where-Object { $_.Name -like "*click_001*" } | Select-Object -First 1
        if ($clickSound) {
            Copy-Item $clickSound.FullName -Destination "$sfxPath\ButtonClick.ogg"
            Write-Host "✓ ButtonClick.ogg copied ($($clickSound.Name))" -ForegroundColor Green
        }
    }

    # Cleanup
    Remove-Item $kenneyZip -Force
    Remove-Item $kenneyExtract -Recurse -Force

} catch {
    Write-Host "✗ Error downloading Kenney sounds: $_" -ForegroundColor Red
    Write-Host "You can manually download from: https://www.kenney.nl/assets/interface-sounds" -ForegroundColor Yellow
}

Write-Host ""

# Download Kevin MacLeod music from Incompetech (CC-BY)
Write-Host "Downloading Kevin MacLeod music from Incompetech (CC-BY)..." -ForegroundColor Yellow
Write-Host "Note: This requires attribution in your game" -ForegroundColor Yellow

# Menu Music - "Wallpaper" by Kevin MacLeod
$menuMusicUrl = "https://incompetech.com/music/royalty-free/mp3-royaltyfree/Wallpaper.mp3"
$menuMusicPath = "$musicPath\MenuMusic.mp3"

try {
    Invoke-WebRequest -Uri $menuMusicUrl -OutFile $menuMusicPath -UseBasicParsing
    Write-Host "✓ MenuMusic.mp3 downloaded (Wallpaper by Kevin MacLeod)" -ForegroundColor Green
} catch {
    Write-Host "✗ Error downloading menu music: $_" -ForegroundColor Red
    Write-Host "You can manually download from: https://incompetech.com/music/royalty-free/music.html" -ForegroundColor Yellow
}

# Gameplay Music - "Anachronist" by Kevin MacLeod
$gameplayMusicUrl = "https://incompetech.com/music/royalty-free/mp3-royaltyfree/Anachronist.mp3"
$gameplayMusicPath = "$musicPath\GameplayMusic.mp3"

try {
    Invoke-WebRequest -Uri $gameplayMusicUrl -OutFile $gameplayMusicPath -UseBasicParsing
    Write-Host "✓ GameplayMusic.mp3 downloaded (Anachronist by Kevin MacLeod)" -ForegroundColor Green
} catch {
    Write-Host "✗ Error downloading gameplay music: $_" -ForegroundColor Red
    Write-Host "You can manually download from: https://incompetech.com/music/royalty-free/music.html" -ForegroundColor Yellow
}

Write-Host ""
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Download Complete!" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

# Summary
Write-Host "Audio files downloaded to:" -ForegroundColor Green
Write-Host "  Music: $musicPath" -ForegroundColor White
Write-Host "  SFX: $sfxPath" -ForegroundColor White
Write-Host ""

Write-Host "IMPORTANT - Attribution Required:" -ForegroundColor Yellow
Write-Host "  Add this to your game's credits/about screen:" -ForegroundColor White
Write-Host '  "Music by Kevin MacLeod (incompetech.com)"' -ForegroundColor Cyan
Write-Host '  "Licensed under Creative Commons: By Attribution 4.0"' -ForegroundColor Cyan
Write-Host '  "Sound effects from Kenney.nl (CC0)"' -ForegroundColor Cyan
Write-Host ""

Write-Host "Next Steps:" -ForegroundColor Yellow
Write-Host "  1. Open Unity Editor" -ForegroundColor White
Write-Host "  2. The audio files should appear in Assets/Audio folder" -ForegroundColor White
Write-Host "  3. Follow the Unity setup instructions to assign them" -ForegroundColor White
Write-Host ""

Write-Host "Press any key to exit..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
