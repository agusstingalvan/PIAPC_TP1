using UnityEngine;

public abstract class PlayerBaseState 
{
    public string status = "";
    public abstract void EnterState(PlayerStateManager player);

    public abstract void UpdateState(PlayerStateManager player);

    public abstract void OnTriggerEnter(PlayerStateManager player);

    public abstract void OnTriggerExit(PlayerStateManager player);
}
