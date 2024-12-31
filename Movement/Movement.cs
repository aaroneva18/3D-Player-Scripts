using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Movement : MonoBehaviour {

    public bool isPlayable;

    [SerializeField] protected float walkSpeed = 0;
    [SerializeField] protected float runSpeed = 0;
    [SerializeField] protected float jumpForce = 0;
    [SerializeField] protected Rigidbody rb = null;


    protected PlayerInput playerInput = null;
    protected InputManager inputManager = null;

    private void Awake() {}
    void Start(){}
    void Update(){}

    public abstract void Move();
}
