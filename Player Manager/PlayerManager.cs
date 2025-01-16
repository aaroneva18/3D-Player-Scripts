using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public PlayerInventary inventary;
    public Transform InitialPlayerPosition;

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

    public void FixedUpdate() {
        
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

    private void SetDefaultState() {
        try {
            inventary = GetComponent<PlayerInventary>();
            movement = GetComponent<PlayerMovement>();
            transform.position = InitialPlayerPosition.position;
        } catch {
            Debug.LogError("Error setting default state");
        }
        
    }
}
