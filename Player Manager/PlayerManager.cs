using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public PlayerInventary inventary;
    public Transform InitialPlayerPosition;

    //Crear una lista de checkpoints para que el jugador pueda regresar a ellos

    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private bool isDead = false;

    private PlayerMovement movement;

    public void Awake() {
        SetDefaultState();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int GetHealth { get { return health; } }
    public int GetMaxHealth { get { return maxHealth; } }
    public bool GetIsAlive { get { return isAlive; } }
    public bool GetIsDead { get { return isDead; } }

    public void TakeDamage(int p_damage) {
        if (p_damage >= maxHealth) { Dead(); }
        health -= p_damage;
        if (health <= 0) { Dead(); }
    }

    public void Heal(int p_heal) {
        if (p_heal > maxHealth || (p_heal + health) > maxHealth) { health = maxHealth; }
        health += p_heal;
    }

    public void Dead() {
        isAlive = false;
        isDead = true;
        movement.SetPlayable(false);
    }   

    public void TeleportTo(Transform desirePosition) {
        transform.position = desirePosition.position;
    }

    public void GetLastCheckPoint() {
        /*
         * Calcular la distancia con todos los checkpoints y determinar cual es el mas cercano
         */
    }

    private void SetDefaultState() {
        try {
            inventary = GetComponent<PlayerInventary>();
            movement = GetComponent<PlayerMovement>();
            //TeleportTo(InitialPlayerPosition);
        } catch {
            Debug.LogError("Error setting default state");
        }
        
    }
}
