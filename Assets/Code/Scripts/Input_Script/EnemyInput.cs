using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInput : EntityInput
{
    public override Vector2 GetInput()
    {
        //Move or idle
        if(UnityEngine.Random.value > 0.25f) //Move
        {
            if(UnityEngine.Random.value > 0.5f) //Up / Down
            {
                if (UnityEngine.Random.value > 0.5f)
                    return Vector2.up;
                else
                    return Vector2.down;
            }
            else //Left / Right
            {
                if (UnityEngine.Random.value > 0.5f)
                    return Vector2.left;
                else
                    return Vector2.right;
            }
        }

        return Vector2.zero; //idle
    }
}
