using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Settings/Entity")]
public class EntityScriptable : ScriptableObject
{
    [SerializeField] public bool IsPlayer = false;
    [SerializeField] public float DirectionDelay = 0.5f;
    public EntityInput GetEntityInput() =>  IsPlayer ? new PlayerInput() : new EnemyInput();
}
