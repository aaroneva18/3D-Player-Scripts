using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

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

    public Vector2 GetCameraMoveInput() {
        return playerInput.actions["CameraMove"].ReadValue<Vector2>();
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
