using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;

    public void WalkAnimation()
    {
        animator.SetInteger("AnimationState", 0);
    }
    public void AttackAnimation()
    {
        animator.SetInteger("AnimationState", 2);
    }
}
