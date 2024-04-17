using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Entity : MonoBehaviour
{
    [SerializeField] EntityScriptable EntitySettings;

    private Rigidbody2D m_RigidBody2D;
    private Movement m_Movement;
    private EntityInput m_Input;

    private float m_LastCall = 0; 

    private Vector2 direction;

    private void Awake()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_Movement = new Movement(EntitySettings.MovementSpeed, m_RigidBody2D);
        
        m_Input = EntitySettings.GetEntityInput();
    }

    private void FixedUpdate()
    {
        direction = Vector2.zero;
        
        if (EntitySettings.DelayBetweenInput + m_LastCall < Time.time)
        {
            m_LastCall = Time.time;
            direction = m_Input.GetInput();
        }

        m_Movement.UpdatePos(direction);
    }

    private void OnDrawGizmos()
    {
        if (m_RigidBody2D == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(m_RigidBody2D.position + direction, 0.25f);
    }
}
