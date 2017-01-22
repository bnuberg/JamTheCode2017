using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : TowerBase {
    //[SerializeField]
	private ActivateKeys activationKey;
    [SerializeField]
    public Text inputText;
    [SerializeField]
    private GameObject freeze;

    // Use this for initialization

    protected override void Start() {
	    base.Start();

        InputToColor(GetActivationKey());
        inputText.text = "";
        
    }
	
	// Update is called once per frame
	void Update () {
        if (explosionRange < maxExplosionRange)
        {
            Debug.Log("Increase Range");
            explosionRange += 0.01f;
        }
        if (explosionRange > maxExplosionRange) explosionRange = maxExplosionRange;
    }
    public override void Explosion()
    {
        if (Input.GetButton("Power"))
        {
            FreezePower();
            Debug.Log("Poweeeeeeeeeeeeeeeeeeeeeeeeeeeer");
        }
        else
        {
            base.Explosion();
        }

    }
    void FreezePower()
    {
        
        GameObject go = Instantiate(freeze, transform);
        go.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    private void InputToColor(ActivateKeys key)
    {
        string inputText = "";

        switch (key)
        {
            //A-button
            case ActivateKeys.X:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            //B-button
            case ActivateKeys.Circle:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            //X-Button
            case ActivateKeys.Square:
                GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            //Y-button
            case ActivateKeys.Triangle:
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            default:
                break;
        }
    }
    public string InputToString(ActivateKeys key)
    {
        string inputText = "";

        switch (key)
        {
            //A-button
            case ActivateKeys.X:
                inputText = "S";
                break;
            //B-button
            case ActivateKeys.Circle:
                inputText = "D";
                break;
            //X-Button
            case ActivateKeys.Square:
                inputText = "A";
                break;
            //Y-button
            case ActivateKeys.Triangle:
                inputText = "w";
                break;
            default:
                break;
        }
        return inputText;
    }
    void OnMouseDown() {
        SetActive();
        
    }

    public override void Die() {
        base.Die();
    }

	public ActivateKeys GetActivationKey() {
		return activationKey;
	}

    public void SetActivationKey(ActivateKeys key)
    {
        activationKey = key;
    }
    
    public override void activateAllChildren()
    {
        base.activateAllChildren();
    }
}
