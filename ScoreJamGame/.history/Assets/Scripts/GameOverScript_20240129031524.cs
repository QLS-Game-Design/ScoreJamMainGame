using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update

    public void gameOver() {

        gameObject.SetActive(true);
    }

    public void RestartButton() {
        Debug.Log("madfssdfdfsasdfadsfeaasdf");
        SceneManager.LoadScene("Level");
    }
}
