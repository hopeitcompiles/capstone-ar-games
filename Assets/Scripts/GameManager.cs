using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public event Action OnMainMenu;
    public event Action OnARPosition;
    public event Action OnItemsMenu;
    public static GameManager instance;

    private void Awake() {
        if(instance!=null && instance!=this){
                Destroy(gameObject);
        }else{
            instance=this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        MainMenu();
    }

    public void MainMenu(){
        OnMainMenu?.Invoke();
        Debug.Log("Main menu");
    }
    
    public void ARPosition(){
        OnARPosition?.Invoke();
        Debug.Log("ARPosition");
    }
    public void ARItemsMenu(){
        OnItemsMenu?.Invoke();
        Debug.Log("OnItemsMenu");
    }

    public void CloseApp(){
        Debug.Log("Close App");
        Application.Quit();
    }

    
}
