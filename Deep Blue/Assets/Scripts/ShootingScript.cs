using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;  // Bullet prefab to instantiate
    public float bulletSpeed = 15f;  // Speed of the bullet
    public float cooldownTime = 0.5f;  // Cooldown between shots

    private float timeSinceLastShot = 0f;  // Timer for cooldown

    private float timeButtonHeldDownFor = 0f;

    public float chargeTime = 2.1f;

    public int numOfBullets = 1;

    public float bulletDamage = 1.1f;

    public int bulletPierce = 1;

    public float bulletsize = 0.08f;
    public float bulletColliderSize = 5;

    public AudioSource shootingAudio;


    public Vector3 direction;
    Vector3 bulletPosition;

     void Start()
    {
        
    }

    void Update()
    {
        // Increment the timer
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetMouseButton(0) && timeSinceLastShot >= cooldownTime)
        {

            if (timeButtonHeldDownFor <= 2.3)
            {
                timeButtonHeldDownFor += Time.deltaTime * 2;
            }

        }
        else if (Input.GetMouseButtonUp(0) && timeSinceLastShot >= cooldownTime)
        {
            Vector3 bulletPosition = BulletPosition();

            timeSinceLastShot = 0;
            Shoot();



        }

    }

    Vector3 BulletPosition()
    {


        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;  // Ensure it's on the same plane (z = 0)

        // Get the direction from the player to the mouse position
        direction = (mousePosition - transform.position).normalized;

        bulletPosition = transform.position + direction * 1.3f;
        
        return bulletPosition;
    }

    public void Shoot()
    {

            float spread = 10f; // total spread in degrees; adjust to your taste
            int center = numOfBullets / 2;

            for (int i = 0; i < numOfBullets; i++)
            {
                float angle = (i - center) * spread;
                Vector3 directionOffset = Quaternion.AngleAxis(angle, Vector3.forward) * direction;

                float angleZ = Mathf.Atan2(directionOffset.y, directionOffset.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0f, 0f, angleZ);

                GameObject bullet = Instantiate(bulletPrefab, bulletPosition, rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

                rb.linearVelocity = directionOffset * bulletSpeed * timeButtonHeldDownFor;
            }

            shootingAudio.Play();

            timeSinceLastShot = 0f;
            timeButtonHeldDownFor = 0f;
    }


}
