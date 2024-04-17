using UnityEngine;

public class PlayerInput : EntityInput
{
    public override Vector2 GetInput()
    {
        Vector2 InputDirection = Vector2.zero;

        InputDirection.x = Input.GetAxisRaw("Horizontal");
        if(InputDirection.x != 0)
            return InputDirection;

        InputDirection.y = Input.GetAxisRaw("Vertical");
        if( InputDirection.y != 0)
            return InputDirection;

        return InputDirection;
    }
}
