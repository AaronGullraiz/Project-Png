using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneLoader
{
    private static string mainmenuScenePath = "Assets/Scenes/Menu.unity";
    private static string GameplayScenePath = "Assets/Scenes/";

    [MenuItem("SceneHandler/Open Splash Scene _F1")]
    static void OpenMainMenuScene()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(mainmenuScenePath);
        }
    }

    [MenuItem("SceneHandler/Open Butterfly Gameplay Scene _F3")]
    static void OpenButterflyGameplayScene()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(GameplayScenePath+ "Insect.unity");
        }
    }

    [MenuItem("SceneHandler/Open Safari Gameplay Scene _F4")]
    static void OpenSafariGameplayScene()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(GameplayScenePath + "Safari.unity");
        }
    }

    [MenuItem("SceneHandler/PlayStop _F5")]
    private static void PlayStopButton()
    {
        if (!EditorApplication.isPlaying)
        {
            bool value = EditorApplication.SaveCurrentSceneIfUserWantsTo();
            if (value)
            {
                EditorApplication.OpenScene(mainmenuScenePath);
                EditorApplication.ExecuteMenuItem("Edit/Play");
            }
        }

    }


    [MenuItem("SceneHandler/Pause _F6")]
    private static void PauseButton()
    {
        if (EditorApplication.isPlaying)
        {
            EditorApplication.ExecuteMenuItem("Edit/Pause");
        }
    }
}