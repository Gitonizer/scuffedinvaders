using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    private Animator _animator;
    public Action ButtonAction;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Initialize(Action action)
    {
        ButtonAction = action;
    }
    public void Select()
    {
        _animator.SetBool("Select", true);
    }
    
    public void Deselect()
    {
        _animator.SetBool("Select", false);
    }
}
