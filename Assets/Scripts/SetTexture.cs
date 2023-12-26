using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTexture : MonoBehaviour
{
    public AnimalInteractionHandler animalBody;

    public void SetTextureOnAnimal(Texture2D texture)
    {
        animalBody.SetTexture(texture);
    }
}