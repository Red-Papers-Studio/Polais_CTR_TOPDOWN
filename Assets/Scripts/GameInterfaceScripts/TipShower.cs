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
            _textObject.text = "WASD ��� ��������� - �����������\n" +
                           "Space ��� F - ���������\n" +
                           "Q - ����� ������\n" +
                           "��� - �����";

            _isActive = true;
        }
        else
        {
            if(!_isActive)
            {
                _textObject.text = "������� �� TAB ��� ���������.";
            }
            else
            {
                _tipObject.SetActive(false);
            }    
        }
    }
}
