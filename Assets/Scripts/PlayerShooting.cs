using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;   // Bullet prefab to be instantiated when shooting
    private Transform firePoint;    // Fire point where bullets will spawn

    // Bullet Properties
    public float bulletSpeed = 20f;
    public float bulletLifetime = 3f;

    // Input System References
    private PlayerInput playerInput;
    private InputAction shootAction;

    void Awake()
    {
        // Get the playerInput componenet attached to this gameobject
        playerInput = GetComponent<PlayerInput>();
        // Ensure the PlayerInput component is found
        if (playerInput != null)
        {
            shootAction = playerInput.actions["Shoot"]; 
        }
    }

    void Start()
    {
        // Try to find an exsisting FirePoint child object
        firePoint = transform.Find("FirePoint");

        // If one isn't found, create one dynamically
        if (firePoint == null)
        {
            GameObject firePointObj = new GameObject("FirePoint");
            firePointObj.transform.SetParent(this.transform);     // Attach to player
            firePointObj.transform.localPosition = new Vector3(0, 1, 1);   // Set default position
            firePointObj.transform.localRotation = Quaternion.identity;   // Ensure proper rotation
            firePoint = firePointObj.transform;    // Assign to firePoint variable
        }
    }

    void Update()
    {
        // Check if the shoot action was pressed this frame
        if (shootAction != null && shootAction.WasPressedThisFrame())
        {
            Shoot();   // Call the shoot function
        }
    }

    void Shoot()
    {
        // Ensure there is a valid fire point before shooting
        if (firePoint == null) return;

        // Instantiate a new bullet at the fire point's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the Rigidbody component from the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // If the bullet has a Rigidbody, aply velocity to move it forward
        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }

        // Destroy the bullet after a specified lifetime to prevent memory issues
        Destroy(bullet, bulletLifetime);
    }
}
