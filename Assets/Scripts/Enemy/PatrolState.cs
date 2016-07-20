using UnityEngine;
using System.Collections;

public class PatrolState : IEnemyState
{
    private readonly StateEnemy enemy;
    
    public PatrolState(StateEnemy stateEnemy)
    {
        enemy = stateEnemy;
    }

    public void updateState()
    {
        Look();
        Patrol();
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            ToAlertState();
    }

    public void ToPatrolState()
    {
        Debug.Log("Can't transition to same state");
    }

    public void ToCircleState()
    {
        enemy.currentState = enemy.circleState;
    }

    public void ToChaseState()
    {
        enemy.currentState = enemy.chaseState;
    }

    public void ToAlertState()
    {
        enemy.currentState = enemy.alertState;
    }

    private void Look()
    {
        RaycastHit hit;
        if(Physics.Raycast (enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            ToChaseState();
        }
    }

    void Patrol()
    {
        if (enemy.navMeshAgent.remainingDistance <= enemy.navMeshAgent.stoppingDistance && !enemy.navMeshAgent.pathPending)
        {
            enemy.meshRenderererFlag.material.color = Color.green;
            Vector2 Temp = Random.insideUnitCircle;
            float TempDistance = Random.Range(0, 10);
            Temp *= TempDistance;
            Vector3 finTemp = new Vector3(Temp.x, 0, Temp.y);
            enemy.navMeshAgent.destination = enemy.transform.position + finTemp;
            enemy.navMeshAgent.Resume();

        }
    }


}