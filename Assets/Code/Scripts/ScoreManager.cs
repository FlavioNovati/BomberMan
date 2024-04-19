using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public delegate void ScoreChanged();
    public static ScoreChanged OnScoreChanged = () => { };

    public int EnemyLeft { get; private set; } = 0;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }

    private void DecreaseEnemyCounter()
    {
        EnemyLeft--;
        OnScoreChanged();
    }

    private void IncreaseEnemyCounter()
    {
        EnemyLeft++;
        OnScoreChanged();
    }

    private void OnEnable()
    {
        Entity.OnEnemyDead += DecreaseEnemyCounter;
        Entity.OnEnemyReady += IncreaseEnemyCounter;
    }

    private void OnDisable()
    {
        OnScoreChanged -= OnScoreChanged;
    }
}
