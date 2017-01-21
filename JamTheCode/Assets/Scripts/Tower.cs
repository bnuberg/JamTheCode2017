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
                inputText = "A";
                break;
            case ActivateKeys.Circle:
                inputText = "B";
                break;
            case ActivateKeys.Square:
                inputText = "X";
                break;
            case ActivateKeys.Triangle:
                inputText = "Y";
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
