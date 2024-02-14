using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private int _chaseRange;
    [SerializeField] private int _attackRange;

    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _chaseRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _attackRange);
    }

    private void Update()
    {
        if (IsPlayerInAttackRange())
        {
            Attack();
        }else if (IsPlayerInChaseRange())
        {
            Chase();
        }
        else
        {
            Stop();
        }
    }

    private bool IsPlayerInAttackRange()
    {
        if (PlayerMovement.Instance == null) return false;

        float distanceToPlayer = Vector3.Distance(
            PlayerMovement.Instance.transform.position,
            transform.position);

        if (distanceToPlayer < _attackRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Stop()
    {
        _navMeshAgent.isStopped = true;
    }

    private void Attack()
    {
        _navMeshAgent.isStopped = true;
    }

    private void Chase()
    {
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(PlayerMovement.Instance.transform.position);
    }

    private bool IsPlayerInChaseRange()
    {
        if (PlayerMovement.Instance == null) return false;

        float distanceToPlayer = Vector3.Distance(
            PlayerMovement.Instance.transform.position, 
            transform.position);

        if(distanceToPlayer < _chaseRange)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
