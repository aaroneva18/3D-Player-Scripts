using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;

    private void Awake() {

    }

    void Start()
    {
            
    }


    void Update()
    {
        
    }

    public void GetPlayerInput() {
        if () {

        }
    }
    public Vector3 GetMovementInput() {
        return playerInput.actions["Movement"].ReadValue<Vector3>();
    }

    
}
