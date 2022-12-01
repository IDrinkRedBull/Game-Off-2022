using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    Sprite origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = gameObject.GetComponent<Sprite>();
    }


    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
