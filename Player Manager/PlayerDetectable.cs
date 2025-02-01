using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectable : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0;
    [SerializeField] float MaxDetectionRadius = 0;


    private PlayerMovement playerMovement;

    private void Awake() {
        SetDefaultState();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public float GetDetectionRadius { get { return detectionRadius; } }

    public void ChangeDetectionRadius() {

    }
    public void IncreaseDetectionRadious(float increasePoints) {}
    public void DecreaseDetectionRadious(float decreasePoints) {}

    private void SetDefaultState() {
        try {
            playerMovement = GetComponent<PlayerMovement>();
        } catch (System.Exception e) {
            Debug.LogError(e);
        }
    }

}
