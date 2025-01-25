using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public PlayerInventary inventary;
    public Transform InitialPlayerPosition;
    public List<Transform> checkPoints;

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
        //TeleportTo(GetLastCheckPoint());
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

    public void TeleportTo(Transform desiredPosition) {
        if(desiredPosition == null){ 
            Debug.Warning("Desire Position is null"); 
            return;
        }
        transform.position = desirePosition.position;
    }

    public Transform GetLastCheckPoint() {
        float NearestDistance = 0;
        float ClosestCheckPoint = 0;
        List<Transform> OrderCheckPoints = new List<Transform>();
        NearestDistance = Vector3.Distance(transform.position, checkPoints[0].position);
        for (int i = 0; i < checkPoints.Count; i++) {
            ClosestCheckPoint = Vector3.Distance(transform.position, checkPoints[i].position);
            if (ClosestCheckPoint <= NearestDistance) {
                OrderCheckPoints.Add(checkPoints[i]);
                NearestDistance = ClosestCheckPoint;
            }
        }
        int finalCheckPoint =  OrderCheckPoints.Count - 1;
        return OrderCheckPoints[finalCheckPoint];
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
