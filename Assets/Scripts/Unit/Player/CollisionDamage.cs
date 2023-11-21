using UnityEngine;

namespace Unit.Player
{
    public class CollisionDamage : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private string targetTag = "Enemy";

        private void OnTriggerEnter(Collider collision)
        {
            ProcessCollision(collision.gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            ProcessCollision(collision.gameObject);
        }

        private void ProcessCollision(GameObject collidedObject)
        {
            if (!collidedObject.CompareTag(targetTag)) return;
            Debug.Log("Collision");
        
            var unit = collidedObject.GetComponent<AUnit>();
            if (unit == null)
                return;

            unit.GetDamage(playerController, unit, playerController.Damage);
        }
    }
}
