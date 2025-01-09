using UnityEngine;

public class PlayerMovement : Movement
{
    private void Awake() {
        SetDefaultState();
    }

    void Update(){}

    private void FixedUpdate() {
        Move();
    }

    public override void Move() {
        Vector2 movement = InputPlayerManager.GetMovementInput();
        Vector3 moveDirection = (movement.y * transform.forward) + (movement.x * transform.right);
        rb.AddForce(moveDirection.normalized * CalculateCurrentSpeed() * 10f, ForceMode.Force);
    }

    public override float CalculateCurrentSpeed() {
        return currentSpeed = InputPlayerManager.GetSprintInput() ? runSpeed : walkSpeed;
    }

    public override void SetDefaultState() {
        try{
            rb = GetComponent<Rigidbody>();
            InputPlayerManager = GetComponent<InputManagerPlayer>();
            walkSpeed = 5;
            runSpeed = 7;
        }catch (System.Exception e) {
            Debug.LogError(e);
        }
    }
}
