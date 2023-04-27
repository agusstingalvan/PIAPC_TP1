using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        player._agent.isStopped = true;
    }


    public override void UpdateState(PlayerStateManager player)
    {

    }

    public override void OnTriggerEnter(PlayerStateManager player)
    {
        
    }

    public override void OnTriggerExit(PlayerStateManager player)
    {
        
    }
}
