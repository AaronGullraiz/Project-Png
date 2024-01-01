using UnityEditor;
using UnityEditor.SceneManagement;

public class SceneLoader
{
    private static string mainmenuScenePath = "Assets/Scenes/Menu.unity";
    private static string ButterflyGameplayScenePath = "Assets/Scenes/Insect.unity";

    [MenuItem("SceneHandler/Open Splash Scene _F1")]
    static void OpenMainMenuScene()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(mainmenuScenePath);
        }
    }

    [MenuItem("SceneHandler/Open ForestGameplay Scene _F3")]
    static void OpenForestGameplayScene()
    {
        if (!EditorApplication.isPlaying && EditorApplication.SaveCurrentSceneIfUserWantsTo())
        {
            EditorSceneManager.OpenScene(ButterflyGameplayScenePath);
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