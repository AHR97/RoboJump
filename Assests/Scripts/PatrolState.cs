using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState
{

    private Enemy enemy;

    private float patrolTimer;

    private float patrolDuration ;

    public void Enter(Enemy enemy)
    {
        patrolDuration = UnityEngine.Random.Range(1, 10);
        this.enemy = enemy;
    }

    public void Execute()
    {
        Debug.Log("Patroling");
        Patrol();

        enemy.Move();

        if (enemy.Target != null && enemy.InThrowRange)
        {
            enemy.ChangeState(new RangedState());
        }
    }

    public void Exit()
    {

    }

    public void OnTriggerEnter(Collider2D other)
    {
        if(other.tag=="Bullet")
        {
            enemy.Target = Player.Instance.gameObject;
        }
    }

    private void Patrol()
    {
        patrolTimer += Time.deltaTime;

        if (patrolTimer >= patrolDuration)
        {
            enemy.ChangeState(new IdleState());
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
