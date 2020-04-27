using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBlock : Block
{
    public override void ActionTouch()
    {
        //Which block will be created next
        Game.ChangeBlock(transform.position, "GreenBlock");
        Game.ChangeScore(20);
        Destroy(gameObject);
    }

}
