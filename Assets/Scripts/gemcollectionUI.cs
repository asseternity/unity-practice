using UnityEngine;
using UnityEngine.UIElements;

public class gemcollection : MonoBehaviour
{
        public GameObject player;
        bool congratsPlayed = false;

        public void OnEnable() 
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;        
            VisualElement field = root.Q<IntegerField>("gems");
            VisualElement congrats = root.Q<Label>("congrats");
            congrats.style.display = DisplayStyle.None;
            PhysicsBehavior script = player.GetComponent<PhysicsBehavior>();
            int gems = script.gemsCollected;
        }
        public void Update()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;        
            IntegerField field = root.Q<IntegerField>("gems");
            VisualElement congrats = root.Q<Label>("congrats");
            PhysicsBehavior script = player.GetComponent<PhysicsBehavior>();
            int gems = script.gemsCollected;

            field.SetValueWithoutNotify(gems);
            if (gems == 5 && congratsPlayed == false) {
                congrats.style.display = DisplayStyle.Flex;
                Invoke("RehideCongrats", 3f);
            }
        }
        public void RehideCongrats()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;        
            VisualElement congrats = root.Q<Label>("congrats");
            congrats.style.display = DisplayStyle.None;
            congratsPlayed = true;
        }
}
