using UnityEngine;
using UnityEngine.InputSystem;

public class CharScript : MonoBehaviour
{
    
    public GameObject exit;
    public InputAction speedUp;
    public float speed =1f;

    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speedUp = InputSystem.actions.FindAction("SpeedUp");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, exit.transform.position, speed*Time.deltaTime);

        if (speedUp.IsPressed())
        {
            speed = 3f;
            // if (speed == 3f)
            // {
            //     speed = 1f;
            // } else
            // {
            //     speed = 3f;
            // }
            
        } else
        {
            speed = 1f;
        }
        
    }

    //  [SerializeField] private bool isDragging = false;
    //  void OnMouseDown()
    // {
    //     Debug.Log("Mouse down");
    //     isDragging = !isDragging;
    // }

    
}
