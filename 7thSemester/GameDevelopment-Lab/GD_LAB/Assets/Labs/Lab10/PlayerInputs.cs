using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Lab10{
    
public class PlayerInputs : MonoBehaviour{
    
    public Lab9.PlayerController playerController;
    public GameObject upBtn, downBtn, leftBtn, rightBtn;
    public GameObject stopBtn;
    public delegate void MovementAction(Vector3 direction);
    public delegate void StopCharacter();

    // Start is called before the first frame update
void Start(){
    if (playerController == null)
        playerController = GetComponent<Lab9.PlayerController>();

    // Define movement actions for each button
    MovementAction moveForward = playerController.MoveCharacter;
    MovementAction moveBackward = playerController.MoveCharacter;
    MovementAction moveLeft = playerController.MoveCharacter;
    MovementAction moveRight = playerController.MoveCharacter;
    StopCharacter stop = playerController.StopCharacter;

    // Set up the buttons with their respective movement directions
    SetupButtonMovement(upBtn, moveForward, Vector3.forward);
    SetupButtonMovement(downBtn, moveBackward, Vector3.back);
    SetupButtonMovement(leftBtn, moveLeft, Vector3.left);
    SetupButtonMovement(rightBtn, moveRight, Vector3.right);

    // Set up the stop button
    SetupStopButton(stopBtn, stop);
}

private void SetupButtonMovement(GameObject button, MovementAction action, Vector3 direction){
    EventTrigger trigger = button.AddComponent<EventTrigger>();
    EventTrigger.Entry entry = new EventTrigger.Entry();
    entry.eventID = EventTriggerType.PointerDown;

    // Use the delegate with a lambda to pass parameters
    entry.callback.AddListener((data) => action(direction));

    trigger.triggers.Add(entry);
}

private void SetupStopButton(GameObject button, StopCharacter stopAction){
    EventTrigger trigger = button.AddComponent<EventTrigger>();
    EventTrigger.Entry entry = new EventTrigger.Entry();
    entry.eventID = EventTriggerType.PointerDown;

    // Add the stopAction delegate directly
    entry.callback.AddListener((data) => stopAction());
    trigger.triggers.Add(entry);
}
}
}
