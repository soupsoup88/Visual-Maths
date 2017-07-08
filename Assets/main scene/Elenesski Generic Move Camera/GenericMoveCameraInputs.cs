using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Elenesski.Camera.Utilities {

    public class GenericMoveCameraInputs : MonoBehaviour {

        public bool isSlowModifier;         // Slows the movement down by a factor
        public bool isFastModifier;         // Speeds the movement up by a factor
        public bool isRotateAction;         // Indicates that the camera is rotating.
        public Vector2 RotateActionStart;   // The X,Y position where the right mouse was clicked
        public bool isLockForwardMovement;  // Turns of forward dampening while on
        public bool ResetMovement;          // Stops all movement
        public bool isPanLeft;              // Tells the system to pan left
        public bool isPanRight;             // Tells the system to pan right
        public bool isPanUp;                // Tells the system to pan up
        public bool isPanDown;              // Tells the system to pan down
        public bool isMoveForward;          // Moves the camera forward
        public bool isMoveBackward;         // Moves the camera backward
        public bool isMoveForwardAlt;       // Moves the camera forward (alternate)
        public bool isMoveBackwardAlt;      // Moves the camera backward (alternate)

        public virtual void Initialize() {
            RotateActionStart = new Vector2();
        }

        public virtual void QueryInputSystem() {

            isSlowModifier = (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl));
            isFastModifier = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
            //isRotateAction = Input.GetButton("Fire2");
			isRotateAction = true;

            // Get mouse starting point when the button was clicked.

            if ( Input.GetButtonDown("Fire2") ) {
                RotateActionStart.x = Input.mousePosition.x;
                RotateActionStart.y = Input.mousePosition.y;
            }

            isLockForwardMovement = Input.GetButton("Fire3");
            ResetMovement = Input.GetKey(KeyCode.Space);

			if (Input.GetButtonDown ("left"))
				isPanLeft = true;
			if (Input.GetButtonUp ("left"))
				isPanLeft = false;
			
			if (Input.GetButtonDown ("right"))
				isPanRight = true;
			if (Input.GetButtonUp ("right"))
				isPanRight = false;

			if (Input.GetButtonDown ("up"))
				isPanUp = true;
			if (Input.GetButtonUp ("up"))
				isPanUp = false;

			if (Input.GetButtonDown ("down"))
				isPanDown = true;
			if (Input.GetButtonUp ("down"))
				isPanDown = false;

			if (Input.GetButtonDown ("A"))
				isMoveForward = true;
			if (Input.GetButtonUp ("A"))
				isMoveForward = false;

			if (Input.GetButtonDown ("Z"))
				isMoveBackward = true;
			if (Input.GetButtonUp ("Z"))
				isMoveBackward = false;

            isMoveForwardAlt = Input.GetAxis("Mouse ScrollWheel") > 0;
            isMoveBackwardAlt = Input.GetAxis("Mouse ScrollWheel") < 0;

        }

    }
}