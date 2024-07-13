using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishWebcamUpdater : EffectManager
{
    protected override void HandlePoint(Vector2 point)
    {
        base.HandlePoint(point);

        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(point), out hitInfo))
        {
            if (hitInfo.collider.tag == "Player")
            {
                hitInfo.transform.GetComponent<FishEffect>().OnMouseOver();
            }
        }
    }

    void Update()
    {
        ProcessInput(true);
    }
}