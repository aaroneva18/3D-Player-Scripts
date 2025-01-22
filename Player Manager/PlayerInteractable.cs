using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    private PlayerInventary inventary;
    private InputManagerPlayer inputManger;
    private Ray ray;

    [SerializeField] private float RayLenght = 0.0f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Transform CameraTransform;

    private void Awake() {
        SetDefaultState();
    }

    void Start()
    {
        
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
                Debug.Log("Inventary size: " + inventary.GetInventarySize);
                inventary.AddItemToInventary(hit.collider.gameObject.name, hit.collider.gameObject);
                hit.collider.gameObject.SetActive(false);
            } else if(inputManger.GetCollectInput() && inventary.GetInventarySize >= inventary.GetInventoryMaxSize) {
                Debug.Log("Inventary is full");
            }
        }
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
