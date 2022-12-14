using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public AudioClip collectedClip;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var controller = other.GetComponent<RubyController>();
        if (controller is null) return;
        if (controller.Health < controller.MaxHealth)
        {
            controller.ChangeHealth(1);
            Destroy(gameObject);
            controller.PlaySound(collectedClip);
        }
    }
}