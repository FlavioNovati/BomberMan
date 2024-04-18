using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Movement
{
    private float m_AnimationSpeed;
    private Rigidbody2D m_Rigidbody2D;

    private Vector2 m_Direction;

    public Movement(float animationSpeed, Rigidbody2D body)
    {
        m_AnimationSpeed = animationSpeed;
        m_Rigidbody2D = body;
    }
    
    public bool CanMove(Vector2 direction)
    {
        m_Direction = direction;
        if (!Physics2D.OverlapCircle(m_Rigidbody2D.position + m_Direction, 0.25f))
        {
            //m_Rigidbody2D.position += direction;
            return true;
        }
        return false;
    }

    public IEnumerator Move()
    {
        float progress = 0f;
        Vector2 startPos = m_Rigidbody2D.position;
        startPos.x = Mathf.Floor(startPos.x);
        startPos.y = Mathf.Floor(startPos.y);
        startPos += Vector2.one * 0.5f;
        Vector2 endPos = startPos + m_Direction;

        while(progress < 1f)
        {
            m_Rigidbody2D.position = Vector2.Lerp(startPos, endPos, progress);
            progress += Time.deltaTime*m_AnimationSpeed;
            yield return null;
        }
    }
}
