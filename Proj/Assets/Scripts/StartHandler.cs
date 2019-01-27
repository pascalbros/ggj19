using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartHandler : MonoBehaviour
{
    public Sprite[] sprites;
    int counter = 3;
    // Start is called before the first frame update
    void Start()
    {
        this.counter = 0;
        Object.Destroy(this.gameObject, 0.1f);
        return;
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
        }
        if (counter == 0)
        {
            var sprite = sprites[counter];
            this.GetComponent<SpriteRenderer>().sprite = sprite;
            Object.Destroy(this.gameObject, 1.1f);
            yield return new WaitForSeconds(1);
            MainCharacter.shared.isGameActive = true;
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
