using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

public class AnimatorObserver : MonoBehaviour
{
    public Animator animator;
    public int layer = 0;
    private bool verbose = false;

    public delegate void ChangeState(PossibleStates prevState, PossibleStates state);
    public event ChangeState onTransition;

    Observable<PossibleStates> currentState;
    Dictionary<int, PossibleStates> statesHash = new Dictionary<int, PossibleStates>();

    private void Awake()
    {
        currentState = new Observable<PossibleStates>(PossibleStates.None);
        currentState.propertyUpdated += onStateChanged;
    }

    private void onStateChanged(PossibleStates prev, PossibleStates v)
    {
        if(onTransition != null)
        {
            onTransition(prev, v);
        }
        if (verbose)
        {
            print(prev.ToString() + " -> " + v.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string[] possibleStates = System.Enum.GetNames(typeof(PossibleStates));

        for (int i = 0; i < possibleStates.Length; i++)
        {
            var hash = Animator.StringToHash(possibleStates[i]);
            PossibleStates state = (PossibleStates)System.Enum.Parse(typeof(PossibleStates), possibleStates[i]);
            statesHash.Add(hash, state);
        }
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(layer);
        var key = animatorStateInfo.shortNameHash;
        if (statesHash.ContainsKey(key)){
            currentState.val = statesHash[key];
        }
    }
}
