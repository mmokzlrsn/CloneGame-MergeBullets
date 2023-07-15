using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButton : MonoBehaviour
{
    public Bullet CurrentBullet;

    private void Start()
    {
        CurrentBullet.SetLevel(1);
        Debug.Log(CurrentBullet.GetLevel());
    }


    public void BuyBullet()
    {
        //money check later on
        //bulletspawnmanager check
        //assign current bullet into an empty slot, then assign the UI and other properties
        var emptyBulletSlot = BulletSpawnManager.instance.ReturnEmptyBulletSlot();

        if (emptyBulletSlot != null)
        {
             
            Bullet newBullet = Instantiate(CurrentBullet, emptyBulletSlot.BulletSpawnPoint3D);

            newBullet.SetLevel(CurrentBullet.GetLevel()); // Assign the level of CurrentBullet to the new bullet
            emptyBulletSlot.Bullet = newBullet;

            // Set other properties of the new bullet if needed

            emptyBulletSlot.SetBulletUI();
        }

        BulletSpawnManager.instance.SaveBulletSlots();
        BulletSpawnManager.instance.LoadBulletSlots();
    }


}
