using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] private SkillView _view;
    [SerializeField] private SkillData _skillData;
    [SerializeField] private AttackInvoker _attackInvoker;

    private void Start()
    {
        _view.Init(_skillData);
        _attackInvoker.OnAttack += OnAttackHandle;
    }
    protected abstract void AttackAction(SkillData skillData);

    private void OnAttackHandle()
    {
        if (_view.isReloaded == true)
        {
            AttackAction(_skillData);
            _view.isReloaded = false;
            _view.StartReloading();
        }
    }
}
