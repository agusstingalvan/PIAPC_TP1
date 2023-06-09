using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightStateManager : MonoBehaviour
{
    public TrafficLightBaseState _currentState;
    public TrafficLightBaseState _oldState;

    //Instances of states
    public TrafficLightWarn _stateWarn = new TrafficLightWarn();
    public TrafficLightStateStop _stateStop = new TrafficLightStateStop();
    public TrafficLightStateGo _stateGo = new TrafficLightStateGo();

    public bool visited = false;
    public bool inLastLight;

    private PlayerStateManager _playerStateManager;
    // Start is called before the first frame update
    void Start()
    {
        int randomNumber = Random.Range(0, 2);
        _currentState = (randomNumber == 0) ? _stateStop : _stateGo;
        _currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerStateManager != null && _playerStateManager._currentState.status == "Reviewing" && _currentState.type != "warn")
        {
            //Si el auto esta en estado de Reviewing y el semaforo no esta en amarrillo ni en rojo. Cambiamos a GOING
            _playerStateManager._currentState = _playerStateManager._stateGo;
            _playerStateManager._currentState.EnterState(_playerStateManager);
        }
        _currentState.UpdateState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "FinalLine") return;

        if (other.tag == "Player")
        {
            _playerStateManager = other.GetComponent<PlayerStateManager>(); 
            visited = true;
            if(_currentState.type == "stop")
            {
                _currentState.OnTriggerEnter(this, other);
            }        
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (this.gameObject.tag == "FinalLine") return;

        if (other.tag == "Player" && _currentState.type == "warn")
        {
            _currentState.OnTriggerStay(this, other);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "FinalLine") return;

        if (other.tag == "Player")
        {
            _oldState.OnTriggerExit(this, other);
        }
    }
}
