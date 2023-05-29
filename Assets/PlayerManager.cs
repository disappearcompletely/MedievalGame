using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public int playerHealth;  // убрано static
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
            SceneManager.LoadScene("MedievalVillage");
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

    // новый метод для лечения игрока
    public void Heal()
    {
        playerHealth = 100;
    }
}
