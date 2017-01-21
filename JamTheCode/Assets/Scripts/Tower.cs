using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : TowerBase {
    [SerializeField]
	private ActivateKeys activationKey;
    [SerializeField]
    private Text inputText;

    public enum ActivateKeys {
        X=0,
        Circle=1,
        Square=2,
        Triangle=3
    }

	// Use this for initialization
	void Start () {
        if (isActive) {
            GetComponent<SpriteRenderer>().color = Color.green;
        } else {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        
        InputToColor(GetActivationKey());
        inputText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        
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

        if (parentTower != null && parentTower.Active() && parentTower.name != "MainTower") {
            //parentTower.Die();
        }

        for (int i = 0; i < children.Length; i++) {
            if (children[i].Active()) children[i].Invoke("Die", 1f);
        }
    }

	public ActivateKeys GetActivationKey() {
		return activationKey;
	}

    
}
