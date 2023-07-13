using Inheritance;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Enemy enemy;

    private float moveSpeed;
    private int hpCost;
    private Transform target;
    private Transform[] movePath;
    private int pathIndex = 0;

    void Start()
    {
        moveSpeed = enemy.MoveSpeed;
        hpCost = enemy.HpCost;

        switch (Random.Range(0, 3)) {
            case 0:
                movePath = LevelManager.main.path;
                target = LevelManager.main.path[pathIndex];
                break;
            case 1:
                movePath = LevelManager.main.path1;
                target = LevelManager.main.path1[pathIndex];
                break;
            case 2:
                movePath = LevelManager.main.path2;
                target = LevelManager.main.path2[pathIndex];
                break;
        }
    }
    
    void Update()
    {
        animator.SetFloat("Angle", Vector2.SignedAngle(target.position - transform.position, Vector2.right) / 180);
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;
            if (pathIndex >= movePath.Length)
            {
                EventManager.OnEnemyFinished(hpCost);
                Destroy(gameObject);
                return;
            }
            else
            {
                target = movePath[pathIndex];
            }
        }
    }
    
    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }
}