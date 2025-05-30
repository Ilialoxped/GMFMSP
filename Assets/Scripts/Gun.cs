using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] public Transform firePoint;
    [SerializeField] private float bulletSpeed = 20f;
    

    private void Start()
    {
        var shootAction = new InputAction(binding: "<Mouse>/leftButton");
        shootAction.performed += ctx => Shoot();
        shootAction.Enable();
    }
    

    private void Shoot()
    {
       
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = firePoint.forward * bulletSpeed;
        }

        
        Destroy(bullet, 3f);
    }
}
