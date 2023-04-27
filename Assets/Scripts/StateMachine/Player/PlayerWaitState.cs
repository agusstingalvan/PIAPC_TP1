using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
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
