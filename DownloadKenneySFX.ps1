# Download Kenney SFX Pack
$sfxPath = "D:\Chopping Block\Chopping Block (1)\Assets\Audio\SFX"

Write-Host "Downloading Kenney Interface Sounds..."
$zip = "$env:TEMP\kenney_sounds.zip"
$extract = "$env:TEMP\kenney_sounds"

Invoke-WebRequest -Uri "https://kenney.nl/media/pages/assets/interface-sounds/d23a84242e-1677589452/kenney_interface-sounds.zip" -OutFile $zip -UseBasicParsing
Write-Host "Downloaded"

Expand-Archive -Path $zip -DestinationPath $extract -Force
Write-Host "Extracted"

$oggFiles = Get-ChildItem -Path $extract -Filter "*.ogg" -Recurse

# Copy tap sound
$tap = $oggFiles | Where-Object { $_.Name -match "bong_001" } | Select-Object -First 1
if ($tap) {
    Copy-Item $tap.FullName -Destination "$sfxPath\TapSound.ogg"
    Write-Host "Copied TapSound.ogg"
}

# Copy unlock sound
$unlock = $oggFiles | Where-Object { $_.Name -match "confirmation" } | Select-Object -First 1
if ($unlock) {
    Copy-Item $unlock.FullName -Destination "$sfxPath\UnlockSound.ogg"
    Write-Host "Copied UnlockSound.ogg"
}

# Copy click sound
$click = $oggFiles | Where-Object { $_.Name -match "click_001" } | Select-Object -First 1
if ($click) {
    Copy-Item $click.FullName -Destination "$sfxPath\ButtonClick.ogg"
    Write-Host "Copied ButtonClick.ogg"
}

# Cleanup
Remove-Item $zip -Force
Remove-Item $extract -Recurse -Force

Write-Host "Done! All SFX files ready."
