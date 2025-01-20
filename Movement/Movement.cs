using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Movement : MonoBehaviour {

    [SerializeField] private bool isPlayable = false;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float currentSpeed = 0;

    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected float walkSpeed = 0;
    [SerializeField] protected float sprintSpeed = 0;
    [SerializeField] protected float stamina = 0;
    [SerializeField] protected float maxStamina = 0;
    [SerializeField] protected float groundGizmoRadious = 0;
    [SerializeField] protected Vector3 velocity = new Vector3();
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected Transform feet;

    protected Rigidbody rb = null;
    protected InputManagerPlayer InputPlayerManager = null;

    private void Awake(){}
    void Start(){}
    void Update(){}

    public bool GetIsPlayable { get { return isPlayable; } }    
    public bool GetIsMoving { get { return CheckIsMoving(); } }
    public bool GetIsGrounded { get { return CheckIsGrounded(); } }
    public float GetCurrentSpeed { get { return currentSpeed; } } 
    public float GetWalkSpeed { get { return walkSpeed; } }
    public float GetSprintSpeed { get { return sprintSpeed; } }
    public float GetStamina { get { return stamina; } } 

    public abstract void SetDefaultState();
    public abstract void Move();
    public abstract void Jump();
    public abstract float CalculateCurrentSpeed();
    public abstract bool CheckIsMoving();
    public bool CheckIsGrounded() {
        return isGrounded = Physics.CheckSphere(feet.position, groundGizmoRadious, groundMask);
    }
    public void SetPlayable(bool p_IsPlayable) {
        isPlayable = p_IsPlayable;
    }
    public void SetCurrentSpeed(float speed) {
        currentSpeed = speed;
    }

    public void ReduceStamina(float ReducePoints) {
        stamina -= ReducePoints;
        if (stamina <= 0) { stamina = 0; }
    }

    public void IncreaseStamina(float IncreasePoints) {
        if (stamina >= maxStamina) { stamina = maxStamina; }
        stamina += IncreasePoints;
    }

    public void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(feet.position, groundGizmoRadious);
    }

}
