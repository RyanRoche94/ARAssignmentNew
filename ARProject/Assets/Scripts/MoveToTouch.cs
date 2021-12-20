using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTouch : MonoBehaviour
{
    void FixedUpdate()
    {

        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved && touch.phase != TouchPhase.Stationary)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, touch.position.z));
                transform.position = touchPosition;
            }
        }
    }
}
