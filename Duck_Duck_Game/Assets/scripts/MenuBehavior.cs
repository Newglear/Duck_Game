using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuBehavior : MonoBehaviour
{
    public AudioSource Honk;
    public Canvas main,title,controls,rules;
    public void StartGame(){
        if(!title.enabled && !controls.enabled && !rules.enabled)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitGame(){
        if(main.enabled){
            Debug.Log("Quit !");
            Application.Quit(); 
        }    
    }
    public void DisplayRules(){
        if(main.enabled){
            Debug.Log("Rules !");
            rules.enabled = true;
            main.enabled=false;
        } 
    }
    public void DisplayControls(){
        if(main.enabled){
            Debug.Log("Controls !");
            controls.enabled = true;
            main.enabled=false; 
        }
        
    }
    void Start(){
        title.enabled = true;
        main.enabled =false; 
        controls.enabled=false; 
        rules.enabled =false;
    }
    void Update(){
        if(title.enabled){
            if(Input.anyKey && !Input.GetButtonDown("Submit")){
                Honk.Play();
                title.enabled=false; 
                main.enabled=true;
            }
        }else{
            if(Input.GetButtonDown("Submit")){
                Honk.Play();
            }
        }
        if(controls.enabled){
            if(Input.GetButtonDown("Cancel")){
                main.enabled=true;
                controls.enabled = false; 
            }
        }
        if(rules.enabled){
            if(Input.GetButtonDown("Cancel")){
                main.enabled=true;
                rules.enabled = false; 
            }
        }

    }
}

