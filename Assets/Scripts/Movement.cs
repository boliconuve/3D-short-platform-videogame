using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float massUp = 1000f; 
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainParticleSystem;
    [SerializeField] ParticleSystem leftParticleSystem;
    [SerializeField] ParticleSystem rightParticleSystem;
    Rigidbody rb;
    AudioSource audioSource;

    bool isAlive;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessUp();
        ProcessRotation();
    }

    void ProcessUp(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(Vector3.up*massUp*Time.deltaTime);
            if(!audioSource.isPlaying){
                audioSource.PlayOneShot(mainEngine);
            }
            if(!mainParticleSystem.isPlaying){
                mainParticleSystem.Play();
            }
            
        }else{
            audioSource.Stop();
            mainParticleSystem.Stop();
        }
    }

    void ProcessRotation(){
        if(Input.GetKey(KeyCode.A)){
            transform.Rotate(Vector3.forward*rotationSpeed*Time.deltaTime);
            if(!rightParticleSystem.isPlaying){
                rightParticleSystem.Play();
            }
        }else if(Input.GetKey(KeyCode.D)){
            transform.Rotate(-Vector3.forward*rotationSpeed*Time.deltaTime);
            if(!leftParticleSystem.isPlaying){
                leftParticleSystem.Play();
            }
        }else{
            rightParticleSystem.Stop();
            leftParticleSystem.Stop();
        }
    }

    
}
