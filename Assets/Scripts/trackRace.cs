
using UnityEngine;

public class trackRace : MonoBehaviour
{
    public GameObject ch1;
    public GameObject ch2;
    public GameObject ch3;
    public GameObject ch4;
    public GameObject ch5;
    public GameObject player;
    public string raceStatus;
    void Start() {
        raceStatus = "started";
    }  
    void Update() {
        RacingSphere playerScript = player.GetComponent<RacingSphere>();
        if ( playerScript.checkpointsCollected == 5) {
            raceStatus = "finished";
        }
    }
}
