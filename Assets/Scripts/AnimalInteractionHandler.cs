using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices;

public class AnimalInteractionHandler : MonoBehaviour
{

[DllImport("user32.dll")]
static extern bool SetCursorPos(int X, int Y);

public UnityEvent clickEvent;

    private void OnMouseUp()
    {
        clickEvent.Invoke();

        SetCursorPos(0, Screen.height);//Call this to set the mouse position
    }

    public void SetParent(Transform ob)
    {
        ob.parent = transform.parent;
    }

    public virtual void SetTexture(Texture2D texture)
    {

    }
}