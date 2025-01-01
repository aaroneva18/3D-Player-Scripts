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
        float mouseX = ((float)inputManager.GetAxisInput()) * senX * Time.deltaTime;
        float mouseY = ((float)inputManager.GetAxisInput()) * senY * Time.deltaTime;    
    }

    private void LockScreenCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
