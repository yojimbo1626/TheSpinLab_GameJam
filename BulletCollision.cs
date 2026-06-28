using UnityEngine;

public class BulletCollision : MonoBehaviour

{
    [SerializeField] private BulletScript bulletScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            bulletScript.CancelInvoke();
            Debug.Log("COME ON MAN");
          //  Destroy(gameObject);
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
