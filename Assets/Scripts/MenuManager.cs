using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Settings")]
    public GameObject settingsPopup;
    public Slider illuminationSlider,daySlider,nightSlider;
    public Toggle dayOnly, dayNight;
    public GameObject dayNightScrollers;

    [Header("Loading")]
    public GameObject loadingScreen;

    private void Start()
    {
        illuminationSlider.value = PrefsHandler.butterflyIlluminationStrength;
        SetToggles();
        daySlider.value = PrefsHandler.dayDuration;
        nightSlider.value = PrefsHandler.nightDuration;
    }

    public void OpenSettings()
    {
        settingsPopup.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        loadingScreen.SetActive(true);
        PrefsHandler.butterflyIlluminationStrength = Mathf.RoundToInt(illuminationSlider.value);
        PrefsHandler.dayDuration = Mathf.RoundToInt(daySlider.value);
        PrefsHandler.nightDuration = Mathf.RoundToInt(nightSlider.value);

        SceneManager.LoadScene(sceneName);
    }

    public void ToggleClicked(bool isDayNight)
    {
        Debug.LogError("Toggle:"+isDayNight);
        PrefsHandler.dayNightSettings = isDayNight;
        SetToggles();
    }

    private void SetToggles()
    {
        dayNightScrollers.SetActive(PrefsHandler.dayNightSettings);
    }
}