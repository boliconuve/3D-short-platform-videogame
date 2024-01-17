using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float timeDelay = 2f;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip finish;

    [SerializeField] ParticleSystem deathParticle;
    [SerializeField] ParticleSystem finishParticle;


    AudioSource audioSource;

    bool isTransitioning = false;

    void Start() {
        audioSource = GetComponent<AudioSource>();    
    }

    void Update() {
        Escape();
        CheatCode();
    }


    void OnCollisionEnter(Collision other) {
        
        if(isTransitioning){return;} 

        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is FRIENDLY");
                break;
            case "Finish":
                NextLevelDelay();
                break;
            case "Fuel":
                Debug.Log("You pick up FUEL");
                break;
            default:
                ReloadLevelDelay();
                break;
        }
    }

    void ReloadLevelDelay(){
        isTransitioning=true;
        audioSource.PlayOneShot(death);
        deathParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel",timeDelay);
    }

    void NextLevelDelay(){
        isTransitioning=true;
        audioSource.PlayOneShot(finish);
        finishParticle.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel",timeDelay);
    }

    void ReloadLevel(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void NextLevel(){
        
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if(nextScene == (SceneManager.sceneCountInBuildSettings-1)){
            nextScene = 0;
        }
        SceneManager.LoadScene(nextScene);
    }
    
    void Escape(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }

    //Cheat Code
    void CheatCode(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        if(Input.GetKeyDown(KeyCode.N) && !(nextScene == (SceneManager.sceneCountInBuildSettings-1))){ //Next Level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if(Input.GetKeyDown(KeyCode.N) && (nextScene == (SceneManager.sceneCountInBuildSettings-1))){
            SceneManager.LoadScene(0);
        }
    }

    
}
