
public class PlayerStateMachine : StateMachine
{

    private InputManagerPlayer inputManager;
    private PlayerMovement playerMovement;
    private PlayerInventary playerInventary;

    private void Awake() {
        inputManager = GetComponent<InputManagerPlayer>();
        playerMovement = GetComponent<PlayerMovement>();
        playerInventary = GetComponent<PlayerInventary>();
    }

    void Start()
    {
        WalkState walkState = new WalkState(playerMovement, inputManager, this);
        IddleState iddleState = new IddleState(playerMovement, this, inputManager);
        JumpState jumpState = new JumpState(playerMovement);
        SprintState sprintState = new SprintState(playerMovement);
        StealthState stealthState = new StealthState(playerMovement);
        InventaryState inventaryState = new InventaryState(playerInventary, playerMovement, inputManager);

        AddTransition(iddleState, walkState, () => playerMovement.GetIsMoving);
        AddTransition(iddleState, sprintState, () => inputManager.GetSprintInput());
        AddTransition(iddleState, stealthState, () => inputManager.GetStealthInput());
        AddTransition(iddleState, inventaryState, () => inputManager.GetInventaryInput());

        AddTransition(walkState, sprintState, () => inputManager.GetSprintInput());
        AddTransition(walkState, iddleState, () => !playerMovement.GetIsMoving);
        AddTransition(walkState, stealthState, () => inputManager.GetStealthInput());
        AddTransition(walkState, inventaryState, () => inputManager.GetInventaryInput());


        AddTransition(sprintState, walkState, () => !inputManager.GetSprintInput());
        AddTransition(sprintState, iddleState, () => !playerMovement.GetIsMoving);
        AddTransition(sprintState, stealthState, () => inputManager.GetStealthInput());
        AddTransition(sprintState, inventaryState, () => inputManager.GetInventaryInput());

        AddTransition(inventaryState, iddleState, () => inputManager.GetInventaryInput() && playerInventary.GetIsPanelActive && !playerMovement.GetIsMoving);
        AddTransition(inventaryState, walkState, () => inputManager.GetInventaryInput() && playerInventary.GetIsPanelActive && playerMovement.GetIsMoving);



        SetState(iddleState);
    }

}
