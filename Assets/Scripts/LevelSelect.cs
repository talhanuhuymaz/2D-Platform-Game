using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public Animator transition;

    public void GotoScene(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
        if (levelIndex == 2)
        {
            AudioManager.instance.StopAll();
            AudioManager.instance.PlaySound("level2");
        }
        if (levelIndex == 3)
        {
            AudioManager.instance.StopAll();
            AudioManager.instance.PlaySound("level3");
        }
    }
}
