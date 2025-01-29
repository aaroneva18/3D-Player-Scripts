using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractableType {
    Collectable,
    Usable,
    None
}

public class PlayerInteractable : MonoBehaviour
{
    private PlayerInventary inventory;
    private InputManagerPlayer inputManager;
    private Ray ray;

    [SerializeField] private float RayLength = 0.0f;
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
        Debug.DrawRay(CameraTransform.position, CameraTransform.forward * RayLength, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, RayLength, interactableLayer)) {
            ShowUI();
            StoreItem(hit.collider);
        }
    }

    public void StoreItem(Collider item) {
        bool canCollect = inputManager.GetCollectInput();
        bool hasSpace = inventory.GetSize < inventory.GetMaxSize;

        if (canCollect && hasSpace) {
            inventory.AddItemToInventory(item.gameObject.name, item.gameObject);

            if (IsRightHandEmpty) {
                PutObjectOnRightHand(item.gameObject);
            } else {
                item.gameObject.SetActive(false);
            }
        } else if (canCollect && !hasSpace) {
            Debug.Log("Inventory is full");
        }
    }

    public void ShowUI() {

    }

    private void PutObjectOnRightHand(GameObject p_object) {
        if (p_object == null || RightHand == null) { return; }

        IsRightHandEmpty = false;
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
            inventory = GetComponent<PlayerInventary>();
            inputManager = GetComponent<InputManagerPlayer>();
        } catch {
            Debug.LogError("Error setting default state at Player Interactable");
        }
    }
}
