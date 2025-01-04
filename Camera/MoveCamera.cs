using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    [SerializeField] private Transform CameraPos;

    void Update()
    {
        transform.position = CameraPos.transform.position;        
    }
}
