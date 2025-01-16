using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState CurrentState;
    private IState PreviousState;
    private IState NextState;

    private InputManagerPlayer inputManager;

    private void Awake() {
        SetDefalutState();
    }
    void Start()
    {
        
    }

    void Update()
    {

    }

    void FixedUpdate() {
        
    }

    public IState GetCurrentState { get { return CurrentState; } }

    public void ChangeIState(IState p_state) {
        if (CurrentState != null) {
            CurrentState.Exit();
        }
        PreviousState = CurrentState;
        CurrentState = p_state;
        CurrentState.Enter();
    }

    private void SetDefalutState() {
        try {
            inputManager = GetComponent<InputManagerPlayer>();
        } catch {
            Debug.LogError("Error setting SetDefaultState");
        }
    }

}
