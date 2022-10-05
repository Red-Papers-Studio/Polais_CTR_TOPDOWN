using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Slider _slider;

    private void Start()
    {
        _image.transform.SetParent(_slider.transform);
        _slider.value = 0;
    }

    public void StartReloading(float time)
    {
        _slider.value = 100;
        Debug.Log("Reloadiiiiiiiing");
    }
}
