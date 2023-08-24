using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class screamState : StateMachineBehaviour
{
    private Transform player;
    private NavMeshAgent _agent;
    private Transform enemy;
    private SoundEffectsManager _soundEffectsManager;
    private AudioSource scream;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        //to stop enemy from moving while screaming
        _agent.updatePosition = false;
        
        _agent.SetDestination(player.transform.position);
        _soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        _soundEffectsManager.playSoundEffect(1);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //will check that scream animation is finished before monster runs
        _agent.SetDestination(player.transform.position);
        if (1 <= stateInfo.normalizedTime){
            {
                animator.SetBool("isRunning", true);
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // turn movement for enemy again
        _agent.updatePosition = true;
        animator.SetBool("isScreaming", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
