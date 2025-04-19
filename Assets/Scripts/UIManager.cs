using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public CameraCurve cameraCurve;
    public QRManager qrManager;
    public Text timerTxt;

    [Header("Gameplay Walk speed Settings")]
    public Slider walkSpeedSlider, cameraCurveSlider;

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

        var files = Directory.GetFiles(Application.streamingAssetsPath+"/"+qrManager.folderName, "*.jpg");
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

    public void OnAnimalsSettingsClosed()
    {
        Time.timeScale = 1 + ((walkSpeedSlider.value * walkSpeedSlider.value) * 0.1f);
        //AnimalsSpawner.Instance.SetAnimalsSpeed(Mathf.RoundToInt(walkSpeedSlider.value));
        
        // Update Camera Curve if it's assigned
        if (cameraCurve != null)
            cameraCurve.SetCameraCurve(cameraCurveSlider.value);

        OnToggleSettings();
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    bool isSettingsEnabled = false;

    public void OnToggleSettings()
    {
        isSettingsEnabled = !isSettingsEnabled;
        foreach (var item in FindObjectsOfType<AnimalInteractionHandler>())
        {
            item.PauseResumeTouch(isSettingsEnabled);
        }
    }
}