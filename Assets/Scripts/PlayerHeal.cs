using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeal : PlayerAbility
{
    public AnimationController animationController;

    
    
    public override void UseAbility()
    {
        if(turnTimer.playerTurn)
        {
            animationController.PlayerHeal();
            _playerHealth.Heal();
            turnTimer.ChangeTurn();
        }

    }

}
