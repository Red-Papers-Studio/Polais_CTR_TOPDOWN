using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] private SkillView _view;
    [SerializeField] private SkillData _skillData;
    [SerializeField] private AttackInvoker _attackInvoker;

    private float _lastAttackTime;

    private void Start()
    {
        _attackInvoker.OnAttack += OnAttackHandle;
    }
    protected abstract void AttackAction(SkillData skillData);

    private void OnAttackHandle()
    {
        if (_lastAttackTime - Time.time < _skillData.CD)
        {
            AttackAction(_skillData);
            _view.StartReloading(_skillData.CD);
            _lastAttackTime = Time.time;
        }
    }
}
