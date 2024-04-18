using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb: MonoBehaviour
{
    public delegate void BombExploded();
    public BombExploded OnBombExploded = () => { };

    [SerializeField] private BombScriptable m_BombSettings;
    [SerializeField] private SpriteRenderer m_SpriteRenderer;
    [SerializeField] private ParticleSystem m_TriggerParticleSystem;
    
    private void Start()
    {
        StartCoroutine(ExplosionEnum());
        Vector2 spawnPos = transform.position;
        spawnPos.x = Mathf.Floor(spawnPos.x);
        spawnPos.y = Mathf.Floor(spawnPos.y);
        spawnPos += Vector2.one * 0.5f;
        transform.position = spawnPos;
    }

    private IEnumerator ExplosionEnum()
    {
        float startTime = Time.time;
        float finalTime = startTime + m_BombSettings.ExplosionDelay;
        float frequency = 1.0f;

        float enlapsedTime = 0f;

        //Expand and Shrink
        while (Time.time < finalTime)
        {
            //Frequency value
            frequency = Mathf.Lerp(0f, m_BombSettings.EndFrequency, enlapsedTime);

            //Shrink/Exand value
            float sinValue = Mathf.Sin(Time.time * frequency)+1f;
            sinValue = sinValue/2;
            m_SpriteRenderer.transform.localScale = (sinValue * m_BombSettings.ScaleDifference * Vector2.one) + Vector2.one;
            
            enlapsedTime = (Time.time - startTime)/finalTime;
            yield return null;
        }

        //Graphics Explosion
        m_SpriteRenderer.transform.localScale = Vector2.one;
        m_SpriteRenderer.sprite = m_BombSettings.ExplodedSprite;
        m_TriggerParticleSystem.gameObject.SetActive(false);
        //Check for explosion
        CheckForExplosions();
        //Send Event
        OnBombExploded();
        //Destroy After
        yield return new WaitForSeconds(m_BombSettings.LifeTime);
        Destroy(this.gameObject);
    }

    private void CheckForExplosions()
    {
        CheckDir(Vector2.up);
        CheckDir(Vector2.right);
        CheckDir(Vector2.down);
        CheckDir(Vector2.left);
    }

    private void CheckDir(Vector2 direction)
    {
        int currentDistance;
        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        RaycastHit2D raycastHit;
        
        for (currentDistance = 1; currentDistance < m_BombSettings.ExplosionDistance; currentDistance++)
        {
            Debug.DrawLine(pos, pos + (direction * currentDistance), Color.magenta, 5f);
            raycastHit = Physics2D.Raycast(transform.position, direction, currentDistance);
            //check
            if (raycastHit.collider != null)
            {
                if (raycastHit.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.TakeDamage();
                }
                return;
            }
        }
    }

    private void OnDestroy()
    {
        OnBombExploded -= OnBombExploded;
    }
}
