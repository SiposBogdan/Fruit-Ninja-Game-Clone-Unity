using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    private int score;
    public Text scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindAnyObjectByType<GameManager>().PlayRandomBombSounds();
        Blade b = collision.GetComponent<Blade>();
        if (!b)
            return;
        FindFirstObjectByType<GameManager>().OnBombHit();
    }
    
}
