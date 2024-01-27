using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsSpawner : MonoBehaviour
{
    public static AnimalsSpawner Instance;

    public string folderName;

    public GameObject[] animals;

    private List<GameObject> spawnedAnimals;

    private void Awake()
    {
        spawnedAnimals = new List<GameObject>();
        Instance = this;
    }

    public bool SpawnAnimal(string name, Texture2D texture)
    {

        foreach (var animal in animals)
        {
            if(animal.name.Equals(name) && animal.transform.childCount==0)
            {
                var an = Instantiate(Resources.Load($"{folderName}/{name}"), animal.transform) as GameObject;
                an.GetComponent<SetTexture>().SetTextureOnAnimal(texture);
                spawnedAnimals.Add(an);
                return true;
            }
        }
        return false;
    }

    public void DeleteAll()
    {
        foreach (var animal in animals)
        {
            if (animal.transform.childCount > 0)
            {
                for (int i = 0; i < animal.transform.childCount; i++)
                {
                    Destroy(animal.transform.GetChild(i).gameObject);
                }
            }
        }
    }

    public void SetAnimalsSpeed(int amount)
    {
        foreach (var animal in spawnedAnimals)
        {
            animal.GetComponent<AnimalController>().SetWalkSpeed(amount);
        }
    }
}