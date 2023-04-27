using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AI : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;
    private string _targetName;

    [SerializeField] private GameObject[] _target;
    [SerializeField] private GameObject _nextPointObject;

    LightStateManager _lsmanager;

    [SerializeField] TMPro.TextMeshProUGUI _flText;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GetComponent<Transform>();
        _lsmanager = new LightStateManager();
    }

    void Update()
    {

        foreach(GameObject lights in _target)
        {
            if (lights.GetComponentInChildren<LightStateManager>().visited == false)
            {
                _agent.SetDestination(lights.transform.position);


                FuzzyLogic(lights.transform, _player);
                _targetName = lights.name;
            }
        }
        


        

        //Instantiate(_nextPointObject, _agent.nextPosition, transform.rotation);

    }

    private void FuzzyLogic(Transform _targetPos, Transform _playerPos)
    {
        float distance = (_targetPos.position - _playerPos.position).magnitude;

        //Debug.Log(distance);

        if(distance >= 40)
        {
            _flText.text = _targetName + " lejos!";
        } 
        if(distance < 45 && distance >= 30)
        {
            _flText.text = _targetName + " menos lejos..";
        }
        if(distance < 30 && distance >= 25)
        {
            _flText.text = _targetName + " cerca..";
        }
        if(distance < 25 && distance >= 20)
        {
            _flText.text = _targetName + " mas cerca..";
        }
        if(distance < 20 && distance >= 0)
        {
            _flText.text = _targetName + " llegué..";
        }


    }

}
