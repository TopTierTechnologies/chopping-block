# Simple Audio Download Script for The Chopping Block
# Downloads free kid-friendly audio files

Write-Host "Downloading audio files for The Chopping Block..." -ForegroundColor Cyan
Write-Host ""

# Paths
$audioPath = "D:\Chopping Block\Chopping Block (1)\Assets\Audio"
$musicPath = "$audioPath\Music"
$sfxPath = "$audioPath\SFX"

# Create directories
Write-Host "Creating directories..." -ForegroundColor Yellow
New-Item -ItemType Directory -Force -Path $musicPath | Out-Null
New-Item -ItemType Directory -Force -Path $sfxPath | Out-Null
Write-Host "Done" -ForegroundColor Green
Write-Host ""

# Download Music Files from Incompetech
Write-Host "Downloading music from Incompetech..." -ForegroundColor Yellow

try {
    # Menu Music - Wallpaper
    Invoke-WebRequest -Uri "https://incompetech.com/music/royalty-free/mp3-royaltyfree/Wallpaper.mp3" -OutFile "$musicPath\MenuMusic.mp3" -UseBasicParsing
    Write-Host "Downloaded MenuMusic.mp3" -ForegroundColor Green
} catch {
    Write-Host "Failed to download MenuMusic.mp3" -ForegroundColor Red
}

try {
    # Gameplay Music - Anachronist
    Invoke-WebRequest -Uri "https://incompetech.com/music/royalty-free/mp3-royaltyfree/Anachronist.mp3" -OutFile "$musicPath\GameplayMusic.mp3" -UseBasicParsing
    Write-Host "Downloaded GameplayMusic.mp3" -ForegroundColor Green
} catch {
    Write-Host "Failed to download GameplayMusic.mp3" -ForegroundColor Red
}

Write-Host ""

# Download Kenney Sound Pack
Write-Host "Downloading Kenney sound pack..." -ForegroundColor Yellow

try {
    $kenneyZip = "$env:TEMP\kenney_sounds.zip"
    Invoke-WebRequest -Uri "https://kenney.nl/content/3-assets/5-interface-sounds/interfacesounds.zip" -OutFile $kenneyZip -UseBasicParsing
    Write-Host "Downloaded Kenney pack" -ForegroundColor Green

    # Extract
    $extractPath = "$env:TEMP\kenney_sounds"
    Expand-Archive -Path $kenneyZip -DestinationPath $extractPath -Force
    Write-Host "Extracted Kenney pack" -ForegroundColor Green

    # Find OGG files
    $oggFiles = Get-ChildItem -Path $extractPath -Filter "*.ogg" -Recurse

    # Copy tap sound
    $tapSound = $oggFiles | Where-Object { $_.Name -match "bong_001" } | Select-Object -First 1
    if ($tapSound) {
        Copy-Item $tapSound.FullName -Destination "$sfxPath\TapSound.ogg"
        Write-Host "Copied TapSound.ogg" -ForegroundColor Green
    }

    # Copy unlock sound
    $unlockSound = $oggFiles | Where-Object { $_.Name -match "confirmation" } | Select-Object -First 1
    if ($unlockSound) {
        Copy-Item $unlockSound.FullName -Destination "$sfxPath\UnlockSound.ogg"
        Write-Host "Copied UnlockSound.ogg" -ForegroundColor Green
    }

    # Copy button click
    $clickSound = $oggFiles | Where-Object { $_.Name -match "click_001" } | Select-Object -First 1
    if ($clickSound) {
        Copy-Item $clickSound.FullName -Destination "$sfxPath\ButtonClick.ogg"
        Write-Host "Copied ButtonClick.ogg" -ForegroundColor Green
    }

    # Cleanup
    Remove-Item $kenneyZip -Force
    Remove-Item $extractPath -Recurse -Force

} catch {
    Write-Host "Error with Kenney pack: $_" -ForegroundColor Red
    Write-Host "You can manually download from https://www.kenney.nl/assets/interface-sounds" -ForegroundColor Yellow
}

Write-Host ""
Write-Host "Audio download complete!" -ForegroundColor Cyan
Write-Host ""
Write-Host "Files are in: $audioPath" -ForegroundColor White
Write-Host ""
Write-Host "REMEMBER TO ADD CREDITS:" -ForegroundColor Yellow
Write-Host "Music by Kevin MacLeod (incompetech.com) - CC BY 4.0" -ForegroundColor White
Write-Host "Sounds from Kenney.nl - CC0" -ForegroundColor White
Write-Host ""
Write-Host "Press any key to exit..." -ForegroundColor Gray
$null = $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
