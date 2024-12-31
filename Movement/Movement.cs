using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {

    public bool isPlayable;

    [SerializeField] protected float walkSpeed = 0;
    [SerializeField] protected float runSpeed = 0;
    [SerializeField] protected float jumpForce = 0;
    [SerializeField] protected Rigidbody rb = null;

    [SerializeField] protected PlayerInput playerInput = null;

    private void Awake() {}
    void Start(){}
    void Update(){}

    private void Move() {
        
    }
}
