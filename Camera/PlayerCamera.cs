using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private float senX;
    [SerializeField] private float senY;
    [SerializeField] private Transform orientation;

    private float xRotation;
    private float yRotation;
    private InputManager inputManager;


    private void Awake() {
        LockScreenCursor();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CameraMovement() {
        float mouseX = inputManager.GetCameraMoveInput().x * senX * Time.deltaTime;
        float mouseY = inputManager.GetCameraMoveInput().y * senY * Time.deltaTime;    

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
