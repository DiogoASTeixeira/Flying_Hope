using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        music.volume = MainMenu.menu.volume;
        music.Play();
    }
}
