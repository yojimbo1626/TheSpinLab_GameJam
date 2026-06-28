using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RedRingScript : MonoBehaviour
{

    public InputAction ringRight;
    public GameObject startPanel;
    public GameObject nextLevelPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public CollisionController collisionControllerScript;
    public InputAction ringLeft;
    public InputAction switchRing;
    public float speed;
    public int ringCount = 0;
    public GameObject temp;
    public GameObject[] rings;
    public int count = 0;
    private bool start = false;
    private AudioSource audioSource;
    public AudioClip deathSound;
    public AudioClip winLevelSound;
    public AudioClip winGameSound;
    private bool soundPlayed = false;

    [SerializeField] private CannonCollision cannonCollision;
   
    void Start()
     {
        audioSource = GetComponent<AudioSource>();

        nextLevelPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        if (winPanel)
        {
            winPanel.SetActive(false);
        }

        rings = GameObject.FindGameObjectsWithTag("Ring").OrderBy(go => go.name).ToArray();
        ringCount = rings.Length;
        temp = rings[0];
        
        
        temp.GetComponent<SpriteRenderer>().color = Color.black;
        foreach (GameObject ring in rings)
        {
            Debug.Log(ring);
        }
        Debug.Log("temp: " + temp);

    }

    void Update()
    {
        if (collisionControllerScript.canProceed == true)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            int currentSceneNum = int.Parse(currentScene.Substring(5,1));
            
            if (currentSceneNum + 3 == SceneManager.sceneCountInBuildSettings)
            {
                if (soundPlayed == false)
                {
                    audioSource.PlayOneShot(winGameSound);
                    soundPlayed = true;
                }
                winPanel.SetActive(true);
            }

            else
            {
                if (soundPlayed == false)
                {
                    audioSource.PlayOneShot(winLevelSound);
                    soundPlayed = true;
                }
                nextLevelPanel.SetActive(true);
            }

        }

        if (collisionControllerScript.isDead == true)
        {
            if (soundPlayed == false)
                {
                    audioSource.PlayOneShot(deathSound);
                    soundPlayed = true;
                }
            gameOverPanel.SetActive(true);   
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Enter");
            start = true;
            startPanel.SetActive(false);

            if (nextLevelPanel.activeSelf == true)
            {
                string currentScene = SceneManager.GetActiveScene().name;
                currentScene = currentScene.Substring(5,1);
                SceneManager.LoadScene("Stage" + (int.Parse(currentScene) + 1).ToString());
            }

            if (gameOverPanel.activeSelf == true)
            {
                string currentScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentScene);
            }

            if (winPanel)
            {
                if (winPanel.activeSelf == true)
                    {
                        SceneManager.LoadScene("MainMenuScene");
                    }
            }
            
        }



        if (start == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
        {
            if (ringCount > 1)
            {
                rings[count].GetComponent<SpriteRenderer>().color = Color.red;
                ++count;
                if (count >= ringCount)
                {
                    
                    count = 0;
                }
                temp = rings[count];
                rings[count].GetComponent<SpriteRenderer>().color = Color.black;

            }
        } else if (Input.GetKeyDown(KeyCode.X))
        {
            if (ringCount > 1)
            {
                rings[count].GetComponent<SpriteRenderer>().color = Color.red;
                --count;
                if (count < 0)
                {
                    count = ringCount-1;
                }
                temp = rings[count];
                rings[count].GetComponent<SpriteRenderer>().color = Color.black;
            }
        }


       if (Input.GetKey(KeyCode.RightArrow))
        {
            
            if (cannonCollision != null)
            {
                if (!cannonCollision.isTouchingRight)
                {
                    temp.transform.Rotate(Vector3.back, speed * Time.deltaTime);
                } 
            } else
            {
                Debug.Log("right");
                Debug.Log(temp);
                temp.transform.Rotate(Vector3.back, speed * Time.deltaTime);
            }
            
            
        } else if (Input.GetKey(KeyCode.LeftArrow))
        {
           
            if (cannonCollision != null)
            {
                if (!cannonCollision.isTouchingLeft)
                {
                    temp.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
                }
            } else
            {
                 Debug.Log("left");
                temp.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
            }
            
            
        }
        }
        

        

    }


}
