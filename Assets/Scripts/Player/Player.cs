using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField]
    private GameObject head;

    [SerializeField]
    private GameObject body;

    [SerializeField]
    private GameObject foot;

    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private float speed;

    private float x;
    private float y;

    private int minPlusY = 0;
    private int minMinusY = -1;

    [SerializeField]
    private float health = 100000;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        Turn();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(x, y) * speed;
    }

    private void Turn()
    {
        float scaleX = (x > 0) ? 1 : (x < 0) ? -1 : head.transform.localScale.x;
        head.transform.localScale = new Vector2(scaleX, head.transform.localScale.y);
        foot.transform.localScale = new Vector2(scaleX, foot.transform.localScale.y);
    }

    public void AddRoom(Room room, int x, int y, int offset)
    {
        Room r = Instantiate(room, body.transform);

        float offsetX = y - offset / 2;
        float offsetY = -(x - offset / 2);

        r.transform.localPosition = new Vector2(offsetX, offsetY);

        if (offsetY >= 0 && offsetY >= minPlusY)
        {
            head.transform.localPosition = r.transform.localPosition + Vector3.up;
            minPlusY += 1;
        }
        else if (offsetY < 0 && offsetY <= minMinusY)
        {
            foot.transform.localPosition = r.transform.localPosition + Vector3.down;
            minMinusY -= 1;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //Debug.Log(health);
    }
}
