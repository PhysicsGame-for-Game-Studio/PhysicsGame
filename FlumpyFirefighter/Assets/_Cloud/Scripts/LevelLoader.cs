using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    void Update()
    {
        
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play Anim
        transition.SetTrigger("Start");
        // Wait
        yield return new WaitForSeconds(1);
        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }

}
