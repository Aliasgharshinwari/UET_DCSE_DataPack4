using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;

namespace OEL{
    
public class PlayerInputsOEL : MonoBehaviour{
    
    public PlayerControllerOEL playerController;
    //public GameObject upBtn, downBtn, leftBtn, rightBtn;
    //public GameObject stopBtn;
    public delegate void MovementAction(Vector3 direction);
    public delegate void StopCharacter();

    // Start is called before the first frame update
void Start(){
    if (playerController == null)
        playerController = GetComponent<PlayerControllerOEL>();

}

}
}
