using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleInChildren : MonoBehaviour
{
    public void Show()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<LeanScale>().Init();
            gameObject.transform.GetChild(i).GetComponent<LeanScale>().ScaleIn(i * 0.2f);
        }
    }

    public void Hide()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<LeanScale>().ScaleOut(i * 0.05f);
        }
    }
}
