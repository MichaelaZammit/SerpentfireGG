using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private GameObject _tailPrefab;
    [SerializeField] private float _snakeSpeed = 0.3f;
    [SerializeField] private int playerIndex = 0;

    private PlayerInput _controls;
    private InputAction _movement;

    private Vector2 _currentDirection = Vector2.right;
    private float _movementSpeed = 0.3f;
    private float _moveTimer = 0f;
    private GameManager _gameManager;

    private List<Transform> _tails = new List<Transform>();
    private bool _foodEaten;

    private void Awake()
    {
        _controls = GetComponent<PlayerInput>();
        _movement = _controls.currentActionMap.FindAction("Movement");

        _gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (_gameManager.CurrentState != GameState.GameInProgress)
            return;

        var position = Vector2.zero;

        _moveTimer += Time.deltaTime;

        if(_moveTimer >= _movementSpeed)
        {
            _moveTimer = 0f;
            Vector3 previousPosition = transform.position;
            position += _currentDirection;

            if(_foodEaten)
            {
                GameObject tail = Instantiate(_tailPrefab, previousPosition, Quaternion.identity);
                _tails.Insert(0, tail.transform);
                _gameManager.AddScreenObject(tail.transform);
                _foodEaten = false;

                if (_snakeSpeed > .035f)
                {
                    _snakeSpeed -= .0025f;
                }
            }
            else if(_tails.Count > 0)
            {
                _tails.Last().position = previousPosition;
                _tails.Insert(0, _tails.Last());
                _tails.RemoveAt(_tails.Count - 1);
            }
        }

        transform.Translate(position);
    }

    private void OnEnable()
    {
        _movement.performed += Movement;
    }

    private void OnDisable()
    {
        _movement.performed -= Movement;
    }

    private void Movement(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();


        if (Vector2.Dot(direction, _currentDirection) == -1)
            return;

        // if x > 0 then rotate to face right
        // if x < 0 then rotate to face left
        _currentDirection = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Food"))
        {
            if (collision.TryGetComponent<FoodCountdown>(out FoodCountdown foodComponent))
            {
                _gameManager.scores.SetScore(playerIndex, _gameManager.scores.score[playerIndex] + foodComponent.CountdownTimer + 1);
                int[] scores = new int[2];
                FoodEaten(collision);
            }
        }
        if (collision.CompareTag("Wall") || collision.CompareTag("Snake"))
        {
            _gameManager.SetGameState(GameState.GameOver);
        }
    }

    private void FoodEaten(Collider2D collision)
    {
        _gameManager.RemoveScreenObject(collision.gameObject.transform);
        Destroy(collision.gameObject);
        _foodEaten = true;
    }
}