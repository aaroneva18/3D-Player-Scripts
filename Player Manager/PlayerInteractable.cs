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

        bool hasSpace = inventory.GetSize < inventory.GetMaxSize;
        if (hasSpace && StoreItemRequirements(item)) {
            inventory.AddItemToInventory(item.name, item.gameObject);
            Debug.Log("Item collected: " + item.name);

            if (IsRightHandEmpty) {
                PutObjectOnHand(RightHand, item.gameObject, true);
                item.GetComponent<Action>().ExcecuteAction(); //<- - make a input to activate the item action
            } else {
                item.gameObject.SetActive(false);
            }
        } else if (!hasSpace) {
            Debug.Log("Inventory is full");
        }
    }

    public bool StoreItemRequirements(Collider item) {
        if (item == null) { return false; }
        if (!item.TryGetComponent<ObjectManager>(out var objManager)) { return false; }
        if (item.GetComponent<ObjectManager>().GetInteractableType != InteractableType.Collectable) { return false; }
        bool canCollect = inputManager.GetCollectInput();
        if (!canCollect) { return false; }
        return true;

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
        if (item.GetComponent<ObjectManager>().GetInteractableType != InteractableType.Usable) { return; }
        Debug.Log("Interacting with item: " + item.name);
        bool canUseItem = inputManager.GetInteractInput(); 
        if (!canUseItem) { return; }

        if (canUseItem) {
            item.GetComponent<Action>().ExcecuteAction();
        }

    }

    public void ShowUI() { }

    public void ActivateItemAction(Collider item) {

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

