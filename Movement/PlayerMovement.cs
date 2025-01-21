using UnityEngine;

public class PlayerMovement : Movement
{
    [SerializeField] private Transform CameraTransform;

    private void Awake() {
        SetDefaultState();
    }

    private void Update() {
        
    }

    public override void Move() {
        if (GetIsPlayable) {
            Vector2 input = InputPlayerManager.GetMovementInput();
            Vector3 movement = (input.y * CameraTransform.forward) + (input.x * CameraTransform.right);
            Vector3 targetPosition = rb.position + movement * CalculateCurrentSpeed() * Time.deltaTime;
            if (CheckIsGrounded()) {
                rb.MovePosition(targetPosition);
            } 
        }
    }

    public override void Jump() {
        if (CheckIsGrounded() && GetIsPlayable) {

            Vector3 currentVelocity = rb.velocity;

            rb.velocity = new Vector3(currentVelocity.x, 0, currentVelocity.z);

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    
    public override bool CheckIsMoving() {
        return InputPlayerManager.GetMovementInput() != Vector2.zero ? true : false;
    }

    public override void SetDefaultState() {
        try{
            rb = GetComponent<Rigidbody>();
            InputPlayerManager = GetComponent<InputManagerPlayer>();
            if (CameraTransform == null) { GameObject.Find("Main Camera").GetComponent<Transform>(); }
            SetPlayable(true);
            walkSpeed = 5;
            sprintSpeed = 7;
        }catch (System.Exception e) {
            Debug.LogError(e);
        }
    }

    public override float CalculateCurrentSpeed() {
        float speed = InputPlayerManager.GetSprintInput() ? sprintSpeed : walkSpeed;
        return speed;
    }

}
