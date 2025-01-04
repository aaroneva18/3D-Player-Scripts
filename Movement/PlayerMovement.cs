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
        Vector2 movement = inputManager.GetMovementInput();
        Vector3 moveDirection = (movement.y * transform.forward) + (movement.x * transform.right);
        transform.position = moveDirection * CalculateCurrentSpeed() * Time.deltaTime;
    }

    public override float CalculateCurrentSpeed() {
        return currentSpeed = inputManager.GetSprintInput() ? runSpeed : walkSpeed;
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
