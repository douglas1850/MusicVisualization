using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioVisualizationButton : MonoBehaviour {

	public void BackOriginal()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
	}

	public void BackFireAndIce()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2); 
	}

	public void BackUTSA()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 3); 
	}
}
