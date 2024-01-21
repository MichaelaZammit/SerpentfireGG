using System.Collections;
using System.Collections.Generic;

using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private TextMeshProUGUI _highScore;
    [SerializeField] private int playerIndex;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        _score.text = _gameManager.scores.score[playerIndex].ToString();
        _highScore.text = _gameManager.scores.highScore[playerIndex].ToString();
    }


}
