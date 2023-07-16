using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MergeBullet : MonoBehaviour
{
    public void ApplyMerge()
    {
        //search same level 2 bullet 
        //if any merge them into the first ones position then save the manager then update ui
        StartCoroutine(Util.CloseButtonInteraction(GetComponent<Button>(), 1f));

        BulletSpawnManager.instance.MergeSameLevelBullets();

        BulletSpawnManager.instance.SaveBulletSlots();
        BulletSpawnManager.instance.LoadBulletSlots();
    }
}
