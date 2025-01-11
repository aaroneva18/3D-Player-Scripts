using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Movement : MonoBehaviour {

    public bool isPlayable;

    [SerializeField] protected float walkSpeed = 0;
    [SerializeField] protected float runSpeed = 0;
    [SerializeField] protected float currentSpeed = 0;
    [SerializeField] protected bool isGrounded = false;
    [SerializeField] protected Vector3 velocity;
    [SerializeField] protected Rigidbody rb = null;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected Transform feet;
    [SerializeField] protected float groundGizmoRadious;


    protected InputManagerPlayer InputPlayerManager = null;

    private void Awake(){}
    void Start(){}
    void Update(){}

    public abstract void SetDefaultState();
    public abstract float CalculateCurrentSpeed();
    public abstract void Move();
    public bool CheckIsGrounded() {
        return isGrounded = Physics.CheckSphere(feet.position, groundGizmoRadious, groundMask);
    }

}
