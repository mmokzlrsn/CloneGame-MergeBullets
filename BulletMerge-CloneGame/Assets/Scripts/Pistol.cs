using System.Linq;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    [SerializeField] float fireRate = 1f;   // Time delay between each shot
    [SerializeField] GameObject bulletPrefab; // Prefab of the bullet object
    [SerializeField] Transform bulletSpawnPoint; // Point where the bullet is spawned
    [SerializeField] float bulletLifetime = 2f; // Time in seconds before the bullet is destroyed
    [SerializeField] float bulletSizeModifier = 1f; // Size modifier for the bullet
    public bool CanJoin = false;
    public bool CanShoot = false;

    private float nextFireTime; // Time when the next shot can be fired
 
    private void Update()
    {
        if (Time.time >= nextFireTime && CanShoot)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate a bullet object at the spawn point
        GameObject bullet = Instantiate(bulletPrefab.gameObject, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Set the scale of the bullet using the size modifier
        bullet.transform.localScale *= bulletSizeModifier;

        // Destroy the bullet after the specified lifetime
        Destroy(bullet, bulletLifetime);

        // Add force to the bullet to simulate shooting
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(bulletSpawnPoint.forward * 5f, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(Constants.BulletTag))
        {
            Debug.Log(gameObject.name + " " + other.gameObject.name);
            bulletPrefab = other.gameObject;
            Destroy(GetComponent<BoxCollider>());
            Destroy(other.gameObject);
            PistolManager.instance.pistols.Add(this);
        }
    }

}
