using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public Rigidbody2D bullet;
    private bool start = false;
    void Start()
    {
        InvokeRepeating(nameof(LaunchProjectile), 0.5f, 0.2f);
    }

    public void LaunchProjectile()
    {
        Rigidbody2D instance = Instantiate(bullet, transform.position, Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));

        instance.linearVelocity = transform.right * 5f;
    }

    void Update()
    {
        // if (Input.GetKey(KeyCode.K))
        // {
        //     start = true;
        // }
    }
}
