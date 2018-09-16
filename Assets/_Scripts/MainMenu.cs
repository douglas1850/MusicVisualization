using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGameRetroFun()
	{
		SceneManager.LoadScene ("PhyllotaxisScene3DRetroFun");
	}

	public void PlayGameHalo()
	{
		SceneManager.LoadScene ("PhyllotaxisScene3DHalo");
	}

	public void PlayGameFireAndIce()
	{
		SceneManager.LoadScene ("PhyllotaxisScene3DFireAndIce");
	}

	/*public void SelectSong()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 2); //song select scene index = 2
	}*/

	public void QuitGame()
	{
		Debug.Log ("Quit!");
		Application.Quit();
	}

	public void Continue()
	{
		SceneManager.LoadScene ("Menu");
	}
}
