using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public enum InteractableType {
    Collectable,
    Usable,
    None
}

public class PlayerInteractable : MonoBehaviour {
    private PlayerInventary inventory;
    private InputManagerPlayer inputManager;
    private Ray ray;

    [SerializeField] private float RayLength = 0.0f;
    [SerializeField] private bool IsRightHandEmpty = true;
    [SerializeField] private bool IsLeftHandEmpty = true;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private Transform RightHand;
    [SerializeField] private Transform LeftHand;

    private void Awake() {
        SetDefaultState();
    }

    void Update() {
        InteractWithItem();
    }

    public bool GetIsRightHandEmpty { get { return IsRightHandEmpty; } }
    public bool GetIsLeftHandEmpty { get { return IsLeftHandEmpty; } }

    private void InteractWithItem() {
        Debug.DrawRay(CameraTransform.position, CameraTransform.forward * RayLength, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, RayLength, interactableLayer)) {
            ShowUI();
            StoreItem(hit.collider);
            InteractWithItem(hit.collider);
        }
    }

    public void StoreItem(Collider item) {
        if (inputManager.GetComponent<ObjectsData>().GetInteractableType != InteractableType.Collectable) { return; } 

        bool canCollect = inputManager.GetCollectInput();
        if (!canCollect) { return; }

        bool hasSpace = inventory.GetSize < inventory.GetMaxSize;

        if (hasSpace) {
            inventory.AddItemToInventory(item.name, item.gameObject);
            Debug.Log("Item collected: " + item.name);

            if (IsRightHandEmpty) {
                PutObjectOnHand(RightHand, item.gameObject, true);
            } else {
                item.gameObject.SetActive(false);
            }
        } else if (canCollect && !hasSpace) {
            Debug.Log("Inventory is full");
        }
    }

    private void PutObjectOnHand(Transform p_hand, GameObject p_object, bool IsRightHand) {
        if (p_object == null || p_hand == null) { return; }

        if ((IsRightHand && !IsRightHandEmpty) || (!IsRightHand && !IsLeftHandEmpty)) {
            Debug.Log("Hand is not empty");
            return;
        }

        Rigidbody rb = p_object.GetComponent<Rigidbody>();
        Collider c = p_object.GetComponent<Collider>();
        if (rb != null && c != null) {
            rb.isKinematic = true;
            rb.useGravity = false;
            c.enabled = false;
        }

        p_object.transform.SetParent(p_hand);
        p_object.transform.localPosition = Vector3.zero;
        p_object.transform.localRotation = Quaternion.identity;

        if (IsRightHand) {
            IsRightHandEmpty = false;
        } else {
            IsLeftHandEmpty = false;
        }

    }

    public void InteractWithItem(Collider item) {
        if (inputManager.GetComponent<ObjectsData>().GetInteractableType != InteractableType.Usable) { return; }

        bool canUseItem = inputManager.GetInteractInput(); 
        if (!canUseItem) { return; }

        item.GetComponent<Action>().ExcecuteAction();
    }

    public void ShowUI() { }

    private void SetDefaultState() {
        try {
            inventory = GetComponent<PlayerInventary>();
            inputManager = GetComponent<InputManagerPlayer>();
        } catch {
            Debug.LogError("Error setting default state at Player Interactable");
        }
    }
}
