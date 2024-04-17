using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour, IDamageable
{

    [SerializeField] private BreakableWallScriptable m_WallSettings;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;

    private BoxCollider2D m_BoxCollider;

    private void Awake()
    {
        m_BoxCollider = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage()
    {
        
    }
}
