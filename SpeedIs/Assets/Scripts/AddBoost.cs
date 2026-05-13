using UnityEngine;

public class AddBoost : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Vehicle>(out Vehicle player))
        {
            Debug.Log("Aceleracion Accedida");
            player.AddBoostOfSpeed(this.transform);
        }
    }
}
