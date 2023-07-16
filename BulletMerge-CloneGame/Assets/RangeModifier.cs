using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeModifier : MonoBehaviour , Modifier
{
    [SerializeField] float modifyValue = 0.1f;


    public void Decrease()
    {
        foreach(var pistol in PistolManager.instance.pistols) {
            pistol.BulletLifetime -= modifyValue;
        }
    }

    public void Increase()
    {
        foreach (var pistol in PistolManager.instance.pistols)
        {
            pistol.BulletLifetime += modifyValue;
        }
    }

     
}
