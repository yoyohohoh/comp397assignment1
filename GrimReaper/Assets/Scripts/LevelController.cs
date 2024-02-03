using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    GamePlayUIController GamePlayUIController;
    public void Update()
    {
        if (GamePlayUIController.Instance.health.GetComponent<Slider>().value == 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }
        
    
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
