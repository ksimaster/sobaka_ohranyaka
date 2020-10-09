using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    private NavMeshAgent _agent;

    [SerializeField] PlayerController _player;

    [SerializeField]
    private float _distanceToPlayer = 10F;

    private const float EPSILON = 0.1F; 
	// Use this for initialization
	void Start () {
        _agent = GetComponent<NavMeshAgent>();
	}
	
    private bool IsNavMeshMoving{
        get{
            return _agent.velocity.magnitude > EPSILON;
        }
    }

	// Update is called once per frame
	void Update () {

        float dist = Vector3.Distance(_player.transform.position, transform.position);

        if(dist < _distanceToPlayer){

            Vector3 playerPos = _player.transform.position;

            _agent.SetDestination(playerPos);
        }
	}
}
