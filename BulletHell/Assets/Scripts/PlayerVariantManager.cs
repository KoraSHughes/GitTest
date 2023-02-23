using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVariantManager : MonoBehaviour
{   
    // Start is called before the first frame update
    public string[] colorArray;

    public Sprite[] spriteArray;

    private SpriteRenderer _sprite_renderer;
    

    private int currentIndex = 0;
    void Start()
    {
        _sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            StartCoroutine(SpriteSwap());
        }
    }

    IEnumerator SpriteSwap()
    {
        currentIndex += 1;
        if(currentIndex >= spriteArray.Length)
        {
            currentIndex = 0;
        }
        changeVariant(currentIndex);
        yield return new WaitForSeconds(2);
    }

    void changeVariant(int newVariantInd)
    {
        _sprite_renderer.sprite = spriteArray[newVariantInd];
    }
}
