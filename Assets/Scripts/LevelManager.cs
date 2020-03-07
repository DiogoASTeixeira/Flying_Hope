using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManager : MonoBehaviour
{
    private float timer;

    public float respawnDelay;
    public PlaneController gamePlayer;
    public Text text;
    public Slider powerBar;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlaneController>();
        text.text = "0";
        ResetTimeCounter();
        powerBar.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
        powerBar.value = 1 - Mathf.Abs(Mathf.Sin(timer + 90*Mathf.Deg2Rad));
    }

    public void Respawn() => StartCoroutine("RespawnCoroutine");

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        //gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }

    public void ResetTimeCounter() => timer = 0f;

    private void CountTime() => timer += Time.deltaTime;
}
