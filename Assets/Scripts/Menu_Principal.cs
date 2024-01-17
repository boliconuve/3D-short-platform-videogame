using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Principal : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene(1);
    }

    public void Controls(){
        SceneManager.LoadScene("Controles");
    }

    public void Quit(){
        Application.Quit();
    }
}
