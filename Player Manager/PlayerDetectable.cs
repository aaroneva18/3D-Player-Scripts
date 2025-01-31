using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetectable : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0;
    [SerializeField] float MaxDetectionRadius = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetDetectionRadius { get { return detectionRadius; } }

    public void IncreaseDetectionRadious() {}
    public void DecreaseDetectionRadious() {}


}
