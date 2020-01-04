using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour {
    public void ToNextScene() {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        SceneManager.LoadScene(nextScene);
    }

    public void ToMenu() {
        SceneManager.LoadScene(0);
    }
}
