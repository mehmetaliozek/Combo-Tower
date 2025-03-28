using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    private Rigidbody2D popupRb;
    private TextMeshProUGUI damageValue;

    public float initialXVelocity = 7f;
    public float initialYVelocityRange = 3f;
    public float lifetime = 0.8f;


    private void Awake() {
        popupRb = GetComponent<Rigidbody2D>();
        damageValue = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start()
    {
        popupRb.linearVelocity = new Vector2(Random.Range(- initialYVelocityRange, initialYVelocityRange), initialXVelocity);
        Destroy(gameObject, lifetime);
    }

    public void SetMessage(string msg) {
        damageValue.SetText(msg);
    }
}
