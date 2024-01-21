using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _Head;
    [SerializeField] private GameObject _Head1;
    [SerializeField] private Vector2 _StartingCorner;
    [SerializeField] private int _width = 50;
    [SerializeField] private int _height = 40;
    
    private Vector2 pos = Vector2.zero;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        GenerateWalls();
        InstantiateHead();
        InstantiateHead1();
    }

    private void InstantiateHead()
    {
        GameObject Head = Instantiate(_Head);
        pos = new Vector2(_StartingCorner.x + _width / 2, _StartingCorner.y + _height / -2);
        Head.transform.position = pos;
        
        _gameManager.AddScreenObject(Head.transform);
    }

    private void InstantiateHead1()
    {
        GameObject Head1 = Instantiate(_Head1);
        pos = new Vector2(_StartingCorner.x + _width / 2, _StartingCorner.y + _height / -2 -2f);
        Head1.transform.position = pos;

        _gameManager.AddScreenObject(Head1.transform);
    }


    private void GenerateWalls()
    {
        for (int i = 0; i < _height; i++)
        {
            Vector2 pos = new Vector2(_StartingCorner.x , _StartingCorner.y - i);
            DisplayWall(pos);
            
            pos = new Vector2(_StartingCorner.x + _width, _StartingCorner.y - i);
            DisplayWall(pos);
        }
        for(int i = 0; i < _width; i++)
        {
            Vector2 pos = new Vector2(_StartingCorner.x + i, _StartingCorner.y);
            DisplayWall(pos);
            
            pos = new Vector2(_StartingCorner.x + i, _StartingCorner.y - (_height - 1));
            DisplayWall(pos);
        }
        
    }

    private void DisplayWall(Vector2 vector2)
    {
        GameObject go = Instantiate(_wallPrefab);
        go.transform.position = vector2;
        go.transform.parent = transform;
    }
}
