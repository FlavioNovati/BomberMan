using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField] private BombManagerScriptable Settings;

    private Bomb BombToSpawn;

    private bool CanSpawn = true;

    private void Awake()
    {
        BombToSpawn = Settings.BombSettings;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CanSpawn)
            Spawm();
    }

    private void Spawm()
    {
        CanSpawn = false;
        Bomb newBomb = BombToSpawn;
        newBomb = Instantiate(newBomb, transform.position, Quaternion.identity);
        newBomb.OnBombExploded += EnableSpawn;
    }

    private void EnableSpawn()
    {
        CanSpawn = true;
    }
}
