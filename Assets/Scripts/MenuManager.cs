using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        illuminationSlider.value = PrefsHandler.butterflyIlluminationStrength;
    }

    public void OpenSettings()
    {
        settingsPopup.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        loadingScreen.SetActive(true);
        if(illuminationSlider.value != PrefsHandler.butterflyIlluminationStrength)
        {
            PrefsHandler.butterflyIlluminationStrength = Mathf.RoundToInt(illuminationSlider.value);
        }

        SceneManager.LoadScene(sceneName);
    }
}