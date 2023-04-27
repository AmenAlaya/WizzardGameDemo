using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance { get; private set; }

    public event EventHandler OnTargetSeen;
    public event EventHandler OnTargetUnseen;
    public event EventHandler OnAttack;
    public event EventHandler OnHitPlayer;

    [SerializeField] private Transform _target;


    private NavMeshAgent _navMeshAgent;

    private float _attackDistance = 2f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float Distance = Vector3.Distance(transform.position, _target.position);

        if (Distance < _attackDistance)
        {
            //Attack the player 
            OnAttack?.Invoke(this, EventArgs.Empty);
            OnHitPlayer?.Invoke(this, EventArgs.Empty);
        }
        else if (Distance < 10)
        {
            //Follow the player
            OnTargetSeen?.Invoke(this, EventArgs.Empty);
            _navMeshAgent.destination = _target.position;
        }
        else
        {
            //Stop following the player
            OnTargetUnseen?.Invoke(this, EventArgs.Empty);
            _navMeshAgent.destination = transform.position;
        }
    }


}
