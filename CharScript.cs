using UnityEngine;
using UnityEngine.InputSystem;

public class CharScript : MonoBehaviour
{
    
    private bool start = false;
    private Vector2 endPos;
    public InputAction speedUp;
    public float speed;
    private float tempSpeed;
    // public float targetAngle = 70f;
    // public float startX = 0f;
    // public float startY = 0f;
    public Vector2 travelDirection;
    
    void Start()
    {
        speedUp = InputSystem.actions.FindAction("SpeedUp");
        travelDirection = new Vector2(0f,1f);
        tempSpeed = speed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            start = true;
        }

        if (start == true)
        {
            endPos = (travelDirection * 1000f);
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed*Time.deltaTime);

            if (speedUp.IsPressed())
            {
                speed = tempSpeed*3;
                
            } else
            {
                speed = tempSpeed;
            }
        }
        

        
        
        
    }

    
}
