using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] float startLevelDelay = 1;

    void Start()
    {

    }
    IEnumerator StartNextLevel()
    {
        yield return new WaitForSeconds(.01f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        currentSceneIndex++;
        if (currentSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            currentSceneIndex = 0;
        }
        ScenePersist scenePersist = FindObjectOfType<ScenePersist>();
        scenePersist.ResetScenePersists();
        SceneManager.LoadScene(currentSceneIndex);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {


        if (other.tag == "Player")
        {
            StartCoroutine(StartNextLevel());
        }
    }


}
