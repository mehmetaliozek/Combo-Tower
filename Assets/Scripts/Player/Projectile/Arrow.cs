using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Vector3 startPos;
    private Vector3 targetPos;
    private float progress;

    [SerializeField] private float bulletSpeed = 40f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        progress += Time.deltaTime * bulletSpeed;
        transform.position = Vector3.Lerp(startPos, targetPos, progress);
    }

    public void setTargetPos(Vector3 targetPosition)
    {
        targetPos = targetPosition;
    }
}
