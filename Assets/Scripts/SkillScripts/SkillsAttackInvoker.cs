using System;
using System.Collections.Generic;
using UnityEngine;

public class SkillsAttackInvoker : MonoBehaviour
{

    [SerializeField] private List<Skill> _skills;
    public event Action<int> OnAttack;

    private void Start()
    {
        if(_skills.Count > 9)
            throw new Exception("Skill more than 9");

        for(int i = 1; i < _skills.Count; i++)
        {
            _skills[i].Id = i;
        }
    }
    void Update()
    {
        for (int i = 1; i < _skills.Count; i++)
        {
            if (Input.GetKeyDown("Alpha" + i))
            {
               OnAttack(i); 
            }
        }
    }
}
