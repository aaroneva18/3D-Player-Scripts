using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;

    private void Awake() {
        GetPlayerInput();
    }
    public void GetPlayerInput() {
        try {
        playerInput = GetComponent<PlayerInput>(); 
        } catch (System.Exception e) {
            Debug.LogError(e);
        }
    }
    public Vector3 GetMovementInput() {
        return playerInput.actions["Move"].ReadValue<Vector3>();
    }

    public bool GetSprintInput() {
        return playerInput.actions["Sprint"].WasPressedThisFrame();
    }

   

    
}
