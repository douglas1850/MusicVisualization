using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongSelect : MonoBehaviour {

	public void Back()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 2); //go back two scenes to menu
	}
}
