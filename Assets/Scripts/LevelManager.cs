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
    private LaunchPhase launchPhase;

    private float timer;
    private float launchPower, launchAngle;

    public float respawnDelay;
    public PlaneController gamePlayer;
    public Text text;
    public Slider powerBar;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlaneController>();
        text.text = "0";
        ResetTimer();

        launchAngle = 0f;
        launchPower = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (launchPhase != LaunchPhase.Launched)
        {
            PlaneLauncher();
        }*/
    }
    /*
    private void PlaneLauncher()
    {
        switch (launchPhase)
        {
            case LaunchPhase.SetPower:
                CountTime();
                powerBar.value = 1 - Mathf.Abs(Mathf.Sin(timer + 90 * Mathf.Deg2Rad));

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    launchPower = powerBar.value;
                    ResetTimer();
                    launchPhase = LaunchPhase.SetAngle;
                }
                break;
            case LaunchPhase.SetAngle:
                CountTime();
                gamePlayer.transform.localEulerAngles = new Vector3(0, 0, 90 * (1 - Mathf.Abs(Mathf.Cos(timer))));
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    launchAngle = 90 * (1 - Mathf.Abs(Mathf.Cos(timer)));
                    gamePlayer.SetKinematic(false);
                    gamePlayer.LaunchPlane(launchPower, launchAngle);
                    launchPhase = LaunchPhase.Launched;
                }
                break;
        }
    }*/

    public void ResetTimer()
    {
        timer = 0f;
    }

    private void CountTime() => timer += Time.deltaTime;

    public void Respawn() => StartCoroutine("RespawnCoroutine");

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        //gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
    }
}
