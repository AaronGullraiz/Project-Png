using UnityEngine;

public static class PrefsHandler
{
    private const string butterflyIlluminationStrengthText = "butterflyIlluminationStrength";

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
}