using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipShower : MonoBehaviour
{
    [SerializeField] GameObject _tipObject;
    [SerializeField] Text _textObject;
    private bool _isActive = false;
    void Update()
    {
        if(!(Input.GetAxis("TipShow") < 1))
        {
            _tipObject.SetActive(true);
            _textObject.text = "WASD или стрелочки - перемещение\n" +
                           "Space или F - ускорение\n" +
                           "Q - смена оружия\n" +
                           "ЛКМ - Атака";

            _isActive = true;
        }
        else
        {
            if(!_isActive)
            {
                _textObject.text = "Нажмите на TAB для подсказки.";
            }
            else
            {
                _tipObject.SetActive(false);
            }    
        }
    }
}
