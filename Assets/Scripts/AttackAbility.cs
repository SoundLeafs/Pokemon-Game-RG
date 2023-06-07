using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : PlayerAbility
{

   public AnimationController animationController;

    public override void UseAbility()
     {
         if(turnTimer.playerTurn)
            //if player turn we can attack
             {
                int damage = Random.Range(20,30);
		    	_health.DealDamage(damage);
                Debug.Log("Attack!");
            animationController.PlayerAnimation();
                turnTimer.ChangeTurn();
            
            //end our turn
             }
     }
}
