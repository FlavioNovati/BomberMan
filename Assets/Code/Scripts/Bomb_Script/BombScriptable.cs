using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bomb Manager", menuName = "settings/Bomb Manager")]
public class BombScriptable : ScriptableObject
{
    [SerializeField] public Bomb BombToSpawn;
}
