using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Texture2D cursorSprite;
    public Text win;
    private float score;
    private float numCoins;
    public void Start()
    {
        score = ScoreManager.instance.getScore();
        numCoins = CoinCounter.instance.getNumCoins();

        float coinValue = 10.5f / numCoins;

        double result = Math.Round((coinValue * score) + 9.5f, 1);

        win.text = result + "! YOU DID IT";

        Cursor.visible = true;
        Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
