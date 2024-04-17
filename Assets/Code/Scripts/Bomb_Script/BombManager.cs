using UnityEngine;

public class BombManager : MonoBehaviour
{
    [SerializeField] private BombScriptable Settings;

    private Bomb BombtToSpawn;

    private bool CanSpawn = true;

    private void Awake()
    {
        BombtToSpawn = Settings.BombToSpawn;
        BombtToSpawn.OnBombExploded += EnableSpawn;
    }

    private void Update()
    {
        if(CanSpawn)
            if (Input.GetKeyDown(KeyCode.Escape))
                Spawm();
    }

    private void Spawm()
    {

    }

    private void EnableSpawn()
    {

    }
}
