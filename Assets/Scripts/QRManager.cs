using CielaSpike.Unity.Barcode;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;

public class QRManager : MonoBehaviour
{
    private IBarcodeDecoder _decoder;

    private List<GameObject> spawnedAnimals;

    void Start()
    {
        _decoder = Barcode.GetDecoder();
        spawnedAnimals = new List<GameObject>();
        CheckAnimalQR();
        //InvokeRepeating(nameof(CheckAnimalQR),2,2);
    }

    void CheckAnimalQR()
    {
        var files = Directory.GetFiles(Application.streamingAssetsPath, "*.jpg");
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
            if (AnimalsSpawner.Instance.SpawnAnimal(result.Text,pic))
            {
                Debug.LogError("Animal Spawned: " + result.Text);
            }
            else
            {
                Debug.LogError("Animal Not Spawned: "+result.Text);
            }
        }
        else
        {
            Debug.LogError("Error loading pic");
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

    private void SetNewTexture(GameObject animal, Texture2D texture)
    {
        foreach (var mesh in animal.GetComponentsInChildren<SkinnedMeshRenderer>())
        {
            mesh.material.mainTexture = texture;
        }
    }

    public void DeleteAllAnimals()
    {
        foreach (var animal in spawnedAnimals)
        {
            Destroy(animal);
        }
        spawnedAnimals.Clear();
    }
}