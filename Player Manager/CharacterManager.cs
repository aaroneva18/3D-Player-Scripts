using UnityEngine;

public abstract class CharacterManager : MonoBehaviour
{

    public Transform InitialCharacterPosition;

    [SerializeField] protected int health = 0;
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected bool isAlive = true;
    [SerializeField] protected bool isDead = false;

    public int GetHealth { get { return health; } }
    public int GetMaxHealth { get { return maxHealth; } }
    public bool GetIsAlive { get { return isAlive; } }
    public bool GetIsDead { get { return isDead; } }

    public abstract void Spawn();
    public abstract void Dead();
    public abstract void Respawn();
    public abstract void SetDefaultState();

    public bool IsHealthFull() {
        return health == maxHealth;
    }

    public bool IsHealthEmpty() {
        return health == 0;
    }

    public bool IsCharacterHealthy() {
        float threshold = maxHealth * 0.75f;    
        return health > threshold;
    }

    public bool IsCharacterHurt() {
        return health <= maxHealth / 2;
    }

    public void TakeDamage(int p_damage) {
        if (p_damage >= maxHealth) { Dead(); }
        health -= p_damage;
        if (health <= 0) { Dead(); }
    }

    public void Heal(int p_heal) {
        if (p_heal > maxHealth || (p_heal + health) > maxHealth) { health = maxHealth; }
        health += p_heal;
    }


}
