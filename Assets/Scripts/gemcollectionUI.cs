using UnityEngine;
using UnityEngine.UIElements;

public class gemcollection : MonoBehaviour
{
        public GameObject player;
        public void OnEnable() 
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;        
            VisualElement field = root.Q<IntegerField>("gems");
            PhysicsBehavior script = player.GetComponent<PhysicsBehavior>();
            int gems = script.gemsCollected;
        }
        public void Update()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;        
            IntegerField field = root.Q<IntegerField>("gems");
            PhysicsBehavior script = player.GetComponent<PhysicsBehavior>();
            int gems = script.gemsCollected;

            field.SetValueWithoutNotify(gems);
        }
}
