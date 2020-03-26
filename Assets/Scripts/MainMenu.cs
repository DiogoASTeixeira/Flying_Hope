using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Texture2D cursorSprite;
    public float volume;
    public static MainMenu menu;
    public void Start()
    {
        if(menu == null)
        {
            menu = this;
        }
        Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void Instructions()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
