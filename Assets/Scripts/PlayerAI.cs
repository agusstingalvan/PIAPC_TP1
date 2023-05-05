using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PlayerAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;
    private string _targetName;
    private string _status;

    [SerializeField] private GameObject[] _target;
    //[SerializeField] private GameObject _nextPointObject;


    TrafficLightStateManager _tlsmanager;

    [SerializeField] TMPro.TextMeshProUGUI _flText;
    [SerializeField] TMPro.TextMeshProUGUI _flTextVelocity;


    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GetComponent<Transform>();
        
        //States Managers
        _tlsmanager = new TrafficLightStateManager();
        
        if(GetComponent<PlayerStateManager>() != null)
        {
           _status = GetComponent<PlayerStateManager>().statusPlayer;
        }
    }

    void Update()
    {

        foreach (GameObject light in _target)
        {

            if (light.GetComponentInChildren<TrafficLightStateManager>().visited == false)
            {
                _agent.SetDestination(light.transform.position);
            }
        }
        if (_status != null)
        {
            _status = GetComponent<PlayerStateManager>().statusPlayer;
            _flText.text = _status;
            _flTextVelocity.text = _agent.speed.ToString(); 
        }
    } 
}
