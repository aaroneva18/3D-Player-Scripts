using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerInventary : MonoBehaviour
{
    public SerializedDictionary<string, GameObject> Inventary;

    private InputManagerPlayer inputManagerPlayer;


    private void Awake() {
        SetDefaultState();
    }
    
    void Start() {}
    
    void Update() {}

    public int GetInventarySize { get { return Inventary.Count; } }   
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

    private void SetDefaultState() {
        Inventary = new SerializedDictionary<string, GameObject>();
        inputManagerPlayer = GetComponent<InputManagerPlayer>();
    }

}
