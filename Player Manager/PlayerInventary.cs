using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventary : MonoBehaviour {
    public SerializedDictionary<string, GameObject> Inventory;

    [SerializeField] private GameObject InventaryPanel = null;
    [SerializeField] private int MaxInventorySize = 0;
    [SerializeField] bool IsPanelActive = false;

    private InputManagerPlayer inputManger;

    private void Awake() {
        SetDefaultState();
    }

    void Start() { }

    void Update() { }

    public int GetSize { get { return Inventory.Count; } }
    public int GetMaxSize { get { return MaxInventorySize; } }
    public bool GetIsPanelActive { get { return IsPanelActive; } }

    public void SetMaxInventorySize(int size) {
        MaxInventorySize = size;
    }

    public GameObject GetItem(string name) {
        return Inventory[name];
    }

    public void AddItemToInventory(string name, GameObject item) {
        Inventory.Add(name, item);
    }

    public void RemoveItem(string name) {
        Inventory.Remove(name);
    }

    public void ClearInventary() {
        Inventory.Clear();
    }

    public bool HasItem(string name) {
        return Inventory.ContainsKey(name);
    }

    public void SetPanelActive(bool IsActive) {
        InventaryPanel.SetActive(IsActive);
        IsPanelActive = IsActive;
    }


    private void SetDefaultState() {
        try {
            inputManger = GetComponent<InputManagerPlayer>();
            Inventory = new SerializedDictionary<string, GameObject>();
            SetPanelActive(false);
        } catch {
            Debug.LogError("Error setting default state at Player Inventary");
        }
    }

}
