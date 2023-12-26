using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsSpawner : MonoBehaviour
{
    public static AnimalsSpawner Instance;

    public GameObject[] animals;

    private void Start()
    {
        Instance = this;
    }

    public bool SpawnAnimal(string name, Texture2D texture)
    {
        foreach (var animal in animals)
        {
            if(animal.name.Equals(name) && animal.transform.childCount==0)
            {
                var an = Instantiate(Resources.Load("Animals/" + name), animal.transform) as GameObject;
                an.GetComponent<SetTexture>().SetTextureOnAnimal(texture);
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
}