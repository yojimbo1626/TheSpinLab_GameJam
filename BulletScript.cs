using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Rigidbody2D bullet;

    void Start()
    {
        InvokeRepeating(nameof(LaunchProjectile), 0.5f, 0.2f);
    }

    public void LaunchProjectile()
    {
        // float angleInDegrees = 45f;
        // float radians = angleInDegrees * Mathf.Deg2Rad;
        // Vector2 direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));

        Rigidbody2D instance = Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));


        instance.linearVelocity = transform.right * 5f;
    }

    void Update()
    {
        
    }
}
