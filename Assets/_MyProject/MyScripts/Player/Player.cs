using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _health = 100f;

    private event EventHandler OnPlayerHittedAnimation;

    private void Start()
    {
        Enemy.Instance.OnHitPlayer += Enemy_OnPlayerGetHited;
    }

    private void Enemy_OnPlayerGetHited(object sender, EventArgs e)
    {
        if(_health > 0)
        {
            //Incrice The health
            _health -= 25f;
            Debug.Log(_health);
        }
        else
        {
            //Player Die
            Debug.Log("YOU DIE!");
        }
    }

}
