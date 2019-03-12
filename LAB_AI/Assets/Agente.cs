using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agente : MonoBehaviour
{
    public float HayTePillo;
    public float HuevaTime;

    private NavMeshAgent agent;
    private float timer;

    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = HuevaTime;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= HuevaTime)
        {
            Vector3 newPos = RandomN(transform.position, HayTePillo, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    public static Vector3 RandomN(Vector3 origen, float distancia, int mask)
    {
        Vector3 direccion = Random.insideUnitSphere * distancia;

        direccion += origen;

        NavMeshHit navHit;

        NavMesh.SamplePosition(direccion, out navHit, distancia, mask);

        return navHit.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "putote")
        {
            Destroy(collision.gameObject);
            collision.gameObject.GetComponent<Movimiento>().Upsi();
        }

    }
}