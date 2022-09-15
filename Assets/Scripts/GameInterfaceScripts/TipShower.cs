using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipShower : MonoBehaviour
{
    [SerializeField] GameObject _tipObject;
    void Update()
    {
        if(!(Input.GetAxis("TipShow") < 1))
        {
            _tipObject.SetActive(true);
        }
        else
        {
            _tipObject.SetActive(false);
        }
    }
}
