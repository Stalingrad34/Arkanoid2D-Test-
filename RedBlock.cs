using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlock : Block
{
    public override void ActionTouch()
    {
        //Which block will be created next
        Game.ChangeBlock(transform.position, "YellowBlock");
        Game.ChangeScore(30);
        Destroy(gameObject);
    }

}
