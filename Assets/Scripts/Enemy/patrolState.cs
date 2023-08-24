using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class patrolState : StateMachineBehaviour
{
    private float timer;
    private NavMeshAgent _agent;
    private Transform player;
    private float chaseRange = 8;
    private List<Transform> wayPoints = new List<Transform>();
    private SoundEffectsManager _soundEffectsManager;
    private int patrolTimer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        _soundEffectsManager.playSoundEffect(2);
        _soundEffectsManager.setLoopSoundEffect(2, true);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = 1f;
        timer = 0;
        
        //choose random amount of time for monster to patrol before going idle again
        patrolTimer = Random.Range(3, 7);
       
        GameObject gameObject = GameObject.FindGameObjectWithTag("WayPoints");

        foreach (Transform t in gameObject.transform)
        {
            wayPoints.Add(t);
            _agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //choose random patrol point if monster reached original patrol point
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _agent.SetDestination(wayPoints[Random.Range(0, wayPoints.Count)].position);
        }
        
        timer += Time.deltaTime;
        if (patrolTimer < timer)
        {
            animator.SetBool("isPatrolling", false);
        }

        // iniate scream and run when player too close to monster
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < chaseRange)
        {
            animator.SetBool("isScreaming", true);
            animator.SetBool("isPatrolling" ,false);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _soundEffectsManager.pauseSoundEffect(2);
        _agent.SetDestination(_agent.transform.position);
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
