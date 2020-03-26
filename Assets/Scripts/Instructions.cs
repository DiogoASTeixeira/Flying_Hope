using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Instructions : MonoBehaviour
{
    public Texture2D cursorSprite;
    public void Start()
    {
        Cursor.visible = true;
        Cursor.SetCursor(cursorSprite, Vector2.zero, CursorMode.ForceSoftware);
    }

    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
