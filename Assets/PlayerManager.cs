using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int playerHealth;
    public static bool gameOver;
    public TextMeshProUGUI playerHealthText;
    public GameObject redOverlay;

    void Start()
    {
        playerHealth = 100;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        playerHealthText.text = "" + playerHealth;
        
        if (gameOver)
        {
            SceneManager.LoadScene("EnemyAI");
        }
    }
            

    public IEnumerator Damage (int damageCount)
    {
        playerHealth -= damageCount;
        redOverlay.SetActive(true);

        if (playerHealth <= 0)
            gameOver = true;

        yield return new WaitForSeconds(.5f);
        redOverlay.SetActive(false);
    }
}
