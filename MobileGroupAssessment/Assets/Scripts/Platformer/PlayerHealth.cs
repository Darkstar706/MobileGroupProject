using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health = 10;
    public Text healthText;
    public Slider healthSlider;
    void Start()
    {
        healthText.text = "Condition: Perfect";
        healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
        healthSlider.maxValue = health;
        healthSlider.value = health;
        //PlayerPrefs.SetInt("Lives", Lives);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health--;
            healthSlider.value = health;
            if(health < 1)
            {
                SceneManager.LoadScene(
                    SceneManager.GetActiveScene().name);
                //SceneManager.LoadScene("Lose");
            }
            else if (health < 3)
            {
                healthText.text = "Condition: Critical";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
            }
            else if (health < 5)
            {
                healthText.text = "Condition: Weak";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;
            }
            else if (health < 7)
            {
                healthText.text = "Condition: Fine";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;
            }
            else if(health < 9)
            {
                healthText.text = "Condition: Healthy";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
            }
            else
            {
                healthText.text = "Condition: Perfect";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyBullet")
        {
            health--;
            healthSlider.value = health;
            if (health < 1)
            {
                    SceneManager.LoadScene("Main Menu");
            }
            else if (health < 3)
            {
                healthText.text = "Condition: Critical";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.red;
            }
            else if (health < 5)
            {
                healthText.text = "Condition: Weak";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;
            }
            else if (health < 7)
            {
                healthText.text = "Condition: Fine";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.yellow;
            }
            else if (health < 9)
            {
                healthText.text = "Condition: Healthy";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
            }
            else
            {
                healthText.text = "Condition: Perfect";
                healthSlider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = Color.green;
            }
        }
    }
}
