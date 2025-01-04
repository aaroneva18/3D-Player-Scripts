using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction lookAction;
    private InputActionAsset inputActionAsset;
    


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

    public Vector2 GetMovementInput() {
        return playerInput.actions["Move"].ReadValue<Vector2>();    
    }

    public Vector2 GetCameraLookInput() {
        return playerInput.actions["Look"].ReadValue<Vector2>();
    }

    public bool GetSprintInput() {
        return playerInput.actions["Sprint"].IsInProgress();
    }
    public bool GetJumpInput() {
        return playerInput.actions["Jump"].WasPressedThisFrame();
    }

    public string GetInputType() {
        return playerInput.currentControlScheme.ToString();
    }

    public string GetCurrentActionMap() {
        return playerInput.currentActionMap.name;
    }

    public void SwitchActionMap(string actionMap) {
        playerInput.SwitchCurrentActionMap(actionMap);
    }

}
