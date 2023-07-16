using System.Linq;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float FireRate = 1f;   // Time delay between each shot
    [SerializeField] GameObject bulletPrefab; // Prefab of the bullet object
    [SerializeField] Transform bulletSpawnPoint; // Point where the bullet is spawned
    public float BulletLifetime = 2f; // Time in seconds before the bullet is destroyed
    public float BulletSizeModifier = 1f; // Size modifier for the bullet
    [SerializeField] float bulletSpeed = 15f;
    public bool CanJoin = false;
    public bool CanShoot = false;

    private float nextFireTime; // Time when the next shot can be fired
 
    private void Update()
    {
        if (Time.time >= nextFireTime && CanShoot)
        {
            nextFireTime = Time.time + 1f / FireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate a bullet object at the spawn point
        GameObject bullet = Instantiate(bulletPrefab.gameObject, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Set the scale of the bullet using the size modifier
        bullet.transform.localScale *= BulletSizeModifier;

        // Destroy the bullet after the specified lifetime
        Destroy(bullet, BulletLifetime);

        // Add force to the bullet to simulate shooting
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletSpawnPoint.forward * bulletSpeed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Constants.BulletTag))
        {
            Debug.Log(gameObject.name + " " + other.gameObject.name);
            bulletPrefab = other.gameObject;
            Destroy(GetComponent<BoxCollider>());
            bulletPrefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
            PistolManager.instance.pistols.Add(this);
        }
    }

}
