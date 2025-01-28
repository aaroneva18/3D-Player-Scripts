using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventaryState : IState
{
    private PlayerInventary playerInventary;
    private PlayerMovement playerMovement;
    private InputManagerPlayer inputManager;

    public InventaryState(PlayerInventary p_playerInventary, PlayerMovement p_playerMovement, InputManagerPlayer p_inputManager) {
        playerInventary = p_playerInventary;
        playerMovement = p_playerMovement;
        inputManager = p_inputManager;
    }

    public void Enter() {
        playerMovement.SetPlayable(false);
        playerInventary.SetPanelActive(true);
        inputManager.SwitchActionMap("Inventary");
    }

    public void Execute() {

    }
    public void FixedExecute() {
    }

    public void Exit() {
        playerInventary.SetPanelActive(false);
        playerMovement.SetPlayable(true);
        inputManager.SwitchActionMap("Gameplay");
    }

}
