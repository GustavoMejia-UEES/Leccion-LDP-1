using UnityEngine;
using UnityEngine.SceneManagement; 

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
