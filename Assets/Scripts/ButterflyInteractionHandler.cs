using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyInteractionHandler : AnimalInteractionHandler
{
    public SkinnedMeshRenderer[] meshes;
    private ITweenMagic tween;

    private void Awake()
    {
        tween = GetComponent<ITweenMagic>();

        clickEvent.AddListener(OnButterflyClicked);
    }

    private void OnButterflyClicked()
    {
        if (TimeManager.Instance.IsDay)
        {
            if (transform.localScale.x == 1)
                tween.PlayForwardScale();
            else
                tween.PlayReverseScale();
        }
        else
        {
            foreach (var mesh in meshes)
            {
                mesh.GetComponent<Animator>().SetBool("Emit", !mesh.GetComponent<Animator>().GetBool("Emit"));
            }
        }
    }

    public override void SetTexture(Texture2D texture)
    {
        foreach (var mesh in meshes)
        {
            Debug.LogWarning("Setting texture: "+mesh.gameObject.name);
            mesh.material.mainTexture = texture;
        }
    }
}