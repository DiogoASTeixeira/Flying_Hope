using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{

    public Slider volume;
    public AudioSource music;

    // Update is called once per frame
    void Update()
    {
        music.volume = volume.value;
        MainMenu.menu.volume = volume.value;
    }
}
