using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizationHandler : MonoBehaviour
{
    public List<TMP_Text> data;
    public List<string> valuesDE;
    public List<string> valuesEN;


    public void SetDE()
    {
        for (int i = 0; i < data.Count; i++)
        {
            data[i].text = valuesDE[i];
        }
    }
    
    public void SetEN()
    {
        for (int i = 0; i < data.Count; i++)
        {
            data[i].text = valuesEN[i];
        }
    }
}
