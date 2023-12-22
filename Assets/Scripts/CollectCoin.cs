using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    public PlayerController playerController;
    public int maxScore;
    public Animator PlayerAnim;
    public GameObject Player;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            playerController.runningSpeed = 0;
            transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
            if(score >= maxScore)
            {
                //Debug.Log("You win");
                PlayerAnim.SetBool("win", true);
            }
            else
            {
                //Debug.Log("You lose");
                PlayerAnim.SetBool("lose", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Collision"))
        {
            Debug.Log("Engele dokundu");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }
}
