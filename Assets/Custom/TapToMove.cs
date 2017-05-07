using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets._2D;

public class TapToMove : MonoBehaviour
{
    //flag to check if the user has tapped / clicked. 
    //Set to true on click. Reset to false on reaching destination
    private bool flag = false;
    //destination point
    private Vector3 endPoint;
    //alter this to change the speed of the movement of player / gameobject
    public float duration = 50.0f;
    //vertical position of the gameobject
    //private float yAxis;

    private PlatformerCharacter2D m_Character;
    private int m_CameraDistance;

    Vector2 mouse;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
        //mCameraDistance = m_Character.GetComponent<r>
    }
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //
        mouse = new Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        if ((Input.GetMouseButtonDown(0)))
        {
            var playerScreenPoint = Camera.main.WorldToScreenPoint(m_Character.transform.position);
            if (mouse.x < playerScreenPoint.x)
            {
                m_Character.Move(-1, false, false);
            }
            else
            {
                m_Character.Move(1, false, false);
            }
        }
    }
}
