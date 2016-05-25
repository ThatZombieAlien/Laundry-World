using UnityEngine;
using System.Collections;
//gjord av Maria

public class TogglePanelButton : MonoBehaviour 
{
	
	public void TogglePanel (GameObject panel)
	{
		panel.SetActive (!panel.activeSelf); //aktiverar/avaktiverar en panel
	}


}
