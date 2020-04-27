using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBlock : Block
{
    public override void ActionTouch()
    {
        //Which block will be created next
        Game.ChangeBlock(transform.position, "SimpleBlock");
        Game.ChangeScore(10);
        Destroy(gameObject);
    }

}
