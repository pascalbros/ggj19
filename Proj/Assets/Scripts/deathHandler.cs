using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void deathScreen()
    {
        SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
    }

    public void menuScreen()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
