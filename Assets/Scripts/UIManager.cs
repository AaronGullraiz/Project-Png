using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public QRManager qrManager;

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void DeleteAllFiles()
    {
        var files = Directory.GetFiles(Application.streamingAssetsPath, "*.jpg");
        foreach (var file in files)
        {
            File.Delete(file);
        }

        qrManager.DeleteAllAnimals();
    }
}