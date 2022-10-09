using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [HideInInspector]public int Id;

    [SerializeField] private SkillView _view;
    [SerializeField] private SkillData _skillData;

    protected static bool _isSkillActive;

    private void Awake()
    {
        _view.Init(_skillData);
    }
    protected abstract void AttackAction(SkillData skillData);

    public void OnAttackHandle(int id)
    {
        if (_view.isReloaded == true && id == Id && !_isSkillActive)
        {
            _isSkillActive = true;
            AttackAction(_skillData);
            _view.isReloaded = false;
            _view.StartReloading();
        }
    }
}
