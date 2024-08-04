using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingularHighScoreScript : MonoBehaviour
{
    public static SingularHighScoreScript instance;
    public int highScore;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
