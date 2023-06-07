using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random=UnityEngine.Random;
using UnityEngine.UI;


public class StateMachine : MonoBehaviour
{
   public AnimationController animationController;
    //reference to the script animation controller

    public enum State
    {
        Normal,
        LowHP,
        Sleep,
        Enraged,
    }

   


    [SerializeField] private State _state;
    [SerializeField] private Health _health;
    [SerializeField] private Health _playerHealth;
    [SerializeField] private TurnTimer _turnTimer;

    public TextMeshProUGUI stateText;

    
    

    //Keep track of which state we are in
    //Start
    // -------> NextState()
    //---------------> PatrolState()
    //---------------> CombatState()

    private void Start()
    {

        //_state = State.Patrol;
        NextState();
    }

    public void Update()
    {
        stateText.text = $"Enemy is "+ _state.ToString();
    }

    private void NextState()
    {
        

        switch (_state)
        {
            case State.Normal:
                StartCoroutine(NormalState());
                break;
            case State.LowHP:
                 StartCoroutine(LowHPState());
                break;
            case State.Sleep:
                 StartCoroutine(SleepState());
                break;
            case State.Enraged:
                StartCoroutine(EnragedState());
                break;
        }
    }

    

    private IEnumerator NormalState()
    {

        Debug.Log("Enter Normal State");
      

      
        while (_state == State.Normal)
        {
           if (_health.CurrentHealth() >30 && _health.CurrentHealth() < 60)
            {
                _state = State.Enraged;
            }

            if(_health.CurrentHealth() <=30)
            {
                _state = State.LowHP;
            }
            if(_turnTimer.playerTurn || _turnTimer.currentTime < 1)
               //if player turn then we wait
            {
                yield return null;
                continue;
                //goes to the while loop and starts again
            }
            //this will only
            int randomDamage = Random.Range(10,30);
            _playerHealth.DealDamage(randomDamage);
            animationController.EnemyAnimation();
            //player health deal random dammage
            _turnTimer.ChangeTurn();
            yield return null;//wait a single frame
            
        }
        Debug.Log("Exit Normal State");
        NextState();
    }
    
    private IEnumerator LowHPState()
    { 
        Debug.Log("Enter LowHP State");
        while(_state == State.LowHP)
        {
            if(_turnTimer.playerTurn || _turnTimer.currentTime <1)
                //if player turn we wait
            {
                yield return null;
                continue;
                //waits one frame and continues
            }

            _health.Heal();

            animationController.EnemyHeal();
            _turnTimer.ChangeTurn();


            if(_health.CurrentHealth() > 80)
            {
                _state = State.Normal;
            }
            yield return null;
        }
        Debug.Log("Exit LowHP State");
        NextState();
    }

    private IEnumerator SleepState()
    {
        Debug.Log("Enter Sleep State");
        while(_state == State.Sleep)
        {


            yield return null;
        }
        Debug.Log("Exit Sleep State");
        NextState();
    }

    private IEnumerator EnragedState()
    {
        Debug.Log("Enemy is enraged");
        while (_state == State.Enraged)
        {
            if (_turnTimer.playerTurn || _turnTimer.currentTime < 1)
            //if player turn we wait
            {
                yield return null;
                continue;
                //waits one frame and continues
            }
            int randomDamage = Random.Range(20, 40);
            _playerHealth.DealDamage(randomDamage);
            animationController.EnemyAnimation();
            //player health deal random dammage
            _turnTimer.ChangeTurn();
            _state = State.Normal;
            yield return null;//wait a single frame
        }
        //return to normal
       
        Debug.Log("Exit Enraged State");
        NextState();

    }

    public void QuitGame()
    {

        Debug.Log("QUIT GAME");
        Application.Quit();
    }

}
