using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private PlayerBehavior _playerBehavior;
    [SerializeField]
    private GameObject _gameLoopScreen, _loseScreen;
    [SerializeField]
    private TMP_Text _coinText;
    [SerializeField]
    private Button _retryButton;

    private void Start()
    {
        _playerBehavior = FindFirstObjectByType<PlayerBehavior>();

        _playerBehavior.OnCoinCollected += cointAmount => HandleCoinCollected(cointAmount);
        _retryButton.onClick.AddListener(HandleRetryButton);

        _loseScreen.SetActive(false);
        _gameLoopScreen.SetActive(true);
    }

    private void HandleCoinCollected(int cointAmount)
    {
        _coinText.text = $"Coins collected: {cointAmount}";
    }

    private void HandleRetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
