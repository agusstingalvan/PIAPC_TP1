using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWarnState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        status = "Reviewing";
       player._agent.isStopped = false;
    }


    public override void UpdateState(PlayerStateManager player)
    {
        
    }

    public override void OnTriggerEnter(PlayerStateManager player)
    {
        if (player._agent.speed >= player.speedNormal)
        {
            player._agent.speed = player.speedMin;
        }
    }

    public override void OnTriggerExit(PlayerStateManager player)
    {
        if (player._agent.speed <= player.speedMin)
        {
            player._agent.speed = Random.Range(player.speedNormal, player.speedMax);
        }
    }
}
