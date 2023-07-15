using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletSlot : MonoBehaviour
{
    public Bullet Bullet;
    public Image BulletUI;
    public Transform BulletSpawnPoint3D;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBulletNull()
    {
        BulletUI = null;

    }

    public void SetBulletUI()
    {
        if (BulletUI != null) 
        {
            BulletUI.sprite = Bullet.GetImageUI();
        }
        else
        {
            BulletUI.sprite =null;
        }
    }

    

}
