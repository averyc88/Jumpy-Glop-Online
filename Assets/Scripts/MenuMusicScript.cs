using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuMusicScript : MonoBehaviour
{
    public AudioSource MenuMusic;
    public static MenuMusicScript instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(transform.gameObject);
            MenuMusic = GetComponent<AudioSource>();
            MenuMusic.loop = true;
        }
        
    }
    // Start is called before the first frame update

    public void playMusic()
    {
        if (MenuMusic.isPlaying) {
            return;
        }
        else
        {
            MenuMusic.Play();
        }
    }

    public void stopMusic()
    {
        MenuMusic.Stop();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
