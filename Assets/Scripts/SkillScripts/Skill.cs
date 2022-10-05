using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [HideInInspector]public int Id;

    [SerializeField] private SkillView _view;
    [SerializeField] private SkillData _skillData;

    private void Awake()
    {
        _view.Init(_skillData);
    }
    protected abstract void AttackAction(SkillData skillData);

    public void OnAttackHandle(int id)
    {
        if (_view.isReloaded == true && id == Id)
        {
            AttackAction(_skillData);
            _view.isReloaded = false;
            _view.StartReloading();
        }
    }
}
