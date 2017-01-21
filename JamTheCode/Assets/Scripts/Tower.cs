using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : TowerBase {
    [SerializeField]
	private ActivateKeys activationKey;
    [SerializeField]
    private Text inputText;

	// Use this for initialization
	void Start () {
        if (isActive) {
            GetComponent<SpriteRenderer>().color = Color.green;
        } else {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        
        inputText.text = InputToText(GetActivationKey());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private string InputToText(ActivateKeys key)
    {
        string inputText = "";

        switch (key)
        {
            case ActivateKeys.X:
                inputText = "S";
                break;
            case ActivateKeys.Circle:
                inputText = "D";
                break;
            case ActivateKeys.Square:
                inputText = "A";
                break;
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
    
    public override void activateAllChildren()
    {
        base.activateAllChildren();
    }
}
