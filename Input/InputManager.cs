using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    protected PlayerInput playerInput;
    protected InputAction lookAction;
    protected InputActionAsset inputActionAsset;
    protected PlayerInputManager playerInputManager;


    private void Awake() {
        GetUnityPlayerInputManager();
    }
    protected void GetPlayerInput() {
        try {
        playerInput = GetComponent<PlayerInput>(); 
        } catch (System.Exception e) {
            Debug.LogError(e);
        }
    }

    protected void GetUnityPlayerInputManager() {
        try {
            GetComponent<PlayerInputManager>(); 
        } catch (System.Exception e) {
            Debug.LogError(e);
        }
    }



    protected Vector2 GetCameraLookInput() {
        return playerInput.actions["Look"].ReadValue<Vector2>();
    }

    protected Vector2 GetMovementInput() {
        return playerInput.actions["Move"].ReadValue<Vector2>();
    }

    public bool GetSprintInput() {
        return playerInput.actions["Sprint"].IsInProgress();
    }
    protected bool GetJumpInput() {
        return playerInput.actions["Jump"].WasPressedThisFrame();
    }

    protected string GetInputType { get { return playerInput.currentControlScheme.ToString(); } }

    protected string GetCurrentActionMap { get { return playerInput.currentActionMap.name; } }

    protected void SwitchActionMap(string actionMap) {
        playerInput.SwitchCurrentActionMap(actionMap);
    }

}
