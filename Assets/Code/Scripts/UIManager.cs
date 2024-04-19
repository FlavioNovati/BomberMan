using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text EnemyLeft_Text;
    [SerializeField] private CanvasRenderer WinCanvas;
    [SerializeField] private CanvasRenderer LoseCanvas;

    private void Start()
    {
        UpdateText();
    }

    private void WinScreen()
    {
        WinCanvas.gameObject.SetActive(true);
    }

    private void LoseScreen()
    {
        LoseCanvas.gameObject.SetActive(true);
    }

    private void UpdateText()
    {
        EnemyLeft_Text.text = ScoreManager.Instance.EnemyLeft.ToString();
    }
    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += UpdateText;
        Entity.OnPlayerDead += LoseScreen;
        GameManager.OnWin += WinScreen;
        GameManager.OnLose += LoseScreen;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
