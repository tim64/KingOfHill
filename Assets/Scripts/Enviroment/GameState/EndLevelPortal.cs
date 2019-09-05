using UnityEngine;

public class EndLevelPortal : MonoBehaviour
{
    public GameObject flag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            LeanTween.scale(collision.gameObject, Vector2.zero, 1).setOnComplete(EndGame);
        }
    }

    private void Update()
    {
        transform.Rotate(0, 0, 20 * Time.deltaTime);
    }

    private void EndGame()
    {
        LeanTween.scale(gameObject, Vector2.zero, 0.5f);
        LeanTween.moveY(flag, flag.transform.position.y + 4, 1);
    }
}
