using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movimiento : MonoBehaviour
{
    public float speed;
    public float HayTeCojo;

    private NavMeshAgent bola;

    Vector3 newPosition;

    void Start()
    {
        bola = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit azote;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out azote))
            {
                bola.SetDestination(azote.point);
            }
        }
    }

    public void Upsi()
    {

    }
}