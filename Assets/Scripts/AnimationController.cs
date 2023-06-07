using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator playerAnimator;

    public Animator enemyAnimator;

    public Animator enemyHeal;

    public Animator playerHeal;

   public void PlayerAnimation()
    {
        playerAnimator.SetTrigger("Attack");
        Debug.Log("PlayerAttack");
    }

    public void EnemyAnimation()
    {
        enemyAnimator.SetTrigger("Attack");
        Debug.Log("EnemyAttack");
    }

    public void EnemyHeal()
    {
        enemyHeal.SetTrigger("HealEnemy");
    }

    public void PlayerHeal()
    {
        playerHeal.SetTrigger("HealMe");
    }
}
