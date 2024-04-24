using UnityEngine;
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
    Stopwatch stopwatch = new Stopwatch();
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
    }
    void RacingStopwatch()
    {
        TimeSpan ts = stopwatch.Elapsed;
        elapsedTime = String.Format("{0:00}:{1:00}", ts.Seconds, ts.Milliseconds / 10);
        if (raceStatus == "finished") {
            stopwatch.Stop();
        }
    }
}
