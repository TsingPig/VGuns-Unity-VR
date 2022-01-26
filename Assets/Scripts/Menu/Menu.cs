using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class Menu : MonoBehaviour
{
    public GameObject Menu1 = null;
    public GameObject Menu2 = null;

    public void Show()
    {
        Menu1.SetActive(false);
        Menu2.SetActive(true);
    }
    
        public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
 
    public void LoadTutorial(string level)
    {
    SceneManager.LoadScene(level);
     
    }
    
    public void Quit()
    {
        Application.Quit();
    }
    
}
