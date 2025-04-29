using UnityEngine;

public class GuardBehavior : MonoBehaviour
{
    private int pistolHitCount = 0;
    private int rpgHitCount = 0;
    private bool isDead = false;
    private bool isChasing = false;

    public Transform player;
    public float detectionRange = 10f;
    public float chaseRange = 10f;
    public float chaseSpeed = 4.5f;
    public LayerMask groundLayer;
    private bool isGrounded = false;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;

    public PlayerKills playerKills;

    private void Start()
    {
        playerKills = FindObjectOfType<PlayerKills>();
    }

    public void GetHitByPistol()
    {
        if (!isDead)
        {
            pistolHitCount++;

            if (pistolHitCount >= 3)
            {
                isDead = true;
                Debug.Log("Guard has been hit three times by pistol bullets and is dead!");
                Destroy(gameObject);

                // Notify the PlayerKills script to increase the kill count
                playerKills.IncreaseKills();
            }
            else
            {
                Debug.Log("Guard has been hit by a pistol bullet " + pistolHitCount + " times.");
            }
        }
    }

    public void GetHitByRPG()
    {
        if (!isDead)
        {
            rpgHitCount++;

            if (rpgHitCount >= 1)
            {
                isDead = true;
                Debug.Log("Guard has been hit by an RPG rocket and is dead!");
                Destroy(gameObject);

                // Notify the PlayerKills script to increase the kill count
                playerKills.IncreaseKills();
            }
            else
            {
                Debug.Log("Guard has been hit by an RPG rocket " + rpgHitCount + " times.");
            }
        }
    }

    private void Update()
    {
        if (!isDead)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                if (!isChasing)
                {
                    isChasing = true;
                }

                if (distanceToPlayer <= chaseRange)
                {
                    ChasePlayer();
                }
            }
            else
            {
                if (isChasing)
                {
                    isChasing = false;
                }
            }

            isGrounded = Physics.OverlapSphere(groundCheck.position, groundCheckRadius, groundLayer).Length > 0;
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    }

    public void SetIsGrounded(bool grounded)
    {
        isGrounded = grounded;
    }
}
