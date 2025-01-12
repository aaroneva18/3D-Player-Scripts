using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public PlayerInventary inventary;
    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private bool isAlive = true;
    [SerializeField] private bool isDead = false;



    public void Awake() {
        SetDefaultState();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetHealth { get { return health; } }
    public int GetMaxHealth { get { return maxHealth; } }
    public bool GetIsAlive { get { return isAlive; } }
    public bool GetIsDead { get { return isDead; } }

    private void SetDefaultState() {
        try {
            inventary = GetComponent<PlayerInventary>();

        } catch {
            Debug.LogError("Error setting default state");
        }
        
    }
}
