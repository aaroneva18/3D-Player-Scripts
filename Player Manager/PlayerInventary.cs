using System.Collections.Generic;
using UnityEngine;

public class PlayerInventary : MonoBehaviour
{
    private Dictionary<string, GameObject> inventary;
    private InputManagerPlayer inputManagerPlayer;

    private float RayLenght = 0.0f;
    private Ray ray;

    private void Awake() {
        SetDefaultState();
    }
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void AddItemToDictionary(string name, GameObject item) {
        inventary.Add(name, item);
    }

    public void AddItemToInventary() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, RayLenght)) {
            if (inputManagerPlayer.GetCollectInput() && hit.collider.CompareTag("Item")) {
                AddItemToDictionary(hit.collider.name, hit.collider.gameObject);
                hit.collider.gameObject.SetActive(false); //make the item disappear
            }
        }
    }

    public void RemoveItem(string name) {
        inventary.Remove(name);
    }

    public GameObject GetItem(string name) {
        return inventary[name];
    }

    public bool HasItem(string name) {
        return inventary.ContainsKey(name);
    }

    private void SetDefaultState() {
        inventary = new Dictionary<string, GameObject>();
        inputManagerPlayer = GetComponent<InputManagerPlayer>();
        RayLenght = 2.0f;
    }


}
