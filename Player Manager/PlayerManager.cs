using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public PlayerInventary inventary;

    public void Awake() {
        SetDefaultState();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SetDefaultState() {
        try {
            inventary = GetComponent<PlayerInventary>();

        } catch {
            Debug.LogError("Error setting default state");
        }
        
    }
}
