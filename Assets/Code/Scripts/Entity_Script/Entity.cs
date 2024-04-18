using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] EntityScriptable EntitySettings;

    private Rigidbody2D m_RigidBody2D;
    private Movement m_Movement;
    private EntityInput m_Input;

    private float m_LastCall = 0; 
    private Vector2 m_Direction;

    public void TakeDamage()
    {
        Destroy(this.gameObject);
    }

    private void Awake()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_Movement = new Movement(EntitySettings.MovementSpeed, m_RigidBody2D);
        
        m_Input = EntitySettings.GetEntityInput();
    }

    private void FixedUpdate()
    {
        m_Direction = Vector2.zero;
        
        if (EntitySettings.DelayBetweenInput + m_LastCall < Time.time)
        {
            m_LastCall = Time.time;
            m_Direction = m_Input.GetInput();
            if (m_Movement.CanMove(m_Direction))
                StartCoroutine(m_Movement.Move());
        }
    }
}
