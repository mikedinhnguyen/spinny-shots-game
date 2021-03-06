using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public Transform enemyDir;
    public float moveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (target != null)
        {
            LookAtPlayer();
        }
    }

    void LookAtPlayer()
    {
        Vector2 lookDir = target.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            //MoveEnemy();
            rb.AddForce(enemyDir.up * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
        }
    }

    void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.fixedDeltaTime);
    }
}
