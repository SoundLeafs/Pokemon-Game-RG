using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    public void Start()
    {
           Time.timeScale = 1; 
    }
    
    public void ResetSceneNow()
    { 

               
        SceneManager.LoadScene(0);

    }
}
