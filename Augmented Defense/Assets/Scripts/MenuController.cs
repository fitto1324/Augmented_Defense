using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public GameObject Panel;

    public void HideBuyTowerPanel() {
        Panel = GameObject.Find("BuyTowerPanel");
        Panel.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowBuyTowerPanel(){
        Panel = GameObject.Find("BuyTowerPanel");
        Panel.transform.localScale = new Vector3(1, 1, 1);
    }

    public void HideUpgradeTowerPanel()
    {
        Panel = GameObject.Find("UpgradeTowerPanel");
        Panel.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowUpgradeTowerPanel()
    {
        Panel = GameObject.Find("UpgradeTowerPanel");
        Panel.transform.localScale = new Vector3(1, 1, 1);
    }

    public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
