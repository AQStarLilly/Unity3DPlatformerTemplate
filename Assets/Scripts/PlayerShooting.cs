using UnityEngine;
using UnityEngine.InputSystem; // Required for new Input System

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Transform firePoint;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 3f;

    private PlayerInput playerInput;
    private InputAction shootAction;

    void Awake()
    {
        // Initialize Input System
        playerInput = GetComponent<PlayerInput>();
        if (playerInput != null)
        {
            shootAction = playerInput.actions["Shoot"]; // Match this with Input Actions Asset
        }
    }

    void Start()
    {
        firePoint = transform.Find("FirePoint");

        if (firePoint == null)
        {
            GameObject firePointObj = new GameObject("FirePoint");
            firePointObj.transform.SetParent(this.transform);
            firePointObj.transform.localPosition = new Vector3(0, 1, 1);
            firePointObj.transform.localRotation = Quaternion.identity;
            firePoint = firePointObj.transform;
        }
    }

    void Update()
    {
        if (shootAction != null && shootAction.WasPressedThisFrame())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (firePoint == null) return;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }

        Destroy(bullet, bulletLifetime);
    }
}
