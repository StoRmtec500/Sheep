using UnityEngine;
using System.Collections;

public class switchFade : MonoBehaviour {

	public TweenAlpha logo;
	bool finish;
	public UI2DSprite logoGO;

	public void Start()
	{
		Invoke ("loadLogo", 0f);
		}

	void Update()
	{
		if (finish == true) {
			Invoke("chanceScene", 1f);
				}
		}

	public void playReverse()
	{
				this.logo.PlayReverse ();
				if (logo.value == 0) {
						finish = true;
				}
		}
	// Use this for initialization
	public void chanceScene()
	{
		Application.LoadLevel (Application.loadedLevel + 1);
		}

	void loadLogo()
	{
		this.logoGO.alpha = 0f;
	}
}
