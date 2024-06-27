using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class HealthManager : MonoBehaviour
{
    //public int maxHealth = 3;
    public GameObject[] hearts;
    public int currentHealth;
    public GameObject gameOverCanvas;
    private float fixedDeltaTime;
    [SerializeField] private AudioSource deathSound;
    public GameObject selectedRestartButton;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        
    }
    

    // Update is called once per frame
    void Update()
    {
        

        if (currentHealth < 1)
        {
            //Destroy(hearts[0].gameObject);
            hearts[0].gameObject.SetActive(false);
            Time.timeScale = 0;
            
            gameOverCanvas.gameObject.SetActive(true);
            
        }
        else if(currentHealth < 2)
        {
            //Destroy(hearts[1].gameObject);
            hearts[1].gameObject.SetActive(false);
        }
        else if (currentHealth < 3)
        {
            //Destroy(hearts[2].gameObject);
            hearts[2].gameObject.SetActive(false);
        }
    }

   
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Lava"))
        {
            currentHealth--;
            deathSound.Play();
            EventSystem.current.SetSelectedGameObject(selectedRestartButton);

        }


        if (collision.gameObject.CompareTag("Death"))
        {
            currentHealth--;
            //deathSound.Play();
            EventSystem.current.SetSelectedGameObject(selectedRestartButton);

        }




    }



    public void ResetScene()
    {
       
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
