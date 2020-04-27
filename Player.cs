using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{   
    [SerializeField] private Transform targetMove;


    void Update()
    {
        if (Input.touchCount > 0 && Game.play == true)
        {
            transform.position = new Vector2(targetMove.position.x, transform.position.y);
            Touch touch = Input.GetTouch(0);
            
            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    targetMove.position = Camera.main.ScreenToWorldPoint(touch.position);
                    break;
            }
        }
    }

}
