using System.Collections;
using TMPro;
using UnityEngine;

public class FoodCountdown : MonoBehaviour
{
    [SerializeField] private int _countdownTimer = 9;
    [SerializeField] private TextMeshPro _countdownText;
    [SerializeField] private int _points = 10; // Add points variable

    private GameManager _gameManager;

    public int CountdownTimer { get => _countdownTimer; set => _countdownTimer = value; }
    public int Points { get => _points; }

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        if (_gameManager.CurrentState != GameState.GameInProgress)
            return;

        StartCoroutine(Countdown());
    }

    private void Update()
    {
        _countdownText.text = CountdownTimer.ToString();
    }

    IEnumerator Countdown()
    {
        while (CountdownTimer >= 0)
        {
            yield return new WaitForSeconds(1);
            CountdownTimer--;

            if (_gameManager.CurrentState != GameState.GameInProgress)
                break;
        }

        _gameManager.RemoveScreenObject(transform);
        Destroy(gameObject);
    }
}