
public class PlayerStateMachine : StateMachine
{

    private InputManagerPlayer inputManager;
    private PlayerMovement playerMovement;
    private PlayerInventary playerInventary;


    void Start()
    {
        WalkState walkState = new WalkState(playerMovement, inputManager, this);
        IddleState iddleState = new IddleState(playerMovement, this, inputManager);
        JumpState jumpState = new JumpState(playerMovement);
        SprintState sprintState = new SprintState(playerMovement);
        StealthState stealthState = new StealthState(playerMovement);
        InventaryState InventaryState = new InventaryState(playerInventary, playerMovement);

        AddTransition(iddleState, walkState, () => playerMovement.GetIsMoving);
        AddTransition(iddleState, sprintState, () => inputManager.GetSprintInput());
        AddTransition(iddleState, stealthState, () => inputManager.GetStealthInput());
        AddTransition(iddleState, InventaryState, () => inputManager.GetInventaryInput());

        AddTransition(walkState, sprintState, () => inputManager.GetSprintInput());
        AddTransition(walkState, iddleState, () => !playerMovement.GetIsMoving);
        AddTransition(walkState, stealthState, () => inputManager.GetStealthInput());
        AddTransition(walkState, InventaryState, () => inputManager.GetInventaryInput());


        AddTransition(sprintState, walkState, () => !inputManager.GetSprintInput());
        AddTransition(sprintState, iddleState, () => !playerMovement.GetIsMoving);
        AddTransition(sprintState, stealthState, () => inputManager.GetStealthInput());
        AddTransition(sprintState, InventaryState, () => inputManager.GetInventaryInput());

        SetState(iddleState);
    }

}
