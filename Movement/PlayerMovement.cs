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
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (CheckIsGrounded() || GetIsPlayable) { 
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            
        }
    }
    
    public override bool CheckIsMoving() {
        return InputPlayerManager.GetMovementInput() != Vector2.zero ? true : false;
    }

    public void MatchRotation() {
        transform.Rotate(transform.rotation.x, CameraTransform.rotation.y + transform.rotation.y, transform.rotation.z);
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
