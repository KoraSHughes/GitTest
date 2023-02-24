using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariantManager : MonoBehaviour
{
    // Start is called before the first frame update

    // Hard enemy switches color randomly between 5 to 10 seconds, by default.
    public bool variantMutates = false;
    public float variantSwitchInterval = 5.0f;
    public string[] colorArray;
    public Sprite[] spriteArray;
    private float secSinceLastVariantChange = 0f;
    private Enemy _enemy;
    private SpriteRenderer _sprite_renderer;

    void Start()
    {
        _enemy = gameObject.GetComponent<Enemy>();
        _sprite_renderer = gameObject.GetComponent<SpriteRenderer>();
        changeVariant(chooseRandomVariantIndex());
        secSinceLastVariantChange = Random.Range(0f, variantSwitchInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (variantMutates) {
            secSinceLastVariantChange += Time.deltaTime;
            if (secSinceLastVariantChange >= variantSwitchInterval)
            {
                changeVariant(chooseRandomVariantIndex());
                secSinceLastVariantChange = 0f;
            }
        }
    }

    int chooseRandomVariantIndex()
    {
        int randInd = Random.Range(0, colorArray.Length);
        // prevent same color from being chosen... probably not the best way to implement this.
        while (colorArray[randInd] == _enemy.variant) {
            randInd = Random.Range(0, colorArray.Length);
        }
        return randInd;
    }

    void changeVariant(int newVariantInd)
    {
        _enemy.variant = colorArray[newVariantInd];

        // change sprite...
        _sprite_renderer.sprite = spriteArray[newVariantInd];
    }

    
}
