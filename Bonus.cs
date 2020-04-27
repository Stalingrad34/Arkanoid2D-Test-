using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Bonus : MonoBehaviour
{
    [Tooltip("Speed")]
    [Range(0.0f, 2f)]
    [SerializeField] public float speed;
    private List<Block> blocks = new List<Block>();

    private void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * speed);
        if (transform.position.y < -5.5f)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var findingBlocks = FindObjectsOfType<Block>();
            if (findingBlocks != null)
            {
                blocks.AddRange(findingBlocks);
            }

            var color = new Color(1, 0, 0, 1);
            var findBlocks = blocks.Where(bl => bl.color == color);

            foreach (var block in findBlocks)
            {
                Game.remainsBlock--;
                Destroy(block.gameObject);
            }
        }

        GetComponent<AudioSource>().Play();
        GetComponent<SpriteRenderer>().enabled = false;
        Destroy(gameObject, 1);
    }
}
