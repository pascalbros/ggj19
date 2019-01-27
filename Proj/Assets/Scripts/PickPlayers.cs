using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickPlayers : MonoBehaviour
{
    public static int numberOfPlayers = 1;

    public int players = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(players);
        PickPlayers.numberOfPlayers = players;
        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
