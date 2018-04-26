using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUp : MonoBehaviour {

    public void Next()
    {
        SceneManager.LoadScene(1);
    }

    public void Next1()
    {
        SceneManager.LoadScene(2);
    }
    public void Next2()
    {
        SceneManager.LoadScene(3);
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplayBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
