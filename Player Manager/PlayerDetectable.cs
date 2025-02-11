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
        ChangeDetectionRadius();
    }

    public float GetDetectionRadius { get { return detectionRadius; } }

    public void ChangeDetectionRadius() {
        if (playerMovement.GetIsMoving) {
            IncreaseDetectionRadious(1);
        }
    }
    public void IncreaseDetectionRadious(float increasePoints) {
        if (detectionRadius < MaxDetectionRadius) {
            detectionRadius += increasePoints;
        } else {
            detectionRadius = MaxDetectionRadius;
        }
    }

    public void DecreaseDetectionRadious(float decreasePoints) {
        if (detectionRadius > 0) {
            detectionRadius -= decreasePoints;
        } else {
            detectionRadius = 0;
        }
    }

    private void SetDefaultState() {
        try {
            playerMovement = GetComponent<PlayerMovement>();
        } catch (System.Exception e) {
            Debug.LogError(e);
        }
    }

}
