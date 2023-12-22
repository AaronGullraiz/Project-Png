using CielaSpike.Unity.Barcode;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QRManager : MonoBehaviour
{
    private IBarcodeDecoder _decoder;

    private List<GameObject> spawnedAnimals;

    void Start()
    {
        _decoder = Barcode.GetDecoder();
        spawnedAnimals = new List<GameObject>();

        InvokeRepeating(nameof(CheckAnimalQR),2,2);
    }

    void CheckAnimalQR()
    {
        var files = Directory.GetFiles(Application.streamingAssetsPath, "*.png");
        foreach (var file in files)
        {
            LoadAnimal(file);
        }
    }

    private void LoadAnimal(string filePath)
    {
        Debug.LogError("Loading: "+filePath);
        var pic = LoadImages(filePath);
        var result = _decoder.Decode(pic.GetPixels32(), pic.width, pic.height);
        if (result.Success)
        {
            Debug.LogError(result.Text);
            var obj = Resources.Load("Animals/" + result.Text);
            if (obj != null)
            {
                if (spawnedAnimals.Count > 0 && spawnedAnimals.Find(x => x.name.Equals(result.Text)))
                {
                    Debug.LogError("Animal Already there: " + result.Text);
                }
                else
                {
                    var ob = Instantiate(obj) as GameObject;
                    ob.name = result.Text;
                    spawnedAnimals.Add(ob);
                }
            }
            else
            {
                Debug.LogError("Invalid QR Code: "+result.Text);
            }
        }
    }

    private Texture2D LoadImages(string path)
    {
        var pngBytes = System.IO.File.ReadAllBytes(path);
        Texture2D tex = new Texture2D(2, 2);
        if (tex.LoadImage(pngBytes))
        {
            return tex;
        }
        return null;
    }
}