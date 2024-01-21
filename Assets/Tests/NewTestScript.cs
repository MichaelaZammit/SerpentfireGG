using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Score1Tests
{
    [Test]
    public void Score1_Update_SetsTextToGameManagerScore()
    {
        // Arrange
        GameObject go = new GameObject();
        Score1 scoreScript = go.AddComponent<Score1>();
        GameManager gameManager = go.AddComponent<GameManager>();
        TextMeshProUGUI textMeshProUGUI = go.AddComponent<TextMeshProUGUI>();

        scoreScript._score1 = textMeshProUGUI;
        scoreScript.Awake();

        // Act
        gameManager.Score = 42;
        scoreScript.Update();

        // Assert
        Assert.AreEqual("42", textMeshProUGUI.text);
    }
}

