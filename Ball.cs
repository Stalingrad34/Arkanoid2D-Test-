using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private Transform target;
    [SerializeField] private Transform direction;
    [SerializeField] private float force;

    void Start()
    {
        Game.RestartGame += RestartGameHadler;
    }

    public void StartBall(Transform direction)
    {
        rigidBody.AddForce(direction.up * force);       
        transform.parent = null;
    }

    private void RestartGameHadler()
    {
        rigidBody.velocity = Vector2.zero;
        transform.parent = player.transform;
        transform.localPosition = new Vector2(0, 1.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            collision.gameObject.GetComponent<Block>().ActionTouch();
            GetComponent<AudioSource>().Play();
        }

        if (collision.gameObject.tag == "Player")
        {
            rigidBody.velocity = Vector2.zero;
            var distance = Vector2.Distance(collision.gameObject.transform.position, transform.position);
            transform.parent = player.transform;
            if (transform.localPosition.x > 0)
            {
                target.position = new Vector2(player.transform.position.x + (distance * 5f), 0);
            }
            else
            {
                target.position = new Vector2(player.transform.position.x - (distance * 5f), 0);
            }
            transform.parent = null;
            direction.transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, 1), (target.position - direction.transform.position));
            rigidBody.AddForce(direction.up * force);
        }
    }
}
