using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public delegate void GameState();
    public static GameState OnWin = () => { }, OnLose = () => { };

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        Time.timeScale = 1f;
    }

    private void EnemyKilled()
    {
        if(ScoreManager.Instance.EnemyLeft <= 0)
        {
            Time.timeScale = 0f;
            OnWin();
        }
    }

    private void PlayerKilled()
    {
        Time.timeScale = 0f;
        OnLose();
    }

    private void OnEnable()
    {
        Entity.OnEnemyDead += EnemyKilled;
        Entity.OnPlayerDead += PlayerKilled;
    }
}
