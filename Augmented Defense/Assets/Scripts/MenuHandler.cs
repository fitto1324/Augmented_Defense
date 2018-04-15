using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour {

    public string ButtonName = "MenuButton";
    public GameObject MenuButton;
    public GameObject MenuPanel;
    public GameObject Panel;

    public void DisplayMenu() {
        MenuPanel = GameObject.Find("MenuPanel");
        MenuPanel.transform.localScale = new Vector3(1, 1, 1);
        this.enabled = false;
        this.transform.localScale = new Vector3(0, 0, 0);

        Panel = GameObject.Find("UpgradeTowerPanel");
        Panel.transform.localScale = new Vector3(0, 0, 0);
    }

    void Start () {
        MenuButton = GameObject.Find(ButtonName);
        MenuButton.GetComponent<Button>().enabled = false;
        MenuButton.transform.localScale = new Vector3(0, 0, 0);
    }
	
	void Update () {
		
	}
}
