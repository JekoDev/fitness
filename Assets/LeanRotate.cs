using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public int RotationAxis = 0;
    public float duration;
    public bool direction;

    void Start()
    {
        switch(RotationAxis)
        {
            case 0:
                LeanTween.rotateX(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic().setLoopPingPong();
                break;
            case 1:
                LeanTween.rotateY(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic().setLoopPingPong();

                break;
            case 2:
                LeanTween.rotateZ(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic().setLoopPingPong();
                break;
                

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
