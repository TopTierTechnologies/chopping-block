using UnityEngine;

public static class UserDataStore
{
    private const string CoinsKey = "UserCoins";
    private const string LastScoreKey = "LastScore";
    private const string HighScoreKey = "HighScore";
    private const string MusicVolumeKey = "Audio_MusicVolume";
    private const string SfxVolumeKey = "Audio_SFXVolume";
    private const string MutedKey = "Audio_Muted";
    private const string BrightnessKey = "Display_Brightness";
    private const string GraphicsQualityKey = "Display_GraphicsQualityIndex";
    private const string LanguageKey = "Display_LanguageIndex";
    private const string FoodUnlockPrefix = "Food_Unlocked_";
    private const int DefaultCoins = 25;

    public static int GetCoins(int defaultCoins = 25)
    {
        return PlayerPrefs.GetInt(CoinsKey, defaultCoins);
    }

    public static void SetCoins(int coins)
    {
        PlayerPrefs.SetInt(CoinsKey, coins);
        PlayerPrefs.Save();
    }

    public static void AddCoins(int amount)
    {
        int currentCoins = GetCoins(DefaultCoins);
        SetCoins(currentCoins + amount);
    }

    public static bool TrySpendCoins(int amount)
    {
        int currentCoins = GetCoins(DefaultCoins);
        if (currentCoins < amount)
        {
            return false;
        }

        SetCoins(currentCoins - amount);
        return true;
    }

    public static int GetLastScore()
    {
        return PlayerPrefs.GetInt(LastScoreKey, 0);
    }

    public static void SetLastScore(int score)
    {
        PlayerPrefs.SetInt(LastScoreKey, score);
        PlayerPrefs.Save();
    }

    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    public static bool TrySetHighScore(int score)
    {
        int highScore = GetHighScore();
        if (score <= highScore)
        {
            return false;
        }

        PlayerPrefs.SetInt(HighScoreKey, score);
        PlayerPrefs.Save();
        return true;
    }

    public static float GetMusicVolume(float defaultVolume = 0.4f)
    {
        return PlayerPrefs.GetFloat(MusicVolumeKey, defaultVolume);
    }

    public static float GetSfxVolume(float defaultVolume = 0.6f)
    {
        return PlayerPrefs.GetFloat(SfxVolumeKey, defaultVolume);
    }

    public static void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(MusicVolumeKey, Mathf.Clamp01(volume));
        PlayerPrefs.Save();
    }

    public static void SetSfxVolume(float volume)
    {
        PlayerPrefs.SetFloat(SfxVolumeKey, Mathf.Clamp01(volume));
        PlayerPrefs.Save();
    }

    public static bool GetMuted()
    {
        return PlayerPrefs.GetInt(MutedKey, 0) == 1;
    }

    public static void SetMuted(bool muted)
    {
        PlayerPrefs.SetInt(MutedKey, muted ? 1 : 0);
        PlayerPrefs.Save();
    }

    public static float GetBrightness(float defaultBrightness = 1f)
    {
        return PlayerPrefs.GetFloat(BrightnessKey, defaultBrightness);
    }

    public static void SetBrightness(float brightness)
    {
        PlayerPrefs.SetFloat(BrightnessKey, Mathf.Clamp01(brightness));
        PlayerPrefs.Save();
    }

    public static int GetGraphicsQualityIndex(int defaultIndex = 0)
    {
        return PlayerPrefs.GetInt(GraphicsQualityKey, defaultIndex);
    }

    public static void SetGraphicsQualityIndex(int index)
    {
        PlayerPrefs.SetInt(GraphicsQualityKey, index);
        PlayerPrefs.Save();
    }

    public static int GetLanguageIndex(int defaultIndex = 0)
    {
        return PlayerPrefs.GetInt(LanguageKey, defaultIndex);
    }

    public static void SetLanguageIndex(int index)
    {
        PlayerPrefs.SetInt(LanguageKey, index);
        PlayerPrefs.Save();
    }

    public static bool GetFoodUnlocked(string foodName, bool defaultUnlocked)
    {
        return PlayerPrefs.GetInt(FoodUnlockPrefix + foodName, defaultUnlocked ? 1 : 0) == 1;
    }

    public static void SetFoodUnlocked(string foodName, bool unlocked)
    {
        PlayerPrefs.SetInt(FoodUnlockPrefix + foodName, unlocked ? 1 : 0);
        PlayerPrefs.Save();
    }

    // ---------------------------------------------------------------
    // PLAYER PROFILE
    // ---------------------------------------------------------------
    private const string PlayerNameKey = "User_PlayerName";
    private const string PlayerAgeRangeKey = "User_AgeRange";

    public static string GetPlayerName(string defaultName = "Player")
    {
        return PlayerPrefs.GetString(PlayerNameKey, defaultName);
    }

    public static void SetPlayerName(string name)
    {
        PlayerPrefs.SetString(PlayerNameKey, name);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Age range index: 0 = "8-9", 1 = "10-11", 2 = "12+"
    /// </summary>
    public static int GetAgeRangeIndex(int defaultIndex = 0)
    {
        return PlayerPrefs.GetInt(PlayerAgeRangeKey, defaultIndex);
    }

    public static void SetAgeRangeIndex(int index)
    {
        PlayerPrefs.SetInt(PlayerAgeRangeKey, index);
        PlayerPrefs.Save();
    }

    // ---------------------------------------------------------------
    // BACKGROUND CUSTOMIZATION
    // ---------------------------------------------------------------
    private const string SelectedBackgroundKey = "Display_SelectedBackground";

    public static int GetSelectedBackground(int defaultIndex = 0)
    {
        return PlayerPrefs.GetInt(SelectedBackgroundKey, defaultIndex);
    }

    public static void SetSelectedBackground(int index)
    {
        PlayerPrefs.SetInt(SelectedBackgroundKey, index);
        PlayerPrefs.Save();
    }
}
