using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [HideInInspector]public int Id;

    [SerializeField] private SkillView _view;
    [SerializeField] private SkillData _skillData;
    [SerializeField] private SkillsAttackInvoker _attackInvoker;

    private void Start()
    {
        _view.Init(_skillData);
        _attackInvoker.OnAttack += OnAttackHandle;
    }
    protected abstract void AttackAction(SkillData skillData);

    private void OnAttackHandle(int id)
    {
        if (_view.isReloaded == true && id == Id)
        {
            AttackAction(_skillData);
            _view.isReloaded = false;
            _view.StartReloading();
        }
    }
}
