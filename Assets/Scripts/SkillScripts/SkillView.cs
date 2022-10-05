using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Slider _slider;
    private SkillData _skillData;

    public bool isReloaded = true;
    private float _timeSinceLastCast = 0;
    private void Start()
    {
        _slider.value = 0;
        _timeSinceLastCast = _skillData.CD;
    }

    private void FixedUpdate()
    {
        Reloading();
    }

    public void Init(SkillData skillData)
    {
        _skillData = skillData;
        _image.sprite = skillData.Sprite;
    }

    public void StartReloading()
    {
        _slider.value = 100;
        _timeSinceLastCast = 0;
        Debug.Log("Reloadiiiiiiiing");
    }

    private void Reloading()
    {
        if (_timeSinceLastCast < _skillData.CD)
        {
            _timeSinceLastCast += Time.deltaTime;
            _slider.value -= _slider.value / _skillData.CD * Time.deltaTime;
        }
        else
            isReloaded = true;
    }
}
