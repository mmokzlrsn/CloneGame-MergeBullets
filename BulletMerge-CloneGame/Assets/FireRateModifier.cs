using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRateModifier : MonoBehaviour
{
    [SerializeField] float modifyValue = 0.1f;


    public void Decrease()
    {
        foreach (var pistol in PistolManager.instance.pistols)
        {
            pistol.FireRate -= modifyValue;
        }
    }

    public void Increase()
    {
        foreach (var pistol in PistolManager.instance.pistols)
        {
            pistol.FireRate += modifyValue;
        }
    }
}
