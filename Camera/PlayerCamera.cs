using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float senX;
    [SerializeField] private float senY;
    [SerializeField] private InputManagerPlayer InputManagerPlayer;

    private float xRotation;
    private float yRotation;


    private void Awake() {
        SetDefaultState();
    }

    void Update()
    {
        CameraMovement();
    }

    public void CameraMovement() {

        Vector2 lookInput = InputManagerPlayer.GetCameraLookInput();

        float mouseX = lookInput.x * Time.deltaTime * senX;
        float mouseY = lookInput.y * Time.deltaTime * senY;
        

        yRotation += mouseX;    
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
    }

    private void LockScreenCursor() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void SetDefaultState() {
        LockScreenCursor();
        try {
            InputManagerPlayer = GameObject.Find("Player").GetComponent<InputManagerPlayer>();
        } catch {
            Debug.LogError("Error setting default state");
        }
    }
}
