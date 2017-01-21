using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tower : TowerBase {
    [SerializeField]
	private ActivateKeys activationKey;
    [SerializeField]
    public Text inputText;
    
    // Use this for initialization

    protected override void Start() {
	    base.Start();

        if (isActive) {
            GetComponent<SpriteRenderer>().color = Color.green;
        } else {
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        InputToColor(GetActivationKey());
        InputToString(GetActivationKey());
        //inputText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    //override public void InputToColor(ActivateKeys key)
    //{
    //    string inputText = "";

    //    switch (key)
    //    {
    //        //A-button
    //        case ActivateKeys.X:
    //            GetComponent<SpriteRenderer>().color = Color.green;
    //            break;
    //        //B-button
    //        case ActivateKeys.Circle:
    //            GetComponent<SpriteRenderer>().color = Color.red;
    //            break;
    //        //X-Button
    //        case ActivateKeys.Square:
    //            GetComponent<SpriteRenderer>().color = Color.blue;
    //            break;
    //        //Y-button
    //        case ActivateKeys.Triangle:
    //            GetComponent<SpriteRenderer>().color = Color.yellow;
    //            break;
    //        default:
    //            break;
    //    }
    //}

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
                inputText = "W";
                break;
            default:
                inputText = "N";
                break;
        }
        return inputText;
    }
    void OnMouseDown() {
        SetActive();
        
    }

    public override void Die() {
        base.Die();
        panel.gameObject.SetActive(false);
    }

	public ActivateKeys GetActivationKey() {
		return activationKey;
	}
    
    public override void activateAllChildren()
    {
        base.activateAllChildren();
    }
}
