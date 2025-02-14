using UnityEngine;
using static UnityEditor.Progress;

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
    [SerializeField] private Collider GrabbedObjectInRightHand;
    [SerializeField] private Collider GrabbedObjectInLeftHand;

    private void Awake() {
        SetDefaultState();
    }

    void Update() {
        InteractWithItem();
        PerformObjectAction(GrabbedObjectInRightHand);
    }

    public bool GetIsRightHandEmpty { get { return IsRightHandEmpty; } }
    public bool GetIsLeftHandEmpty { get { return IsLeftHandEmpty; } }

    private void InteractWithItem() {
        Debug.DrawRay(CameraTransform.position, CameraTransform.forward * RayLength, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(CameraTransform.position, CameraTransform.forward, out hit, RayLength, interactableLayer)) {
            ShowUI(hit.collider);
            StoreItem(hit.collider);    
            InteractWithItem(hit.collider);
        }
    }

    public void StoreItem(Collider item) {
        bool hasSpace = inventory.GetSize < inventory.GetMaxSize;

        if (hasSpace && StoreItemRequirements(item)) {
            inventory.AddItemToInventory(item.name, item.gameObject);
            Debug.Log("Item collected: " + item.name);
            PutObjectOnRightHand(item.gameObject);
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
    private void PutObjectOnRightHand(GameObject p_object) {
        if (p_object == null || RightHand == null) { return; }
        if (!IsRightHandEmpty || p_object.GetComponent<ObjectManager>().GetInteractableType != InteractableType.Collectable) { return; }

        Rigidbody rb = p_object.GetComponent<Rigidbody>();
        Collider c = p_object.GetComponent<Collider>();
        if (rb != null && c != null) {
            rb.isKinematic = true;
            rb.useGravity = false;
            c.enabled = false;
        }

        p_object.transform.SetParent(RightHand);
        p_object.transform.localPosition = Vector3.zero;
        p_object.transform.localRotation = Quaternion.identity;
        GrabbedObjectInRightHand = p_object.GetComponent<Collider>();
        IsLeftHandEmpty = false;
    }

    public void DropObject(Collider item) {
        if (IsRightHandEmpty || item == null) { return; }
        if (!IsRightHandEmpty && inputManager.GetCollectInput()) {
            GrabbedObjectInRightHand.transform.SetParent(null);
            Rigidbody rb = GrabbedObjectInRightHand.GetComponent<Rigidbody>();
            Collider c = GrabbedObjectInRightHand.GetComponent<Collider>();
            if (rb != null && c != null) {
                rb.isKinematic = false;
                rb.useGravity = true;
                c.enabled = true;
            }
            GrabbedObjectInRightHand = null;
            IsRightHandEmpty = true;
        }
    }

    private void PutObjectOnLeftHand(GameObject p_object) {
        if (p_object == null || LeftHand == null) { return; }
        if (!IsLeftHandEmpty) { return; }
        Rigidbody rb = p_object.GetComponent<Rigidbody>();
        Collider c = p_object.GetComponent<Collider>();

        if (rb != null && c != null) {
            rb.isKinematic = true;
            rb.useGravity = false;
            c.enabled = false;
        }

        p_object.transform.SetParent(LeftHand);
        p_object.transform.localPosition = Vector3.zero;
        p_object.transform.localRotation = Quaternion.identity;
        IsLeftHandEmpty = false;
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

    public void PerformObjectAction(Collider item) {
        if (GrabbedObjectInRightHand == null || !IsRightHandEmpty) { return; }
        if (inputManager.GetUseInput() ) {
            item.GetComponent<Action>().ExcecuteAction();
        }
    }

    public void ShowUI(Collider Item) {
        if (Item == null) { return; }
        if (Item.GetComponent<ObjectManager>().GetInteractableType == InteractableType.Collectable) {
            
        } else if (Item.GetComponent<ObjectManager>().GetInteractableType == InteractableType.Usable) {
            Debug.Log("Press E to use item");
        }


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

