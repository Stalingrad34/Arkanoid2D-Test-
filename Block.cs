using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Color color;

    public virtual void ActionTouch()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<Animator>().Play("BlockBoom");
        Game.ChangeScore(100);
        Game.remainsBlock--;
        Destroy(gameObject, 0.7f);
    }
}
