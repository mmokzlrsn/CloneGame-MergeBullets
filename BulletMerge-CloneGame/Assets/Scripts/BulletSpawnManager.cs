using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class BulletSpawnManager : MonoBehaviour
{
    
    public static BulletSpawnManager instance;
    public Bullet[] bullets;
    public BulletSlot[] bulletSlots;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    { 
        LoadBulletSlots();
        SaveBulletSlots();
    }

    // Update is called once per frame
    public void SaveBulletSlots()
    {
        for (int i = 0; i < bulletSlots.Length; i++)
        {
            // Save the position and bullet level of each slot using PlayerPrefs
            if (bulletSlots[i].Bullet != null)
            {
                PlayerPrefs.SetString("BulletSlot" + i, bulletSlots[i].Bullet.name);
                // Save the bullet level
                Bullet bullet = bulletSlots[i].GetComponent<BulletSlot>().Bullet;
                if (bullet != null)
                {
                    PlayerPrefs.SetInt("BulletLevel" + i, bullet.GetLevel());
                }
            }
        }
    }

    // Called when the game restarts
    public void LoadBulletSlots()
    {
        for (int i = 0; i < bulletSlots.Length; i++)
        {
            if (PlayerPrefs.HasKey("BulletSlot" + i))
            {
                // Load the position of each slot from PlayerPrefs
                //Vector3 slotPosition = StringToVector(PlayerPrefs.GetString("BulletSlot" + i));
                //bulletSlots[i].position = slotPosition;
                
                // Load the bullet level
                if (PlayerPrefs.HasKey("BulletLevel" + i))
                {
                    if (PlayerPrefs.GetInt("BulletLevel" + i) != 0)
                    {
                        int bulletLevel = PlayerPrefs.GetInt("BulletLevel" + i);
                        //load from manager
                        
                        if (bulletSlots[i].Bullet == null)
                        {                             
                            // Spawn the bullet at the calculated position
                            Bullet bullet = Instantiate(bullets[bulletLevel - 1], bulletSlots[i].BulletSpawnPoint3D,false); 

                            bulletSlots[i].Bullet= bullet;
                            bulletSlots[i].Bullet.SetBullet(bullet);
                        }
                    }
                }

                bulletSlots[i].SetBulletUI();
            }
        }
    }

    public void FireAllBullets()
    {
        for(int i = 0; i < bulletSlots.Length; i++)
        {
            if (bulletSlots[i].Bullet != null)
                bulletSlots[i].Bullet.Fire();
        }
    }





    public BulletSlot ReturnEmptyBulletSlot()
    {
        for(int i = 0; i < bulletSlots.Length; i++)
        {
            if (bulletSlots[i].Bullet == null)
                return bulletSlots[i];
        }
        return null;
    }
    public void MergeSameLevelBullets()
    {
        //search for a bullet
        for (int i = 0; i < bulletSlots.Length; i++)
        {
            for (int j = 0; j < bulletSlots.Length; j++)
            {
                if (i == j)
                { 
                    continue; 
                }

                if (bulletSlots[i].Bullet != null && bulletSlots[j].Bullet != null)
                {
                    if(bulletSlots[i].Bullet.GetLevel() == bulletSlots[j].Bullet.GetLevel())
                    {
                        if (bulletSlots[i].Bullet.GetLevel() < bullets.Length)
                        {
                            var newBulletLevel = bulletSlots[i].Bullet.GetLevel() + 1;
                            //upgrade the level of first node than remove the old one
                            Destroy(bulletSlots[i].BulletSpawnPoint3D.GetChild(0).gameObject);
                            //Debug.Log("destroyed");
                            Bullet bullet = Instantiate(bullets[newBulletLevel - 1], bulletSlots[i].BulletSpawnPoint3D, false);
                            bulletSlots[i].Bullet = bullet;
                            bulletSlots[i].Bullet.SetBullet(bullet);

                            PlayerPrefs.DeleteKey("BulletSlot" + j);
                            PlayerPrefs.DeleteKey("BulletLevel" + j);
                            bulletSlots[j].BulletUI.sprite = null;
                            Destroy(bulletSlots[j].BulletSpawnPoint3D.GetChild(0).gameObject);
                            bulletSlots[j].Bullet = null;

                            return;
                        }
                        
                    }
                }
            }
        }

    }


}
