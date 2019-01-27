using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHandler : MonoBehaviour
{
    public Sprite[] sprites;
    public AudioClip[] sounds;
    int counter = 3;
    // Start is called before the first frame update
    void Start()
    {
        //this.counter = 0;
        //MainCharacter.shared.isGameActive = true;
        //Object.Destroy(this.gameObject, 0.1f);
        //return;
        StartCoroutine(ChangeNumber());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ChangeNumber()
    {

        if (counter != 3) {
            yield return new WaitForSeconds(1.5f);
            this.GetComponent<AudioSource>().clip = sounds[counter];
            this.GetComponent<AudioSource>().Play();
        }
        else
        {
            this.GetComponent<AudioSource>().clip = sounds[counter];
            this.GetComponent<AudioSource>().Play();
        }
        if (counter == 0)
        {
            var sprite = sprites[counter];
            this.GetComponent<SpriteRenderer>().sprite = sprite;
            Object.Destroy(this.gameObject, 1.1f);
            yield return new WaitForSeconds(1);
            MainCharacter.shared.isGameActive = true;
            Camera.main.GetComponent<AudioSource>().Play();
        }
        else
        {
            var sprite = sprites[counter];
            this.GetComponent<SpriteRenderer>().sprite = sprite;
            counter--;
            yield return ChangeNumber();
        }
    }
}
