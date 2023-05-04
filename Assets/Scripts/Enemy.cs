using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3.25f;
    public float avoidDistance = 2f; // la distancia de detección de obstáculos
    public float avoidForce = 5f; // la fuerza con la que el enemigo evita los obstáculos

    private Vector3 _initialPosition;
    private Quaternion _initialRotation;
    private Vector3 _lastPosition;

    void Start()
    {
        _initialPosition = transform.position;
        _initialRotation = transform.rotation;
        _lastPosition = transform.position;
    }

    void Update()
    {
        // Encuentra la dirección actual del enemigo
        Vector3 direction = (transform.position - _lastPosition).normalized;
        _lastPosition = transform.position;

        // Dispara un raycast en la dirección de movimiento actual para detectar obstáculos
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, avoidDistance, LayerMask.GetMask("Obstacle")))
        {
            // Calcula un nuevo vector de dirección girando hacia la derecha y alejándose del obstáculo
            Vector3 avoidDirection = Vector3.Cross(direction, Vector3.forward).normalized;
            Vector3 newDirection = Vector3.Cross(avoidDirection, direction).normalized;

            // Asigna la nueva dirección al enemigo
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
        else
        {
            // Si no se detecta un obstáculo, continúa moviéndote hacia adelante
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Si el enemigo se sale del mapa, vuelve a la posición inicial
        if (transform.position.z <= -10 || transform.position.x > 10 || transform.position.z > 108f)
        {
            transform.position = new Vector3(_initialPosition.x, transform.position.y, _initialPosition.z);
            transform.rotation = _initialRotation;
        }
    }
}
