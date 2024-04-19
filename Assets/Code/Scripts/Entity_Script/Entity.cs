using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class Entity : MonoBehaviour, IDamageable
{
    public delegate void EntityDead();
    public static EntityDead OnEnemyDead = () => { };
    public static EntityDead OnPlayerDead = () => { };

    public delegate void EntityReady();
    public static event EntityReady OnEnemyReady = () => { };

    [SerializeField] EntityScriptable EntitySettings;

    private Rigidbody2D m_RigidBody2D;
    private Movement m_Movement;
    private EntityInput m_Input;

    private float m_LastCall = 0; 
    private Vector2 m_Direction;

    public void TakeDamage()
    {
        if (EntitySettings.IsPlayer)
            OnPlayerDead();
        else
            OnEnemyDead();

        this.gameObject.SetActive(false);
    }

    private void Awake()
    {
        m_RigidBody2D = GetComponent<Rigidbody2D>();
        m_Movement = new Movement(EntitySettings.DirectionDelay, m_RigidBody2D);
        
        m_Input = EntitySettings.GetEntityInput();
    }

    private void Start()
    {
        if(!EntitySettings.IsPlayer)
            OnEnemyReady();
    }

    private void FixedUpdate()
    {
        m_Direction = m_Input.GetInput();

        if(m_Direction != Vector2.zero)
            if (EntitySettings.DirectionDelay + m_LastCall < Time.time)
            {
                m_LastCall = Time.time;
                if (m_Movement.CanMove(m_Direction))
                    StartCoroutine(m_Movement.Move());
            }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 startPos = transform.position;
        startPos.x = Mathf.Floor(startPos.x);
        startPos.y = Mathf.Floor(startPos.y);
        startPos += Vector2.one * 0.5f;
        transform.position = startPos;
    }

    private void OnDestroy()
    {
        OnEnemyDead -= OnEnemyDead;
        OnPlayerDead -= OnPlayerDead;
    }
}
