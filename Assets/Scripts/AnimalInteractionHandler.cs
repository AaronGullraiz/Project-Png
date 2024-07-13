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

    public SkinnedMeshRenderer[] renderers;
    public MeshRenderer[] mRenderers;

    public void OnMouseEnter()
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
        foreach (var r in renderers)
        {
            r.material.mainTexture=texture;
        }

        foreach (var r in mRenderers)
        {
            r.material.mainTexture = texture;
        }
    }
}