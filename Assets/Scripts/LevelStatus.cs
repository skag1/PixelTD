using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LevelStatus : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private Text playerHealthText;
    [SerializeField] private int playerHealth = 20;

    private void Start()
    {
        playerHealthText.text = playerHealth.ToString();
    }

    private void OnEnable()
    {
        EventManager.EnemyFinished += OnEnemyFinished;
    }
    private void OnDisable()
    {
        EventManager.EnemyFinished -= OnEnemyFinished;
    }
    public void OnEnemyFinished(int hpCost)
    {
        playerHealth -= hpCost;
        if(playerHealth <= 0)
        {
            playerHealth = 0;
        }
        playerHealthText.text = playerHealth.ToString();
    }

    //public void ChangeHealthText()
    //{
    //    playerHealthText.text = playerHealth.ToString();
    //}
}
