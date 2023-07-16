using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int level;
    private float speed = 10f;  // Speed of the bullet
    public float lifetime = 6f;  // Time before the bullet is destroyed

    private Rigidbody rb;  // Reference to the Rigidbody component
    private void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the Rigidbody component
    }
    public int GetLevel()
    {
        return level;
    }

    public void SetLevel(int value)
    {
        level = value;
    }

    [SerializeField] private Sprite imageUI;

    public Sprite GetImageUI()
    {
        return imageUI;
    }

    public void SetImageUI(Sprite value)
    {
        imageUI = value;
    }

    public void ClearImageUI()
    {
        imageUI = null;
    }

    public void Fire()
    {
        rb.velocity = transform.forward * speed;  // Set the initial velocity of the bullet
    }


    [SerializeField] private GameObject ammoModel;

    private GameObject GetAmmoModel()
    {
        return ammoModel;
    }

    private void SetAmmoModel(GameObject value)
    {
        ammoModel = value;
    }

    public void SetBullet(Bullet bullet)
    {
        SetLevel(bullet.level);
        SetImageUI(bullet.imageUI);
        SetAmmoModel(bullet.ammoModel);
    }
}
