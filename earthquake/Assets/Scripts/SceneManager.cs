using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public GameObject PlayerOneBuldingsText, PlayerTwoBuldingsText, TimeLeftObject;

    public GameObject FirstPlayerUI, SecondPlayerUI, MarkerButton;
    public List<GameObject> FirstPlayerBuildings, SecondPlayerBuildings;
    public GameObject P1DefaultBuilding, P2DefaultBuilding;
    public bool P1UIActive = true, P2UIActive = true;
    public int maxBuildings = 3;
    public Button_Bulding buttonScript;
    public GameObject clickDetector;

    public float maxTime = 10;
    public float timeLeft;
    private Text timeLeftText;
    public bool editorActive = true, activatedMarker = false;
    void Start()
    {
        timeLeft = maxTime;
        PlayerOneBuldingsText.GetComponent<Text>().text = maxBuildings.ToString();
        PlayerTwoBuldingsText.GetComponent<Text>().text = maxBuildings.ToString();
        timeLeftText = TimeLeftObject.GetComponent<Text>();
        buttonScript = GameObject.FindGameObjectWithTag("UI_Manager").GetComponent<Button_Bulding>();
        
    }

    void SwitchUI()
    {
        if (P1UIActive)
        {
            FirstPlayerUI.SetActive(true);
            SecondPlayerUI.SetActive(false);
            PlayerOneBuldingsText.GetComponent<Text>().text = (maxBuildings - FirstPlayerBuildings.Count).ToString();
            if (maxBuildings - FirstPlayerBuildings.Count == 0)
            {
                FirstPlayerUI.SetActive(false);
            }
        }
        else if(P2UIActive)
        {
            SecondPlayerUI.SetActive(true);
            FirstPlayerUI.SetActive(false);
            PlayerTwoBuldingsText.GetComponent<Text>().text = (maxBuildings - SecondPlayerBuildings.Count).ToString();
            if (maxBuildings - SecondPlayerBuildings.Count == 0)
            {
                SecondPlayerUI.SetActive(false);
            }
        }

        if ((maxBuildings - SecondPlayerBuildings.Count == 0) && (maxBuildings - FirstPlayerBuildings.Count == 0) && activatedMarker == false)
        {
            editorActive = false;
            MarkerButton.SetActive(true);
            activatedMarker = true;
        }
    }
    public void ActivateMarkerButton()
    {
        clickDetector.gameObject.SetActive(true);
        MarkerButton.SetActive(false);
    }
    void Update()
    {
        if (editorActive)
        {
            timeLeft -= Time.unscaledDeltaTime;
            timeLeftText.text = ((int)timeLeft).ToString();
        }
        else 
        {
            //TimeLeftObject.SetActive(false);
            //TimeLeftObject.transform.parent.gameObject.SetActive(false);
        }
        if (timeLeft <= 0)
        {
            if (P1UIActive)
            {
                GameObject newBuilding = Instantiate(P1DefaultBuilding);
                newBuilding.transform.position = new Vector3(0, 1.5f, 0);
                buttonScript.createBuilding(newBuilding);
                FirstPlayerBuildings.Add(Instantiate(newBuilding));
                P1UIActive = false;
                P2UIActive = true;
            }
            else if (P2UIActive)
            {

                GameObject newBuilding = Instantiate(P2DefaultBuilding);
                newBuilding.transform.position = new Vector3(0, 0, 0);
                buttonScript.createBuilding(newBuilding);
                SecondPlayerBuildings.Add(Instantiate(newBuilding));
                P1UIActive = true;
                P2UIActive = false;
            }
            Destroy(buttonScript.building);
            timeLeft = maxTime;
        }
        SwitchUI();
    }

}
