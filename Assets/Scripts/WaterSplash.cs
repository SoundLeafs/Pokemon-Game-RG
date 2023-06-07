using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSplash : PlayerAbility
{
    public override void UseAbility()
    {
        if (turnTimer.playerTurn)
        {
            if (CurrentEnemy.enemyElement == "Fire") 
            {
                int damage = Random.Range(50, 70);
                _health.DealDamage(damage);
                turnTimer.ChangeTurn();
                Debug.Log("Super Effective");
            }
            else
            {
                int damage = Random.Range(10, 20);
                _health.DealDamage(damage);
                turnTimer.ChangeTurn();
                Debug.Log("Not Very Effective");
            }
        }
    }




}