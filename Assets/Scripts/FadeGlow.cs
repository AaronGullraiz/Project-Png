using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeGlow : MonoBehaviour
{
    private float speed = 0.5f;

    public MeshRenderer[] meshes;
    public SkinnedMeshRenderer[] skinnedMeshes;

    private Coroutine routine;

    public void StartGlow()
    {
        if (routine == null)
        {
            routine = StartCoroutine(Glow());
        }
    }

    IEnumerator Glow()
    {
        Color c = Color.yellow;
        while (c!=Color.black)
        {
            c.r = Mathf.MoveTowards(c.r, 0, Time.deltaTime * speed);
            c.g = Mathf.MoveTowards(c.g, 0, Time.deltaTime * speed);
            c.b = Mathf.MoveTowards(c.b, 0, Time.deltaTime * speed);
            SetColor(c);
            yield return new WaitForFixedUpdate();
        }

        routine = null;
    }

    private void SetColor(Color c)
    {
        foreach (var mesh in meshes)
        {
            mesh.material.EnableKeyword("_EMISSION");
            mesh.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            mesh.material.SetColor("_EmissionColor", c);
            //mesh.material.color = c;
        }
        foreach (var mesh in skinnedMeshes)
        {
            mesh.material.EnableKeyword("_EMISSION");
            mesh.material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;
            mesh.material.SetColor("_EmissionColor", c);
            //mesh.material.color = c;
        }
    }
}