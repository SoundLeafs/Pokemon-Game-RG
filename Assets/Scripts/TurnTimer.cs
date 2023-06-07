using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnTimer : MonoBehaviour
{
	public bool playerTurn;
    // will decide who's turn it is
    public TextMeshProUGUI whoseTurn;

    public float currentTime = 0;
    public float timerSpeed = 1;
    public bool recharge = false;
    

    public void Start()
    {
       playerTurn = false;
    }

    public void ChangeTurn()
    {
        //this will change between turns 

        if (playerTurn)
        {
            playerTurn = false;
            whoseTurn.text = "Enemy Turn";
            currentTime = 0;
        }

        else if (recharge)
        {
            recharge = false;
            playerTurn = false;
            whoseTurn.text = "Enemy Turn";
            currentTime = 0;
        }

        else
        {
           playerTurn = true;
            whoseTurn.text = "Your Turn";
        }
    }

    public void Update()
    {
        if (!playerTurn)
        {
            currentTime += timerSpeed * Time.deltaTime;
        }
    }


}


	

