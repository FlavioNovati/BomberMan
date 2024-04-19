using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public static Action<Vector2> RequestExplosion_VFX = (Vector2 pos) => { };

    public static VFXManager Instance;

    [SerializeField] private ParticleSystem ExplosionParticle;
    [SerializeField] private int PoolSize;

    private List<ParticleSystem> PoolElements = new List<ParticleSystem>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }

        RequestExplosion_VFX += PlaceVFX;
    }

    private void Start()
    {
        for(int i = 0; i < PoolSize; i++)
        {
            ParticleSystem particle = ExplosionParticle;
            PoolElements.Add(Instantiate(particle, transform.position, Quaternion.identity));
            PoolElements[i].gameObject.SetActive(false);
        }
    }

    private void PlaceVFX(Vector2 pos)
    {
        for(int i = 0; i < PoolSize; i++)
        {
            if (!PoolElements[i].gameObject.activeInHierarchy)
            {
                PoolElements[i].transform.position = pos;
                PoolElements[i].gameObject.SetActive(true);
                PoolElements[i].Play();
                return;
            }
        }
    }

    private void OnDisable()
    {
        RequestExplosion_VFX -= RequestExplosion_VFX;
    }
}
