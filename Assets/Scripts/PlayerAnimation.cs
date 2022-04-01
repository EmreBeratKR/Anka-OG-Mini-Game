using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private PlayerMove playerMove;
    [SerializeField] private Animator animator;
    private PLayerState state;


    private void Update()
    {
        UpdateState();

        switch (state)
        {
            case PLayerState.IDLE:
                animator.SetBool("isIdle", true);
                animator.SetBool("isWalk", false);
                animator.SetBool("isRun", false);
                break;
            case PLayerState.WALK:
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalk", true);
                animator.SetBool("isRun", false);
                break;
            case PLayerState.RUN:
                animator.SetBool("isIdle", false);
                animator.SetBool("isWalk", false);
                animator.SetBool("isRun", true);
                break;
        }

    }


    private void UpdateState()
    {
        var speed = playerMove.GetSpeed();

        if (speed > 5)
        {
            state = PLayerState.RUN;
        }
        else if (speed > 0)
        {
            state = PLayerState.WALK;
        }
        else
        {
            state = PLayerState.IDLE;
        }
    }


    enum PLayerState
    {
        IDLE,
        WALK,
        RUN
    }
}
