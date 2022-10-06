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
            _textObject.text = "WASD - Movement\n" +
                           "Space or F - Acceleration\n" +
                           "Q - Weapon change\n" +
                           "Mouse0 - Attack\n" +
                           "1,2...9 - Use skills";

            _isActive = true;
        }
        else
        {
            if(!_isActive)
            {
                _textObject.text = "Press TAB for a tips";
            }
            else
            {
                _tipObject.SetActive(false);
            }    
        }
    }
}
