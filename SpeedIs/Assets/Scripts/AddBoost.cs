using UnityEngine;

public class AddBoost : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Vehicle>(out Vehicle player))
        {
            player.AddBoostOfSpeed(this.transform);
        }
    }
}
