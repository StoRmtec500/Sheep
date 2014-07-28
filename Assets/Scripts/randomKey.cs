using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class randomKey : MonoBehaviour {

	static randomKey myInstance;
	public static randomKey Instance { get { return myInstance; } }
	public int zahl;
	public bool start = false;
	public bool erlaubt = false;
	public bool einmal = false;
	public bool gestartet = false;
	public enum startState {On, Off };
	public startState starts = startState.Off;
	public GUIText zahlanzeige;
	public GUIText numberklicktanzeige;
	public int[] nummer = new int[7] {0,1,2,3,4,5,6};
	public GUISkin mySkin;
	public GameObject[] button;
	public int buttonstring;
	public GameObject pnlGameOver;
	public GameObject pnlOverlay;
	public UILabel lblText;
	//public static int buttonnumber;


	void Start()
	{
				myInstance = this;
	}

	// Update is called once per frame
	void Update () {
		if (start) 
		{
			zahlstart ();
		}

		zahlanzeige.text = zahl.ToString ();
		numberklicktanzeige.text = buttonstring.ToString ();


		if (einmal == true) {
			if (buttonstring == zahl && erlaubt == true) {
				Debug.Log ("--------------WEITER--------------"); 
				erlaubt = false;
				einmal = false;
				//gestartet = true;
			}
			if (buttonstring != zahl && erlaubt == true) {
				erlaubt = false;
				einmal = false;
				Time.timeScale = 0f;
				Debug.Log("------------- Aus ---------------");
				lblText.text = "Du hast die falsche Zahl gedrückt!";
			}
		}
	}

	void zahlstart()
	{
		start = false;
		gestartet = true;
		starts = startState.On;
		StartCoroutine (startZahl (1.5f));
	}

	IEnumerator startZahl(float timer)
	{
		while (starts == startState.On) 
		{
			zahl = Random.Range(1, nummer.Length);		
			yield return new WaitForSeconds (timer);
			Debug.Log (nummer[zahl]);

			if (gestartet == true) {
				Time.timeScale = 0f;
				Debug.Log("------------- NICHTS GEDRÜCKT ---------------");
				pnlGameOver.SetActive(true);
				pnlOverlay.SetActive(true);
				lblText.text = "Du hast leider nichts gedrückt!";
			}
		}
	}

	// Playbutton wird angezeigt ---
	void OnGUI()
	{
		if(GUI.Button (new Rect (10, 10, 50, 20), "Play", mySkin.button))
			startPlaying();
	}

	// Zahlen werden angezeigt ----
	void startPlaying ()
	{
		start = true;
	}

}
