using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public Texture2D cursorSprite;
    public void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
}
