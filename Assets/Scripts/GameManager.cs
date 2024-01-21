using System.Collections;
using System.Collections.Generic;
using System.Linq;

using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;

    private List<Transform> _screenObjects = new List<Transform>();
    private GameState _currentState;

    public Scores scores = new Scores();

    public GameState CurrentState { get { return _currentState; } }


    private void Awake()
    {
        SetGameState(GameState.GameInProgress);
        scores = SaveData.Load();
        scores.SetScore(0, 0);
        scores.SetScore(1, 0);
    }

    public void SetGameState(GameState gameState)
    {
        _currentState = gameState;

        switch (gameState)
        {
            case GameState.GameInProgress:
                _gameOver.SetActive(false);
                break;
            case GameState.GameOver:
                _gameOver.SetActive(true);
                break;

            default: break;
        }
    }

    public void AddScreenObject(Transform transform)
    {
        _screenObjects.Add(transform);
    }

    public void RemoveScreenObject(Transform transform)
    {
        _screenObjects.Remove(transform);
    }

    public bool FindScreenObjerct(float posx, float posy)
    {
        Transform objtransform = _screenObjects.Where(x => x.position.x == posx && x.position.y == posy).FirstOrDefault();
        if (objtransform)
            return true;

        return false;
    }

    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestory()
    {
        SaveData.Save(scores);
    }
}