using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] _foodPrefab;
    [SerializeField] private int _borderLeft = 0;
    [SerializeField] private int _borderRight = 0;
    [SerializeField] private int _borderTop = 0;
    [SerializeField] private int _borderBottom = 0;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        InvokeRepeating("Spawn", 3f, 3f);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        if (_gameManager.CurrentState != GameState.GameInProgress)
        {
            CancelInvoke();
            return;
        }

        int x, y;

        while (true)
        {
            x = (int)Random.Range(_borderLeft, _borderRight);
            y = (int)Random.Range(_borderTop, _borderBottom);

            if (!_gameManager.FindScreenObjerct(x, y))
            {
                break;
            }
        }

        int random = Random.Range(0, _foodPrefab.Length);
        GameObject go = Instantiate(_foodPrefab[random], new Vector2(x, y), Quaternion.identity);
        _gameManager.AddScreenObject(go.transform);

    }
}
