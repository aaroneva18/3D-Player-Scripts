using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    protected InputAction lookAction;
    protected InputActionAsset inputActionAsset;
    protected PlayerInputManager playerInputManager;
    


    private void Awake() {
        GetUnityPlayerInputManager();
    }

    protected void GetPlayerInput() {
        try {
            playerInput = GetComponent<PlayerInput>();
            Debug.Log("true");
        } catch (System.Exception e) {
            Debug.Log("false");
            Debug.LogError(e);
        }
    }

    protected void GetUnityPlayerInputManager() {
        try {
            playerInputManager = GetComponent<PlayerInputManager>(); 
        } catch (System.Exception e) {
            Debug.LogError(e);
        }
    }

    //--------------------Input Actions--------------------
    public Vector2 GetCameraLookInput() {
        return playerInput.actions["Look"].ReadValue<Vector2>();
    }

    public Vector2 GetMovementInput() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        return movement;
    }

    public bool GetSprintInput() {
        return playerInput.actions["Sprint"].IsInProgress();
    }
    public bool GetJumpInput() {
        return playerInput.actions["Jump"].WasPressedThisFrame();
    }


    //--------------------Debugging--------------------
    public string GetInputType { get { return playerInput.currentControlScheme.ToString(); } }

    public string GetCurrentActionMap { get { return playerInput.currentActionMap.name; } }

    public void SwitchActionMap(string actionMap) {
        playerInput.SwitchCurrentActionMap(actionMap);
    }

    public void DebugDevices() {
        Debug.Log(playerInput.devices);
    }

}
