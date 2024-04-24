using UnityEngine;
using UnityEngine.UIElements;

public class raceUIscript : MonoBehaviour
{
    public GameObject raceTracker;
    void Update()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement; 
        Label status = root.Q<Label>("RaceStatus");
        Label timer = root.Q<Label>("Timer");
        trackRace script = raceTracker.GetComponent<trackRace>();
        if (script.raceStatus == "started") {
            status.text = "Race Started! Collect all checkpoints!";
        } else if (script.raceStatus == "finished" ) {
            status.text = "Race Finished!";
        }
        timer.text = script.elapsedTime;
    }
}
