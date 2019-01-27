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

    public AudioClip[] heySounds;

    GameObject exclamationMark;
    public int playerNumber = 1;
    public float speed = 5.0f;

    AudioSource audioSource;

    private bool canCall = true;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource source = GetComponent<AudioSource>();
        this.audioSource = source;
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
    void Update()
    {
        if (!MainCharacter.shared.isGameActive) { return; }
        var move = new Vector3(Input.GetAxis("P"+playerNumber+" Horizontal"), Input.GetAxis("P" + playerNumber + " Vertical"), 0);
        this.transform.position += move * speed * Time.deltaTime;
        HandleCallButton();
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
        var clip = this.heySounds[Random.Range(0, heySounds.Length)];
        this.audioSource.PlayOneShot(clip);
        this.canCall = false;
        this.exclamationMark.SetActive(true);
        yield return new WaitForSeconds(seconds);
        exclamationMark.SetActive(false);
        this.canCall = true;
    }
}
