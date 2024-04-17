using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bomb Manager", menuName = "Settings/Bomb/Bomb Manager")]
public class BombManagerScriptable : ScriptableObject
{
    [SerializeField] public Bomb BombSettings;
}
