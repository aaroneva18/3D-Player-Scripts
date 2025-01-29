using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    private PlayerInventary inventary;
    private InputManagerPlayer inputManger;
    private Ray ray;

    [SerializeField] private float RayLenght = 0.0f;
    [SerializeField] private bool IsRightHandEmpty = true;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private Transform RightHand;

    private void Awake() {
        SetDefaultState();
    }

    void Update()
    {
        InteractWithItem();
    }

    private void InteractWithItem() {
        Debug.DrawRay(CameraTransform.position, CameraTransform.forward * RayLenght, Color.red);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, RayLenght, interactableLayer)) {
            //Aqui deberia de mostar la UI
            if (inputManger.GetCollectInput() && inventary.GetInventarySize < inventary.GetInventoryMaxSize) {
                inventary.AddItemToInventary(hit.collider.gameObject.name, hit.collider.gameObject);
                if (IsRightHandEmpty) {
                    PutObjectOnRightHand(hit.collider.gameObject);
                } 
            } 
            else if(inputManger.GetCollectInput() && inventary.GetInventarySize >= inventary.GetInventoryMaxSize) {
                Debug.Log("Inventary is full");
            }
        }
    }

    private void PutObjectOnRightHand(GameObject p_object) {
        if (p_object == null || RightHand == null) { return; }

        Rigidbody rb = p_object.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        //agregar la rotacion de la camara
        p_object.transform.SetParent(RightHand); 
        p_object.transform.localPosition = Vector3.zero; 
        p_object.transform.localRotation = Quaternion.identity;
    }

    private void SetDefaultState() {
        try {
            inventary = GetComponent<PlayerInventary>();
            inputManger = GetComponent<InputManagerPlayer>();
        } catch {
            Debug.LogError("Error setting default state at Player Interactable");
        }
    }
}
