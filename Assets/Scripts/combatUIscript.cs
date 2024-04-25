using UnityEngine;
using UnityEngine.UIElements;

public class combatUIscript : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement; 
        ProgressBar healthBar = root.Q<ProgressBar>("HealthBar");
        FightingSphere playerScript = player.GetComponent<FightingSphere>();
        healthBar.value = playerScript.health;
    }
}
