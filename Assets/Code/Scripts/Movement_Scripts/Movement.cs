using UnityEngine;

public class Movement
{
    private int m_AnimationSpeed;
    private Rigidbody2D m_Rigidbody2D;

    public Movement(int animationSpeed, Rigidbody2D body)
    {
        m_AnimationSpeed = animationSpeed;
        m_Rigidbody2D = body;
    }

    //TODO: Fancy Movement
    //TODO: Flip Sprite
    public bool UpdatePos(Vector2 direction)
    {
        if (!Physics2D.OverlapCircle(m_Rigidbody2D.position + direction, 0.25f))
        {
            m_Rigidbody2D.position += direction;
            return true;
        }

        return false;
    }
}
