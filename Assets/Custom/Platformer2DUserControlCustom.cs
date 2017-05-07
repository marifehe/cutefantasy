using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (Platformer2DCharacterMovement))]
	public class Platformer2DUserControlCustom : MonoBehaviour
	{
		private Platformer2DCharacterMovement m_Character;
		private bool m_Jump;
		public float h = 0;


		private void Awake()
		{
			m_Character = GetComponent<Platformer2DCharacterMovement>();
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
			if (Input.GetMouseButton (0))
			{
				//h = (Input.mousePosition.x - Screen.width / 2) / Screen.width * 2;
			} else {
				h = CrossPlatformInputManager.GetAxis ("Horizontal");
			}
			// Pass all parameters to the character control script.
			m_Character.Move(h, crouch, m_Jump);
			m_Jump = false;
		}
	}
}

