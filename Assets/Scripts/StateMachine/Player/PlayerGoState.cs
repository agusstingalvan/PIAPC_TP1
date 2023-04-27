using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        status = "Going";
        player._agent.isStopped = false;
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
