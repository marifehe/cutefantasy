using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerOnTurn : MonoBehaviour {

    public AnimationCurve curveY;
    private float halfBoxWidth;
    private float x_init;
    private float x_end;

    int totalTime = 4;
    float slope;
    float t;


    // Use this for initialization
    void Awake()
    {
    halfBoxWidth = gameObject.GetComponent<BoxCollider2D>().size[0]/2;
    x_init = gameObject.transform.position[0] - halfBoxWidth;
    x_end = gameObject.transform.position[0] + halfBoxWidth;
    }

    float distanceToTime(float d)
    {
        slope = (totalTime / x_end);
        return slope * d;
    }

    public void SetCurves(AnimationCurve yC)
    {
        curveY = yC;
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            t = distanceToTime(coll.transform.position[0]);
            coll.transform.localEulerAngles = new Vector3(0f, curveY.Evaluate(t), 0f);
        }
    }

    void Update()
    {
        
    }
   
}
