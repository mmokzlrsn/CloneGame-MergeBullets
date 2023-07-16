using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public Bullet CurrentBullet;
    public int BulletCost = 100;

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
        
        if (MoneyManager.instance.Money < BulletCost) return;


        var emptyBulletSlot = BulletSpawnManager.instance.ReturnEmptyBulletSlot();

        StartCoroutine(Util.CloseButtonInteraction(GetComponent<Button>(), 1f));
        if (emptyBulletSlot != null)
        {
            MoneyManager.instance.Money -= BulletCost;
            Bullet newBullet = Instantiate(CurrentBullet, emptyBulletSlot.BulletSpawnPoint3D);
            
            newBullet.gameObject.SetActive(false);
            newBullet.SetLevel(CurrentBullet.GetLevel()); // Assign the level of CurrentBullet to the new bullet
            emptyBulletSlot.Bullet = newBullet;

            // Set other properties of the new bullet if needed

            emptyBulletSlot.SetBulletUI();
        }

        BulletSpawnManager.instance.SaveBulletSlots();
        BulletSpawnManager.instance.LoadBulletSlots();
    }


}
