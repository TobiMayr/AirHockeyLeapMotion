using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitManual : MonoBehaviour 
{
	public Canvas quitMenu;
	public Button exitText;

	void Start ()
	{
		quitMenu = quitMenu.GetComponent<Canvas> ();
		exitText = exitText.GetComponent<Button> ();
		quitMenu.enabled = false;
	}

	public void OnExitClick()
	{
		quitMenu.enabled = true;
		exitText.enabled = false;
	}
	public void NoPress()
	{
		quitMenu.enabled = false;
		exitText.enabled = true;
	}

}
