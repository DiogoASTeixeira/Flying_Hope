using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Texture2D cursorSprite;
    public void Start()
    {
        Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Options()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
