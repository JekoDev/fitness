using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGParticleSystem : MonoBehaviour
{
    public List<Sprite> particles = new List<Sprite>();
    public GameObject parent;
    GameObject NewObj;
    float period = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnParticle();
    }

    private void SpawnParticle()
    {
        NewObj = new GameObject(); //Create the GameObject
        Image NewImage = NewObj.AddComponent<Image>(); //Add the Image Component script
        int index = Random.Range(0, 3);
        Debug.Log(index);
        NewImage.color = new Color(NewImage.color.r, NewImage.color.g, NewImage.color.b, Random.Range(.01f, .2f));
        NewImage.sprite = particles[index]; //Set the Sprite of the Image Component on the new GameObject
        NewObj.GetComponent<RectTransform>().SetParent(parent.transform); //Assign the newly created Image GameObject as a Child of the Parent Panel.
        NewObj.GetComponent<RectTransform>().position = new Vector3(0.0f -300.0f, Random.Range(-50.0f, Screen.height / 4), 0.0f);
        float randomScale = Random.Range(4f, 6.0f);
        NewObj.GetComponent<RectTransform>().localScale = new Vector3(randomScale, randomScale, 1.0f);
        NewObj.SetActive(true); //Activate the GameObject
        NewObj.transform.SetSiblingIndex(0);
        LeanTween.move(NewObj, new Vector3(Screen.width + 300.0f, Random.Range(0.0f, Screen.height / 1.5f), 0.0f), Random.Range(30.0f, 50.0f)).setDestroyOnComplete(true);
        LeanTween.rotate(NewObj, new Vector3(Random.Range(-90.0f, 270.0f), Random.Range(-90.0f, 270.0f), Random.Range(-90.0f, 270.0f)), Random.Range(20.0f, 40.0f)).setLoopPingPong();
    }

    // Update is called once per frame
    void Update()
    {
        if (period > 6f)
        {
            SpawnParticle();
            period = 0;
        }
        period += UnityEngine.Time.deltaTime;
    }
}
