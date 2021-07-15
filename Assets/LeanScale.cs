using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanScale : MonoBehaviour
{
    public float Duration = 1.0f;
    public void Init()
    {
        transform.localScale = new Vector3(0.0f, transform.localScale.y, transform.localScale.z);
    }

    public void ScaleIn(float delay)
    {
        LeanTween.scaleX(gameObject, 1.0f, Duration).setEaseOutCubic().setDelay(delay);
    }
    
    public void ScaleOut(float delay)
    {
        LeanTween.cancel(gameObject);
        LeanTween.scaleX(gameObject, 0.0f, Duration / 10.0f).setDelay(delay);
    }


}
