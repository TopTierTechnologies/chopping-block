using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

/// <summary>
/// Automated setup for AudioManager GameObject and audio clip assignments
/// Run via Menu: Tools > Setup AudioManager
/// </summary>
public class AudioManagerSetup : EditorWindow
{
    [MenuItem("Tools/Setup AudioManager")]
    public static void ShowWindow()
    {
        GetWindow<AudioManagerSetup>("AudioManager Setup");
    }

    private void OnGUI()
    {
        GUILayout.Label("AudioManager Auto-Setup", EditorStyles.boldLabel);
        GUILayout.Space(10);

        GUILayout.Label("This will:", EditorStyles.wordWrappedLabel);
        GUILayout.Label("1. Create AudioManager GameObject in MainMenu scene");
        GUILayout.Label("2. Add AudioManager component");
        GUILayout.Label("3. Assign all audio clips from Assets/Audio folder");
        GUILayout.Label("4. Save the scene");
        GUILayout.Space(10);

        if (GUILayout.Button("Run Auto-Setup", GUILayout.Height(40)))
        {
            SetupAudioManager();
        }

        GUILayout.Space(10);
        GUILayout.Label("Make sure you've downloaded audio files first!", EditorStyles.helpBox);
    }

    private static void SetupAudioManager()
    {
        Debug.Log("=== Starting AudioManager Auto-Setup ===");

        // Open MainMenu scene
        Scene mainMenuScene = EditorSceneManager.OpenScene("Assets/Scenes/MainMenu.unity");
        Debug.Log("✓ Opened MainMenu scene");

        // Check if AudioManager already exists
        AudioManager existingManager = FindObjectOfType<AudioManager>();
        if (existingManager != null)
        {
            Debug.LogWarning("AudioManager already exists in scene. Updating assignments...");
            AssignAudioClips(existingManager);
            return;
        }

        // Create new GameObject
        GameObject audioManagerObj = new GameObject("AudioManager");
        Debug.Log("✓ Created AudioManager GameObject");

        // Add AudioManager component
        AudioManager audioManager = audioManagerObj.AddComponent<AudioManager>();
        Debug.Log("✓ Added AudioManager component");

        // Assign audio clips
        AssignAudioClips(audioManager);

        // Mark scene as dirty to ensure save
        EditorSceneManager.MarkSceneDirty(mainMenuScene);

        // Save scene
        EditorSceneManager.SaveScene(mainMenuScene);
        Debug.Log("✓ Saved MainMenu scene");

        // Select the AudioManager in hierarchy
        Selection.activeGameObject = audioManagerObj;

        Debug.Log("=== AudioManager Auto-Setup Complete! ===");
        EditorUtility.DisplayDialog("Success",
            "AudioManager has been created and configured!\n\n" +
            "Check the Console for details.\n\n" +
            "Press Play to test the audio.",
            "OK");
    }

    private static void AssignAudioClips(AudioManager audioManager)
    {
        Debug.Log("Searching for audio files in Assets/Audio...");

        // Load audio clips from Assets/Audio folder
        AudioClip menuMusic = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Audio/Music/MenuMusic.mp3");
        AudioClip gameplayMusic = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Audio/Music/GameplayMusic.mp3");
        AudioClip tapSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Audio/SFX/TapSound.ogg");
        AudioClip unlockSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Audio/SFX/UnlockSound.ogg");
        AudioClip gameOverSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Audio/SFX/GameOverSound.mp3");
        AudioClip buttonClick = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/Audio/SFX/ButtonClick.ogg");

        // Use SerializedObject to assign public fields (works with AudioManager's public fields)
        SerializedObject serializedManager = new SerializedObject(audioManager);

        // Assign clips if found
        if (menuMusic != null)
        {
            serializedManager.FindProperty("menuMusic").objectReferenceValue = menuMusic;
            Debug.Log("✓ Assigned MenuMusic.mp3");
        }
        else
        {
            Debug.LogWarning("✗ MenuMusic.mp3 not found at Assets/Audio/Music/MenuMusic.mp3");
        }

        if (gameplayMusic != null)
        {
            serializedManager.FindProperty("gameplayMusic").objectReferenceValue = gameplayMusic;
            Debug.Log("✓ Assigned GameplayMusic.mp3");
        }
        else
        {
            Debug.LogWarning("✗ GameplayMusic.mp3 not found at Assets/Audio/Music/GameplayMusic.mp3");
        }

        if (tapSound != null)
        {
            serializedManager.FindProperty("tapSound").objectReferenceValue = tapSound;
            Debug.Log("✓ Assigned TapSound.ogg");
        }
        else
        {
            Debug.LogWarning("✗ TapSound.ogg not found at Assets/Audio/SFX/TapSound.ogg");
        }

        if (unlockSound != null)
        {
            serializedManager.FindProperty("unlockSound").objectReferenceValue = unlockSound;
            Debug.Log("✓ Assigned UnlockSound.ogg");
        }
        else
        {
            Debug.LogWarning("✗ UnlockSound.ogg not found at Assets/Audio/SFX/UnlockSound.ogg");
        }

        if (gameOverSound != null)
        {
            serializedManager.FindProperty("gameOverSound").objectReferenceValue = gameOverSound;
            Debug.Log("✓ Assigned GameOverSound.mp3");
        }
        else
        {
            Debug.LogWarning("✗ GameOverSound.mp3 not found at Assets/Audio/SFX/GameOverSound.mp3");
        }

        if (buttonClick != null)
        {
            serializedManager.FindProperty("buttonClickSound").objectReferenceValue = buttonClick;
            Debug.Log("✓ Assigned ButtonClick.ogg");
        }
        else
        {
            Debug.LogWarning("✗ ButtonClick.ogg not found at Assets/Audio/SFX/ButtonClick.ogg");
        }

        // Apply all changes
        serializedManager.ApplyModifiedProperties();
        Debug.Log("✓ All audio clips assigned to AudioManager");
    }
}
