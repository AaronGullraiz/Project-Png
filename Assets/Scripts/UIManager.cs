using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public QRManager qrManager;
    public Text timerTxt;

    public void UpdateTime(string time)
    {
        timerTxt.text = time;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void DeleteAllFiles()
    {
        AnimalsSpawner.Instance.DeleteAll();

        var files = Directory.GetFiles(Application.streamingAssetsPath, "*.jpg");
        foreach (var file in files)
        {
            File.Delete(file);
        }

        qrManager.DeleteAllAnimals();
    }

    public SchoolController school;
    public void SpawnFish(GameObject fish)
    {
        //school.Spawn(fish, transform.position, fish.transform.rotation);
        school.gameObject.SetActive(true);
    }
}