using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Rigidbody rb;
    public TextMeshProUGUI messageText;

    private bool canMove = true;
    private Vector3 startPosition;
    private Vector3 startScale;
    private float baseMoveSpeed;

    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        rb.freezeRotation = true;

        startPosition = transform.position;
        startScale = transform.localScale;
        baseMoveSpeed = moveSpeed;
    }

    void Update()
    {

        if (!canMove)
        {
            rb.linearVelocity = new Vector3(0f, rb.linearVelocity.y, 0f);
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 dir = new Vector3(h, 0f, v).normalized;
        Vector3 vel = dir * moveSpeed;

        vel.y = rb.linearVelocity.y;
        rb.linearVelocity = vel;
    }

    void ShowMessage(string message)
    {
        if (messageText != null)
            messageText.text = message;

        if (!string.IsNullOrEmpty(message))
            Debug.Log(message);
    }

    public void Grow(float percent)
    {
        transform.localScale *= (1f + percent);

        if (transform.localScale.x > startScale.x * 2f)
        {
            if (messageText != null) messageText.text = "Too powerful";
            canMove = false;
        }
    }

    public void Shrink(float percent)
    {
        transform.localScale *= (1f - percent);

        if (transform.localScale.x < startScale.x * 0.3f)
        {
            if (messageText != null) messageText.text = "You faded away";

            StartCoroutine(ResetWithDelay());
        }
    }

    private IEnumerator ResetWithDelay()
    {
        yield return new WaitForSeconds(1f);
        ResetPlayer();
    }

    public void JumpUp()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void ChangeSpeed(float factor)
    {
        moveSpeed *= factor;
    }

    public void Spin()
    {
        StartCoroutine(RotateSmoothly());
    }

    private IEnumerator RotateSmoothly()
    {
        float duration = 1f;
        float elapsed = 0f;

        Quaternion startRot = transform.rotation;
        Quaternion endRot = transform.rotation * Quaternion.Euler(0f, 180f, 0f);

        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(startRot, endRot, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRot;
    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
        transform.localScale = startScale;
        moveSpeed = baseMoveSpeed;

        canMove = true;
        rb.linearVelocity = Vector3.zero;

        if (messageText != null) messageText.text = "";
    }
}
