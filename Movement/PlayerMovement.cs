using UnityEngine;

public class PlayerMovement : Movement
{
    
    // Start is called before the first frame update
    void Start()
    {
        SetDefaultState();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    public override void Move() {
        Vector3 movement = inputManager.GetMovementInput();
        Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);
        rb.velocity = new Vector3(moveDirection.x * CalculateCurrentSpeed(), rb.velocity.y, moveDirection.z * walkSpeed);
    }

    public override float CalculateCurrentSpeed() {
        return currentSpeed = inputManager.GetSprintInput() ? runSpeed : walkSpeed;
    }

    public override void SetDefaultState() {
            rb = GetComponent<Rigidbody>();
            inputManager = GetComponent<InputManager>();
        if (rb == null || inputManager == null || walkSpeed != 0 || runSpeed != 0) { return; }
            rb = GetComponent<Rigidbody>();
            inputManager = GetComponent<InputManager>();
            walkSpeed = 5;
            runSpeed = 7;
        try{
        }catch (System.Exception e) {
            Debug.LogError(e);
        }
    }
}
