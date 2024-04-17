using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bomb Manager", menuName = "Settings/Bomb/Bomb Setting")]
public class BombScriptable : ScriptableObject
{
    [SerializeField] public int ExplosionDistance = 2;
    [SerializeField] public float ExplosionDelay = 5f;
    [SerializeField] public float EndFrequency = 5f;
    [SerializeField] public float ScaleDifference = 0.25f;
    [SerializeField] public float LifeTime = 5f;
    [SerializeField] public Sprite ExplodedSprite;
}
