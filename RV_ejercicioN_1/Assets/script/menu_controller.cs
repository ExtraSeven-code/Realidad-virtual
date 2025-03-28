using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void jugar()
    {
        SceneManager.LoadScene("Ejercicio3");
    }
    public void salir()
    {
        Application.Quit();
    }
}
