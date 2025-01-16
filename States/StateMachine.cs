using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState CurrentState;
    private IState PreviousState;
    private IState NextState;
    
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


}
