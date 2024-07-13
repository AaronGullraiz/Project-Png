using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEffect : MonoBehaviour
{


    
    public void OnMouseOver()
    {
        GetComponent<AnimalInteractionHandler>().OnMouseEnter();
    }
}
