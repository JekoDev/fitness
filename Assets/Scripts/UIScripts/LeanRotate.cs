using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public int RotationAxis = 0;
    public float duration;
    public bool direction;
    public bool loop = true;

    void Start()
    {
        switch(RotationAxis)
        {
            case 0:
                if(loop)
                    LeanTween.rotateX(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic().setLoopPingPong();
                else
                    LeanTween.rotateX(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic();
                break;
            case 1:
                if(loop)
                    LeanTween.rotateY(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic().setLoopPingPong();
                else
                    LeanTween.rotateY(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic();
                break;
            case 2:
                if(loop)
                    LeanTween.rotateZ(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic().setLoopPingPong();
                else
                    LeanTween.rotateZ(gameObject, 200.0f * (direction ? -1 : 1), duration).setEaseOutCubic();
                break;
                

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
