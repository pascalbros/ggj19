using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    static Player one = null;
    static Player two = null;
    static Player three = null;
    static Player four = null;

    static Color[] colors = {
    new Color(1.0f, 0.0f, 0.0f, 1.0f),
    new Color(0.0f, 1.0f, 0.0f, 1.0f),
    new Color(0.0f, 0.0f, 1.0f, 1.0f),
    new Color(1.0f, 1.0f, 0.0f, 1.0f)
    };

    GameObject exclamationMark;
    public int playerNumber = 1;
    public float speed = 5.0f;

    private bool canCall = true;

    public int bacca = 1;

    // Start is called before the first frame update
    void Start()
    {
        this.SetupPlayerNumber(this.playerNumber);
        this.exclamationMark = transform.Find("warning").gameObject;
        this.exclamationMark.SetActive(false);
    }

    void SetupPlayerNumber(int number)
    {
        if (number == 1) {
            Player.one = this;
        }
        else if (number == 2)
        {
            Player.two = this;
        }
        else if (number == 3)
        {
            Player.three = this;
        }
        else if (number == 4)
        {
            Player.four = this;
        }
        this.playerNumber = number;
        this.SetupColor();
    }

    private void SetupColor()
    {
        //Color c = Player.colors[this.playerNumber - 1];
        //gameObject.GetComponent<SpriteRenderer>().color = c;
    }

    // Update is called once per frame
    float timeLeft = 5;
    void Update()
    {
        var move = new Vector3(Input.GetAxis("P"+playerNumber+" Horizontal") * bacca, Input.GetAxis("P" + playerNumber + " Vertical") * bacca, 0);
        this.transform.position += move * speed * Time.deltaTime;
        HandleCallButton();
        if(bacca < 0)
        {
            timeLeft -= Time.deltaTime;
            Debug.Log(Time.deltaTime + " " + timeLeft);
            if(timeLeft <= 0)
            {
                bacca = 1;
                timeLeft = 30;
            }
        }
    }

    private void HandleCallButton()
    {
        bool input = Input.GetButtonDown("P"+playerNumber+" Call");
        if (!input) { return; }
        if (!canCall) { return; }
        StartCoroutine(ShowWarning(3.0f));
        Vector3 pos1 = this.transform.position;
        Vector3 pos2 = MainCharacter.shared.transform.position;
        float direction = MainCharacter.GetDirection(pos1, pos2);
        MainCharacter.shared.direction = direction;
    }

    private float constraintAngle(float angle)
    {
        float result = angle - 90;
        if (result < 0)
        {
            result = 360 - Mathf.Abs(result);
        }
        return result;
    }

    IEnumerator ShowWarning(float seconds)
    {
        this.canCall = false;
        this.exclamationMark.SetActive(true);
        yield return new WaitForSeconds(seconds);
        exclamationMark.SetActive(false);
        this.canCall = true;
    }

    public static bool checkPlayers()
    {
        return Player.one != null || Player.two != null || Player.three != null || Player.four != null;
    }
}
