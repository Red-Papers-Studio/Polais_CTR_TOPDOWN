using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class GeneralAnimationController : MonoBehaviour
{
    public event Action<Animator,string> OnAnimatorInvoke;

    [HideInInspector]
    public Animator Animator { get; private set; }

    private void Start()
    {
        Animator = this.GetComponent<Animator>();
    }
    public void AnimationEventInvoke(string value)
    {
        OnAnimatorInvoke?.Invoke(Animator, value);
    }
}
