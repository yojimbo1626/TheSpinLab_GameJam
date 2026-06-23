using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RedRingScript : MonoBehaviour
{

    public InputAction ringRight;
    public InputAction ringLeft;
    public InputAction switchRing;
    public float speed = 2000f;
    public int ringCount = 0;
    public GameObject temp;
    public GameObject[] rings;
    public int count = 0;

    [SerializeField] private CannonCollision cannonCollision;
   

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     Debug.Log("Colis enter");
    //     if (collision.gameObject.name == "CoveringCollider")
    //     {
    //         isTouching = true;
    //         Debug.Log("Is Covering");
    //     } 
    // }
    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.name == "CoveringCollider")
    //     {
    //         isTouching = false;
            
    //     } 
    // }
    

//    [SerializeField] private bool isDragging = false;
    void Start()
     {
        rings = GameObject.FindGameObjectsWithTag("Ring");
        ringCount = rings.Length;

        // Loop through the array to interact with each object
        foreach (GameObject ring in rings)
        {
            
        }
    }

    void Update()
    {
       if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!cannonCollision.isTouchingRight)
            {
                temp.transform.Rotate(Vector3.back, speed * Time.deltaTime);
            } 
            
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!cannonCollision.isTouchingLeft)
                {
                    temp.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
                }
            
        } else

        if (Input.GetKey(KeyCode.Z))
        {
            if (ringCount > 1)
            {
                ++count;
                if (count >= ringCount)
                {
                    count = 0;
                }
                temp = rings[count];
            }
        }
   

    }

    // private void OnMouseDown()
    // {
    //     Debug.Log("Mouse down");
    //     isDragging = true;
    // }

    // private void OnMouseUp()
    // {
    //     Debug.Log("Mouse up");
    //     isDragging = false;
    // }

    ////CANON code
    

}
