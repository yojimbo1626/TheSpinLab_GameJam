using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;

    void Awake()
    {
        // Singleton pattern to prevent duplicate music players if you return to the first scene
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        
        // This ensures the GameObject persists across scene loads
        DontDestroyOnLoad(this.gameObject);
    }
}
