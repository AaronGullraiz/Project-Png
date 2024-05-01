using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Settings")]
    public GameObject settingsPopup;
    public Slider illuminationSlider;

    [Header("Loading")]
    public GameObject loadingScreen;

    [Header("Togglers")]
    public GameObject toggleObject;
    public string[] scenesList;

    private List<GameObject> togglers;

    private void Start()
    {
        illuminationSlider.value = PrefsHandler.butterflyIlluminationStrength;

        togglers = new List<GameObject>();
        toggleObject.GetComponent<MenuSceneDayNightToggleHandler>().Setup(scenesList[0]);
        togglers.Add(toggleObject);
        for (int i = 1; i < scenesList.Length; i++)
        {
            var obj = Instantiate(toggleObject, toggleObject.transform.parent) as GameObject;
            obj.GetComponent<MenuSceneDayNightToggleHandler>().Setup(scenesList[i]);
            togglers.Add(obj);
        }
    }

    public void OpenSettings()
    {
        settingsPopup.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        loadingScreen.SetActive(true);
        PrefsHandler.butterflyIlluminationStrength = Mathf.RoundToInt(illuminationSlider.value);
        SaveDayNightToggleData();
        SceneManager.LoadScene(sceneName);
    }

    private void SaveDayNightToggleData()
    {
        foreach (var item in togglers)
        {
            item.GetComponent<MenuSceneDayNightToggleHandler>().SaveData();
        }
    }
}