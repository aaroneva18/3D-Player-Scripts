using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float senX;
    [SerializeField] private float senY;
    [SerializeField] private Transform orientation;
    [SerializeField] private InputManager inputManager;

    private float xRotation;
    private float yRotation;


    private void Awake() {
        LockScreenCursor();

    }
    void Start()
    {
        
    }

    void Update()
    {
        CameraMovement();
    }

    public void CameraMovement() {

        Vector2 lookInput = inputManager.GetCameraLookInput();

        float mouseX = lookInput.x * Time.deltaTime * senX;
        float mouseY = lookInput.y * Time.deltaTime * senY;
        

        yRotation += mouseX;    
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void LockScreenCursor() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
