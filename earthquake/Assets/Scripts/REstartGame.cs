using UnityEngine;

public class REstartGame : MonoBehaviour
{
   public string LevelName;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void restartScene()
    {
       string newLevel = "Levelworking";
       if (LevelName == "Levelworking")
       {
          newLevel = "Levelworking2";
      }
        Application.LoadLevel(newLevel);
    }
}
