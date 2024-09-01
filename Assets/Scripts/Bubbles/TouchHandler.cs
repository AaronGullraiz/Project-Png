using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHandler : MonoBehaviour
{
    Tweener tween;

    public Vector2 xVarient;

    public float yVal, floatingTime;

    bool hasTouched;

    public BubbleHandler parentObj;

    void OnEnable()
    {
        transform.position = transform.parent.position;
        tween = transform.DOMove(new Vector3(transform.parent.position.x+Random.Range(xVarient.x, xVarient.y), yVal, transform.parent.position.z), floatingTime)
            .OnComplete(()=> { tween = null; gameObject.SetActive(false); hasTouched = false; });
    }

    private void OnDisable()
    {
        transform.localScale = Vector3.one * -1;

        if (tween != null)
        {
            tween.Kill();
            tween = null;
        }
    }

    private void OnMouseEnter()
    {
        if (!hasTouched && tween != null)
        {
            hasTouched = true;
            transform.DOShakeScale(0.25f, 1f, 20);
            GetComponent<AudioSource>().Play();
            tween.timeScale = parentObj.touchSpeed;
        }
    }
}