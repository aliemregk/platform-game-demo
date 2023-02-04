using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public static int activeScene;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && activeScene == 1)
        {
            activeScene = 2;
            SceneManager.LoadScene(2);
        }
        else if(other.tag == "Player" && activeScene == 2)
        {
            activeScene = 3;
            SceneManager.LoadScene(3);
        }
        else if(other.tag == "Player" && activeScene == 3)
        {
            activeScene = 4;
            Time.timeScale = 0;
        }
    }
}
