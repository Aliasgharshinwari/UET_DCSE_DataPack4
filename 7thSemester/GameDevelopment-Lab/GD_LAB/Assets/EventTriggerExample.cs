using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventTriggerExample : MonoBehaviour
{

    public Transform btn;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(SimpleFunc);
        EventTrigger ev = btn.AddComponent<EventTrigger>();

        EventTrigger.Entry customEvent = new EventTrigger.Entry();
        customEvent.eventID = EventTriggerType.PointerDown;
        customEvent.callback.AddListener(PrintOne);  

        ev.triggers.Add(customEvent);  
    }

    void PrintOne(BaseEventData x){
        btn.transform.position = x.currentInputModule.transform.position;
        Debug.Log("One");
    }

    void SimpleFunc(){
        Debug.Log("New");
    }
}
