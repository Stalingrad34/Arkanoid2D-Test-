using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionBallStart : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameObject ball;
    [SerializeField] private SpriteRenderer arrows;

    private void Start()
    {
        Game.RestartGame += RestartGameHadler;
    }

    void Update()
    {
       //if (Input.GetMouseButton(0))
       //{
       //    target.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       //    if (target.position.y > -2.5f)
       //    {
       //        transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), (target.position - transform.position));
       //    }            
       //}
       //
       //if (Input.GetKey(KeyCode.Space))
       //{
       //    ball.GetComponent<Ball>().StartBall(transform);
       //    Game.play = true;
       //    arrows.enabled = false;
       //    //gameObject.SetActive(false);
       //}

        if (Input.touchCount > 0 && target.position.y > -2.5f && Game.play == false)
        {
            Touch touch = Input.GetTouch(0);
        
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    target.position = Camera.main.ScreenToWorldPoint(touch.position);
                    break;
        
                case TouchPhase.Moved:
                    target.position = Camera.main.ScreenToWorldPoint(touch.position);
                    transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), (target.position - transform.position));
                    break;
        
                case TouchPhase.Ended:
                    ball.GetComponent<Ball>().StartBall(transform);
                    Game.play = true;
                    arrows.enabled = false;                
                    break;
            }
        }      
    }

    private void RestartGameHadler()
    {
        transform.rotation = Quaternion.identity;
        target.position = Vector3.zero;
        arrows.enabled = true;
    }
}
