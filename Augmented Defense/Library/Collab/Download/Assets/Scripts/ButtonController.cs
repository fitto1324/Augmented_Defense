using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour {

    public GameObject MenuButton;
    public GameObject MenuPanel;
    public Text HeaderText;
    public Image HealthBar;
    public float waitTime = 30.0f;

    public void DisplayMenuButton() {
        // Find Button With Name of "MenuButton"
        MenuButton = GameObject.Find("MenuButton");
        if (MenuButton.GetComponent<Button>() != null) {
            // Enable Menu Button When Starting Game 
            MenuButton.GetComponent<Button>().enabled = true;
            MenuButton.transform.localScale = new Vector3(1, 1, 1);
            // Disable Start Game Button When Pressed
            this.enabled = false;
            this.transform.localScale = new Vector3(0, 0, 0);
            // Remove Header Text After Starting Game
            HeaderText = GameObject.Find("HeaderText").GetComponent<Text>();
            HeaderText.enabled = false;
        } else {
            // Error Message When Button Does Not Exist
            print("Button Does Not Exist");
        }
    }

	void Start () {
        //Countdown = GameObject.Find("Countdown").GetComponent<Text>();
        //Countdown.enabled = false;
        //Countdown.transform.localScale = new Vector3(0, 0, 0);
        MenuPanel = GameObject.Find("MenuPanel");
        MenuPanel.transform.localScale = new Vector3(0, 0, 0);

    }
	
	void Update () {
        //HealthBar = GameObject.Find("HealthBar").GetComponent<Image>();
        //HealthBar.fillAmount -= 1.0f / waitTime * Time.deltaTime;
    }
}
