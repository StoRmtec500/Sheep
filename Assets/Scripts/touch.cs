using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour {

	static touch myInstance;                       //Hold a reference to this script
	public static touch Instance { get { return myInstance; } }

	public GameObject button;
	public int nummertouch;

	// Use this for initialization
	void Start () {
		myInstance = this;
	}

	void Update() {

		}
	
	// Update is called once per frame
	void OnMouseDown () {

		nummertouch = System.Int32.Parse (gameObject.name);
		Debug.Log ("Buttonname: " + nummertouch.ToString());
		randomKey.Instance.buttonstring = 0;
		randomKey.Instance.erlaubt = true;
		randomKey.Instance.einmal = true;
		randomKey.Instance.gestartet = false;
		randomKey.Instance.buttonstring += nummertouch;
		//randomKey.Instance.einmal = false;
	}
}
