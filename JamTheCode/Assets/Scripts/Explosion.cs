using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private float transparencySpeed;
    [SerializeField] private float sizeMultiplier;

    // Use this for initialization
    void Start () {
	    spriteRenderer = GetComponent<SpriteRenderer>();
	    spriteRenderer.color = new Color(1, 0.5f, 0, 1);
	    spriteRenderer.transform.localScale *= sizeMultiplier;
	}
	
	// Update is called once per frame
	void Update () {
        spriteRenderer.color = new Color(1, 0.5f, 0, spriteRenderer.color.a - transparencySpeed);

        if (spriteRenderer.color.a <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void SetSizeMultiplier(float size)
    {
        sizeMultiplier = size;
    }
}
