using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void RecBookScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadHome()
    {
        SceneManager.LoadSceneAsync(0);
    }

   

}