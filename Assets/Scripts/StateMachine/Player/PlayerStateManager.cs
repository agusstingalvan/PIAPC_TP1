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
    PlayerWarnState _stateReviewing = new PlayerWarnState();

    public string statusPlayer;
    public Camera camera;


    [SerializeField]
    public float speedMax = 6.5f;
    [SerializeField]
    public float speedNormal = 3.5f;
    [SerializeField]
    public float speedMin = 1.5f;
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
                _currentState.OnTriggerExit(this);
                _currentState = _stateGo;
                _currentState.EnterState(this);
                statusPlayer = _currentState.status;
            }else if(_trafficLightCurrent._currentState.type == "warn")
            {
                _currentState = _stateReviewing;
                _currentState.EnterState(this);
                statusPlayer = _currentState.status;
            }else if(_trafficLightCurrent._currentState.type == "stop")
            {
                _currentState = _stateWait;
                _currentState.EnterState(this);
                statusPlayer = _currentState.status;
            }
        }
        _currentState.UpdateState(this);
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "TrafficLight")
        {
            _trafficLightCurrent = other.GetComponentInChildren<TrafficLightStateManager>();
            //if (_trafficLightCurrent.inLastLight)
            //{
            //    _agent.isStopped = true;
            //    _agent.velocity = new Vector3(0, 0, 0);
            //    _currentState = _stateWait;
            //    _currentState.EnterState(this);
            //    statusPlayer = "Gano";
            //    return;
            //}
            
            string type = other.GetComponentInChildren<TrafficLightStateManager>()._currentState.type;
            if(type == "stop")
            {
                _currentState = _stateWait;
                _currentState.EnterState(this);
                statusPlayer = _currentState.status;
            }else if (type == "warn")
            {
                _currentState = _stateReviewing;
                _currentState.EnterState(this);
                _currentState.OnTriggerEnter(this);
                statusPlayer = _currentState.status;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "TrafficLight")
        {
            _currentState.OnTriggerExit(this);
            _currentState = _stateGo;
            _currentState.EnterState(this);
            statusPlayer = _currentState.status;
            _trafficLightCurrent = null;
        }
    }
}
