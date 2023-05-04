using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerStateManager : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent _agent;
    public PlayerBaseState _currentState;

    private TrafficLightStateManager _trafficLightCurrent;

    //Instances of states
    public PlayerWaitState _stateWait = new PlayerWaitState();
    public PlayerGoState _stateGo = new PlayerGoState();
    public PlayerWarnState _stateReviewing = new PlayerWarnState();

    public string statusPlayer;

    [SerializeField]
    public float speedNormal;
    [SerializeField]
    public float speedMin = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _currentState = _stateGo;
        _currentState.EnterState(this);
    }

    void Update()
    {
        _currentState.UpdateState(this);
    }
    IEnumerator WaitEnd()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("TpSceneTest2");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FinalLine")
        {
            StartCoroutine(WaitEnd());
        }
    }
    private void OnTriggerExit(Collider other)
    {
    }
}
