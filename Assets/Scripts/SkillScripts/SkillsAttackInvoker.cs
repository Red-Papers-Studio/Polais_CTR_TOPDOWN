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

        for(int i = 0; i < _skills.Count; i++)
        {
            _skills[i].Id = i+1;
            OnAttack += _skills[i].OnAttackHandle;
        }
    }
    void Update()
    {
        for (int i = 1; i < _skills.Count+1; i++)
        {
            if (Input.GetKeyDown(Enum.Parse<KeyCode>("Alpha" + i)))
            {
               OnAttack.Invoke(i); 
            }
        }
    }
}
