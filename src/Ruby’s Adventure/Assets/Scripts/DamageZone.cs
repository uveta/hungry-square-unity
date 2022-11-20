using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        var controller = other.GetComponent<RubyController>();
        if (controller is null) return;
        if (controller.Health > 0) controller.ChangeHealth(-1);
    }
}