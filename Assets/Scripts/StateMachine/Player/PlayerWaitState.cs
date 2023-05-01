using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWaitState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        status = "Waiting";
        player._agent.isStopped = true;
        player._agent.speed = 0;
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
