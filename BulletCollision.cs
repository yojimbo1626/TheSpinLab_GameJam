using UnityEngine;

public class BulletCollision : MonoBehaviour

{
    [SerializeField] private BulletScript bulletScript;
    public GameObject explosionEffect;
    public CollisionController collisionControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            bulletScript.CancelInvoke();
            Debug.Log("COME ON MAN3");
            //Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            collisionControllerScript.isDead = true;
        }

    }

    // void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.gameObject.name == "Character")
    //     {
    //         Debug.Log("COME ON MAN");
    //       //  Destroy(gameObject);
    //     }
    // }

    // Update is called once per frame

}
