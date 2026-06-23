using UnityEngine;
using UnityEngine.InputSystem.Android.LowLevel;

public class CollisionController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RedRing_Prefab")
        {
            Debug.Log("COME ON MAN");
            Destroy(gameObject);
        } 
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        // if (collision.gameObject.name == "RedRing_Prefab")
        // {
        //     Debug.Log("stay");
        // } else
        // {
        //     Debug.Log("nope");
        // }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RedRing_Prefab")
        {
            Debug.Log("exit");
        } else
        {
            Debug.Log("nope");
        }
    }

    // [SerializeField] private bool isDragging = false;
    //  void OnMouseDown()
    // {
    //     Debug.Log("Mouse down");
    //     isDragging = !isDragging;
    // }

}
