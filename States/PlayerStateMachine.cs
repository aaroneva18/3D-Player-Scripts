

public class PlayerStateMachine : StateMachine
{
    void Start()
    {
        WalkState walkState = new WalkState(playerMovement, inputManager, this);
        IddleState iddleState = new IddleState(playerMovement, this, inputManager);
        JumpState jumpState = new JumpState(playerMovement);
        SprintState sprintState = new SprintState(playerMovement);

        AddTransition(iddleState, walkState, () => playerMovement.GetIsMoving);
        AddTransition(iddleState, sprintState, () => inputManager.GetSprintInput());

        AddTransition(walkState, sprintState, () => inputManager.GetSprintInput());
        AddTransition(walkState, iddleState, () => !playerMovement.GetIsMoving);


        AddTransition(sprintState, walkState, () => !inputManager.GetSprintInput());
        AddTransition(sprintState, iddleState, () => !playerMovement.GetIsMoving);

        SetState(iddleState);
    }

}
