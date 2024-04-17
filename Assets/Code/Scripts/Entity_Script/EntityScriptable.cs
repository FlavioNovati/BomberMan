using UnityEngine;

[CreateAssetMenu(fileName = "New Entity", menuName = "Settings/Entity")]
public class EntityScriptable : ScriptableObject
{
    [SerializeField] public int MovementSpeed = 1;
    [SerializeField] private bool IsPlayer = false;
    [SerializeField] public float DelayBetweenInput = 0.5f;
    public EntityInput GetEntityInput() =>  IsPlayer ? new PlayerInput() : new EnemyInput();
}
