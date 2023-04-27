using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStateManager : MonoBehaviour
{
    public NavMeshAgent _agent;
    public PlayerBaseState _currentState;
    PlayerWaitState _stateWait = new PlayerWaitState();
    PlayerGoState _stateGo = new PlayerGoState();
    // Start is called before the first frame update
    void Start()
    {
        _currentState = _stateGo;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "TrafficLight")
        {
            string type = other.GetComponentInChildren<TrafficLightStateManager>()._currentState.type;
            if(type == "stop")
            {
                _currentState = _stateWait;
                _currentState.EnterState(this);
            }
        }
    }
}
