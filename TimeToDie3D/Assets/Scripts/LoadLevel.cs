using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadLevel : MonoBehaviour {

    public Slider loadingBar;
    public GameObject loadingImage;
    private AsyncOperation async;
    
	public void LoadLevelButton(string LevelName) 
    {
        if (Time.timeScale < 1f)
            Time.timeScale = 1f;

        Application.LoadLevelAsync(LevelName);
	}

    public void QuitGame()
    {
        Application.Quit();
    }


    public void ClickAsync(string LevelName)
    {
        loadingBar.gameObject.SetActive(true);
        loadingImage.SetActive(true);
        StartCoroutine(LoadLevelWithBar(LevelName));
    }


    IEnumerator LoadLevelWithBar(string LevelName)
    {
        async = Application.LoadLevelAsync(LevelName);
        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            yield return null;
        }
    }
}
