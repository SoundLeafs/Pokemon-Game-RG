using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour
//abstract 
{
	[SerializeField] public TurnTimer turnTimer;

	[SerializeField] protected Health _health;

	[SerializeField] protected Health _playerHealth;


   public abstract void UseAbility();
    //protected can be inhereted by children

    private void Start()
    {
        turnTimer = GetComponent<TurnTimer>();
    }

    protected void EndTurn()

	{
        
		turnTimer.ChangeTurn();
	}

   

}
