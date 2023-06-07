using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : PlayerAbility
{
   
    
  public override void UseAbility()
     {
         if(turnTimer.playerTurn)
             {
                int damage = Random.Range(50,70);
		    	_health.DealDamage(damage);
                Debug.Log("HEAVY ATTACK!");
            //reset timer
                turnTimer.recharge = true;
                turnTimer.ChangeTurn();

             }
     }
}
