using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBlock : Block
{
    public override void ActionTouch()
    {
        //Which block will be created next
        Game.ChangeBlock(transform.position, "RedBlock");
        Game.ChangeScore(40);
        Destroy(gameObject);
    }

}
