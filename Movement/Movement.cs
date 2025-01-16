using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Movement : MonoBehaviour {

    [SerializeField] private bool isPlayable;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private float currentSpeed = 0;

    [SerializeField] protected float walkSpeed = 0;
    [SerializeField] protected float runSpeed = 0;
    [SerializeField] protected float stamina = 0;
    [SerializeField] protected float maxStamina = 0;
    [SerializeField] protected float groundGizmoRadious;
    [SerializeField] protected Vector3 velocity;
    [SerializeField] protected LayerMask groundMask;
    [SerializeField] protected Transform feet;

    protected Rigidbody rb = null;
    protected InputManagerPlayer InputPlayerManager = null;

    private void Awake(){}
    void Start(){}
    void Update(){}

    public bool GetIsPlayable { get { return isPlayable; } }    
    public float GetCurrentSpeed { get { return currentSpeed; } }   
    public float GetStamina { get { return stamina; } } 

    public abstract void SetDefaultState();
    public abstract float CalculateCurrentSpeed();
    public abstract void Move();
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
