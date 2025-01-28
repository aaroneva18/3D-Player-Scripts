using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventaryState : IState
{
    private PlayerInventary playerInventary;
    private PlayerMovement playerMovement;

    public InventaryState(PlayerInventary p_playerInventary, PlayerMovement p_playerMovement) {
        playerInventary = p_playerInventary;
        playerMovement = p_playerMovement;
    }

    public void Enter() {
        playerMovement.SetPlayable(false);
        playerInventary.SetPanelActive(true);
    }

    public void Execute() {

    }

    public void Exit() {
        
    }

    public void FixedExecute() {
    }
}
