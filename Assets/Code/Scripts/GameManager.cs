using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    private void EnemyKilled()
    {

    }

    private void PlayerKilled()
    {

    }

    private void OnEnable()
    {
        Entity.OnEnemyDead += EnemyKilled;
        Entity.OnPlayerDead += PlayerKilled;
    }
}
