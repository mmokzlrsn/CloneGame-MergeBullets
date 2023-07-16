using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolManager : MonoBehaviour
{
    public static PistolManager instance;
    public List<Pistol> pistols;
    public Transform[] pistolPositions;
    float timeToArrive = 1f;

    private void Awake()
    {
        instance = this;
    }

    public void SetPistolPositions()
    {
        for(int i = 0; i < pistols.Count; i++)
        {
            var temp = pistols[i];
            temp.transform.DOMove(pistolPositions[i].transform.position, timeToArrive).SetEase(Ease.Linear).OnComplete(() =>
            {
                temp.CanShoot = true;
            });
            pistols[i].transform.SetParent(InputManager.instance.gameObject.transform, false);
            //pistols[i].CanShoot = true;

        }
    }

    

    
}
