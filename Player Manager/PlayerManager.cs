using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager {

    public PlayerInventary inventary;
    public List<Transform> checkPoints;

    private PlayerMovement movement;

    public void Awake() {
        SetDefaultState();
    }

    public override void Spawn() {
        movement.TeleportTo(InitialCharacterPosition);
        Heal(maxHealth);
        isAlive = true;
        isDead = false;
        movement.SetPlayable(true);
    }

    public override void Dead() {
        isAlive = false;
        isDead = true;
        movement.SetPlayable(false);
    }   

    public override void Respawn() {
        movement.TeleportTo(GetLastCheckPoint());
        Heal(maxHealth);
        isAlive = true;
        isDead = false;
        movement.SetPlayable(true);
    }

    public Transform GetLastCheckPoint() {
        float NearnestDistance = 0;
        float CurrentDistance = 0;
        List<Transform> OrderCheckPoints = new List<Transform>();
        NearnestDistance = Vector3.Distance(transform.position, checkPoints[0].position);
        for (int i = 0; i < checkPoints.Count; i++) {
            CurrentDistance = Vector3.Distance(transform.position, checkPoints[i].position);
            if (CurrentDistance <= NearnestDistance) {
                OrderCheckPoints.Add(checkPoints[i]);
                NearnestDistance = CurrentDistance;
            }
        }
        int finalCheckPoint =  OrderCheckPoints.Count - 1;
        return OrderCheckPoints[finalCheckPoint];
    }

    public override void SetDefaultState() {
        try {
            inventary = GetComponent<PlayerInventary>();
            movement = GetComponent<PlayerMovement>();
        } catch {
            Debug.LogError("Error setting default state");
        }
        
    }

}
