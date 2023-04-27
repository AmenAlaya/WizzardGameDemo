using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        Enemy.Instance.OnTargetSeen += Enemy_OnTargetSeen;
        Enemy.Instance.OnTargetUnseen += Enemy_OnTargetUnseen;
        Enemy.Instance.OnAttack += Enemy_OnAttchack;
    }

    private void Enemy_OnAttchack(object sender, System.EventArgs e)
    {
        // Player attack animation
        animator.SetTrigger(Constants.ENEMY_SMASH_ATTACK_ANIM);
        animator.SetBool(Constants.ENEMY_WLAK_FORWORD_ANIM, false);
    }

    private void Enemy_OnTargetUnseen(object sender, System.EventArgs e)
    {
        // Stop Walk animation    
        animator.SetBool(Constants.ENEMY_WLAK_FORWORD_ANIM, false);
    }

    private void Enemy_OnTargetSeen(object sender, System.EventArgs e)
    {
        // start Walk animation    
        animator.SetBool(Constants.ENEMY_WLAK_FORWORD_ANIM, true);
    }
}
