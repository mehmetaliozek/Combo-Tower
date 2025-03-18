using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField]
    private float range;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
