using UnityEngine;

public static class PrefsHandler
{
    private const string butterflyIlluminationStrengthText = "butterflyIlluminationStrength";
    private const string dayDurationText = "dayDuration";
    private const string nightDurationText = "nightDuration";
    private const string dayNightSettingsText = "DayNightSetting";

    public static int butterflyIlluminationStrength 
    {
        get
        {
            return PlayerPrefs.GetInt(butterflyIlluminationStrengthText, 1);
        }
        set
        {
            PlayerPrefs.SetInt(butterflyIlluminationStrengthText, value);
        }
    }

    public static int dayDuration
    {
        get
        {
            return PlayerPrefs.GetInt(dayDurationText, 1);
        }
        set
        {
            PlayerPrefs.SetInt(dayDurationText, value);
        }
    }

    public static int nightDuration
    {
        get
        {
            return PlayerPrefs.GetInt(nightDurationText, 1);
        }
        set
        {
            PlayerPrefs.SetInt(nightDurationText, value);
        }
    }

    public static bool dayNightSettings
    {
        get
        {
            return PlayerPrefs.GetInt(dayNightSettingsText, 1)==1;
        }
        set
        {
            PlayerPrefs.SetInt(dayNightSettingsText, value?1:0);
        }
    }
}