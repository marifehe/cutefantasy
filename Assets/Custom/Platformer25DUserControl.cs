using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(Platformer_Character_25D))]
public class Platformer25DUserControl : MonoBehaviour
{
    private Platformer_Character_25D m_Character;
    private bool m_Jump;


    private void Awake()
    {
        m_Character = GetComponent<Platformer_Character_25D>();
    }


    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float z_axis = CrossPlatformInputManager.GetAxis("Vertical");
        // Pass all parameters to the character control script.
        m_Character.Move(h, z_axis, crouch, m_Jump);
        m_Jump = false;
    }
}
