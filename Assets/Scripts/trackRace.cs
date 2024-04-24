using UnityEngine;
using UnityEngine.InputSystem;
using System;
using System.Diagnostics;

public class trackRace : MonoBehaviour
{
    public GameObject ch1;
    public GameObject ch2;
    public GameObject ch3;
    public GameObject ch4;
    public GameObject ch5;
    public GameObject player;
    public string raceStatus;
    public string elapsedTime;
    public InputAction resetButton;
    Stopwatch stopwatch = new Stopwatch();
    private void OnEnable() { resetButton.Enable(); }
    private void OnDisable() { resetButton.Disable(); }
    void Start() 
    {
        raceStatus = "started";
        stopwatch.Start();
    }  
    void Update() 
    {
        RacingSphere playerScript = player.GetComponent<RacingSphere>();
        if ( playerScript.checkpointsCollected == 5) {
            raceStatus = "finished";
        }
        RacingStopwatch();
        buttonPressed = false;
        ResetRace();
    }
    void RacingStopwatch()
    {
        TimeSpan ts = stopwatch.Elapsed;
        elapsedTime = String.Format("{0:00}:{1:00}", ts.Seconds, ts.Milliseconds / 10);
        if (raceStatus == "finished") {
            stopwatch.Stop();
        }
    }
    bool buttonPressed = false;
    void ResetRace()
    {
        float resetPressed = resetButton.ReadValue<float>();
        if (resetPressed > 0) {
            UnityEngine.Debug.Log("reset pressed");
            if (!buttonPressed) {
                RacingSphere playerScript = player.GetComponent<RacingSphere>();
                playerScript.ReturnToStart();
                stopwatch.Reset();
                stopwatch.Start();
                raceStatus = "started";
                playerScript.checkpointsCollected = 0;
                ch1.SetActive(true);
                ch2.SetActive(true);
                ch3.SetActive(true);
                ch4.SetActive(true);
                ch5.SetActive(true);
                buttonPressed = true;
            }
        }
    }
}
