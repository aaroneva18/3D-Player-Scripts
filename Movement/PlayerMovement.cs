using UnityEngine;

public class PlayerMovement : Movement
{
    
    void Start()
    {
        SetDefaultState();
    }

    void Update()
    {
        CameraMovement();
        Move();
    }

    public override void Move() {
        Vector3 movement = inputManager.GetMovementInput();
        Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);
        rb.velocity = new Vector3(moveDirection.x * CalculateCurrentSpeed(), rb.velocity.y, moveDirection.z * CalculateCurrentSpeed());
    }

    public override float CalculateCurrentSpeed() {
        return currentSpeed = inputManager.GetSprintInput() ? runSpeed : walkSpeed;
    }
    public override void CameraMovement() {
        throw new System.NotImplementedException();
    }

    public override void SetDefaultState() {
        try{
            rb = GetComponent<Rigidbody>();
            inputManager = GetComponent<InputManager>();
            walkSpeed = 5;
            runSpeed = 7;
        }catch (System.Exception e) {
            Debug.LogError(e);
        }
    }

}
