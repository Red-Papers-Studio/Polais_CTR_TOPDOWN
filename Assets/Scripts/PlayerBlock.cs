using UnityEngine;
using System;

public class PlayerBlock : MonoBehaviour
{
    public static Action Block;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Block?.Invoke();
        }
    }
}
