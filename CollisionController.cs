using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour
{

    [SerializeField] private BulletScript bulletScript;
    [SerializeField] private CharScript charScript;
 //  [SerializeField] private CharScript charScript;
    public GameObject portalLeave;
    public Rigidbody2D player;
    public GameObject explosionEffect;
    public bool canProceed = false;
    public bool isDead = false;
    private AudioSource audioSource;
    public AudioClip portalSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ring" || collision.gameObject.name == "Boundary" || collision.gameObject.name == "Boundary (1)" || collision.gameObject.name == "Boundary (2)")
        {
            Debug.Log("COME ON MAN");
            Debug.Log(collision.gameObject.name);
            // Instantiate(explosionEffect, transform.position, transform.rotation);
            isDead = true;
            Destroy(gameObject);
        } 

        // if (collision.gameObject.name == "Exit")
        // {
        //     string curScene = SceneManager.GetActiveScene().name;
        //     char lvlNum = curScene[curScene.Length-1];
        //     int iLvlNum = (lvlNum - '0') + 1;
        //   //  lvlNum = iLvlNum + '0';
        //     string nextScene = curScene.Remove(curScene.Length-1) + lvlNum;
        //     Debug.Log(nextScene);
        //     LoadSceneByName("Stage4");
        // }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Switch")
        {
            bulletScript.CancelInvoke();
           // Destroy(bulletScript.bullet);
        } 

        if (collision.gameObject.name == "PortalEnter")
        {
            audioSource.PlayOneShot(portalSound);
            string tagPortal = collision.gameObject.tag;
          //  Destroy(gameObject);
          //  LaunchPlayer();
            portalLeave = GameObject.FindWithTag(tagPortal + "Leave");
            if (portalLeave)
            {
                
                GameObject child = portalLeave.transform.Find("DirPoint").gameObject;
                transform.position = child.transform.position;
                charScript.travelDirection = (child.transform.position)-portalLeave.transform.position;
            } else
            {
                Debug.Log("PortalLeave error");
            }
            
        }

        if (collision.gameObject.name == "Exit")
        {
            if (bulletScript)
            {
                bulletScript.CancelInvoke();
            }
            
            gameObject.SetActive(false);
            canProceed = true;
            
           // Destroy(bulletScript.bullet);
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

    void LaunchPlayer()
    {
        Rigidbody2D instance = Instantiate(player, portalLeave.transform.position, Quaternion.Euler(portalLeave.transform.rotation.x, portalLeave.transform.rotation.y, portalLeave.transform.rotation.z));

        instance.linearVelocity = transform.eulerAngles * 1f;
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
