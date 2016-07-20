using UnityEngine;
using System.Collections;

public class StateEnemy : MonoBehaviour {

    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public CircleState circleState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;

    private void Awake()
    {
        chaseState = new ChaseState();
        circleState = new CircleState();
        patrolState = new PatrolState();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        currentState = patrolState;
    }

    void Update()
    {
        currentState.UpdateState();
    }

}
