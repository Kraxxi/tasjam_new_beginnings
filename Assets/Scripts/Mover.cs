using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public Transform targetToMove;
    public Animator entityAnimator;
    public float moveSpeed;
    [SerializeField] private Vector2 _currentDirection;
    
    
    private void Awake()
    {
        if (targetToMove == null) targetToMove = transform;
    }


    public void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_currentDirection == Vector2.zero)
        {
            entityAnimator.SetBool("isMoving", false);
            return;
        }

        entityAnimator.SetBool("isMoving", true);
        Vector2 startPos = targetToMove.position;
        Vector2 destination = startPos + _currentDirection;
        float step = moveSpeed * Time.fixedDeltaTime;

        targetToMove.transform.position = Vector2.MoveTowards(startPos, destination, step);
    }
    
    

    public void Move(Vector2 direction)
    {
        _currentDirection = direction;
    }
}
