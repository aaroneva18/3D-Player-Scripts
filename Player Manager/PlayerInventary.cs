using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventary : MonoBehaviour {
    public SerializedDictionary<string, GameObject> Inventary;

    [SerializeField] private GameObject InventaryPanel = null;
    [SerializeField] private int MaxInventorySize = 0;
    [SerializeField] bool IsPanelActive = false;

    private InputManagerPlayer inputManger;

    private void Awake() {
        SetDefaultState();
    }

    void Start() { }

    void Update() { ActivePanelByInput(); }

    public int GetInventarySize { get { return Inventary.Count; } }
    public int GetInventoryMaxSize { get { return MaxInventorySize; } }

    public void SetMaxInventorySize(int size) {
        MaxInventorySize = size;
    }

    public GameObject GetItem(string name) {
        return Inventary[name];
    }

    public void AddItemToInventary(string name, GameObject item) {
        Inventary.Add(name, item);
    }

    public void RemoveItem(string name) {
        Inventary.Remove(name);
    }

    public void ClearInventary() {
        Inventary.Clear();
    }

    public bool HasItem(string name) {
        return Inventary.ContainsKey(name);
    }

    public void SetPanelActive(bool IsActive) {
        InventaryPanel.SetActive(IsActive);
        IsPanelActive = IsActive;
    }

    public void ActivePanelByInput() {
        if (inputManger.GetInventaryInput()) {
            if (IsPanelActive) { SetPanelActive(false); } 
            else { SetPanelActive(true); }

        } 
        //Mejor hacer un script que sea un state de abrir el inventario
    }

    private void SetDefaultState() {
        try {
            inputManger = GetComponent<InputManagerPlayer>();
            Inventary = new SerializedDictionary<string, GameObject>();
            SetPanelActive(false);
        } catch {
            Debug.LogError("Error setting default state at Player Inventary");
        }
    }

}
