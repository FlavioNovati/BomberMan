using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Breakable wall", menuName = "Settings/Wall/Breakable")]
public class BreakableWallScriptable : ScriptableObject
{
    [SerializeField] public Sprite BrokenSprite;
}
