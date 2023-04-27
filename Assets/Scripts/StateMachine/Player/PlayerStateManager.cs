using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStateManager : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent _agent;
    public PlayerBaseState _currentState;

    private TrafficLightStateManager _trafficLightCurrent;

    //Instances of states
    PlayerWaitState _stateWait = new PlayerWaitState();
    PlayerGoState _stateGo = new PlayerGoState();

    public string statusPlayer;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentState = _stateGo;
        _currentState.EnterState(this);

        statusPlayer = _currentState.status;
    }

    void Update()
    {

        if (_trafficLightCurrent != null)
        {
            if (_trafficLightCurrent._currentState.type == "go")
            {
                _currentState = _stateGo;
                _currentState.EnterState(this);
                statusPlayer = _currentState.status;
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "TrafficLight")
        {
            _trafficLightCurrent = other.GetComponentInChildren<TrafficLightStateManager>();
            string type = other.GetComponentInChildren<TrafficLightStateManager>()._currentState.type;
            if(type == "stop")
            {
                _currentState = _stateWait;
                _currentState.EnterState(this);
                statusPlayer = _currentState.status;
            }
        }
    }
}
