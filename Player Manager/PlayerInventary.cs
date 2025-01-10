using System.Collections.Generic;
using UnityEngine;

public class PlayerInventary : MonoBehaviour
{
    Dictionary<string, GameObject> inventary;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(string name, GameObject item) {
        inventary.Add(name, item);
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



}
