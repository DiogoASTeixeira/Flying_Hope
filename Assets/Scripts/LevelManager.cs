using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    private enum LaunchPhase
    {
        SetPower,
        SetAngle,
        Launched
    }

    public float respawnDelay;
    public PlaneController gamePlayer;
    public Text text;
    public Slider powerBar;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        gamePlayer = FindObjectOfType<PlaneController>();
    }

    public void Respawn() => StartCoroutine("RespawnCoroutine");

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        //gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
}
