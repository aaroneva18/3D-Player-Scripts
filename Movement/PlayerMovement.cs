using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private Transform CameraTransform;

    private void Awake() {
        SetDefaultState();
    }

    void Update(){}

    private void FixedUpdate() {
        if (GetIsPlayable) {
            if (CheckIsGrounded()) {
                Move(); 
                MatchRotation();
            }
        }
    }

    public override void Move() {
        Vector2 input = InputPlayerManager.GetMovementInput();
        Vector3 movement = (input.y * CameraTransform.forward) + (input.x * CameraTransform.right); 
        Vector3 targetPosition = rb.position + movement * CalculateCurrentSpeed() * Time.deltaTime;
        rb.MovePosition(targetPosition);
    }

    public void MatchRotation() {
        transform.Rotate(transform.rotation.x, CameraTransform.rotation.y + transform.rotation.y, transform.rotation.z);
    }

    public override float CalculateCurrentSpeed() {
        return currentSpeed = InputPlayerManager.GetSprintInput() ? runSpeed : walkSpeed;
    }

    public override void SetDefaultState() {
        try{
            rb = GetComponent<Rigidbody>();
            InputPlayerManager = GetComponent<InputManagerPlayer>();
            if (CameraTransform == null) { GameObject.Find("Main Camera").GetComponent<Transform>(); }
            SetPlayable(true);
            walkSpeed = 5;
            runSpeed = 7;
        }catch (System.Exception e) {
            Debug.LogError(e);
        }
    }
}
