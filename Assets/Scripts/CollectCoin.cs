using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectCoin : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI coinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddCoin();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Collision"))
        {
            Debug.Log("Engele dokundu");
        }
    }

    void AddCoin()
    {
        score++;
        coinText.text = "Score: " + score.ToString();
    }
}
