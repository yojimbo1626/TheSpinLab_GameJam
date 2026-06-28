using UnityEngine;

public class CannonCollision : MonoBehaviour
{
    public bool isTouchingLeft = false;
    public bool isTouchingRight = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "CoveringColliderLeft")
        {
            isTouchingLeft = true;
        } else if (collision.gameObject.name == "CoveringColliderRight")
        {
            isTouchingRight = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "CoveringColliderLeft")
        {
            isTouchingLeft = true;

        } else if (collision.gameObject.name == "CoveringColliderRight")
        {
            isTouchingRight = true;

        } 
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "CoveringColliderLeft")
        {
            isTouchingLeft = false;
            
        } 
        if (collision.gameObject.name == "CoveringColliderRight")
        {
            isTouchingRight = false;
            
        } 
    }
}
