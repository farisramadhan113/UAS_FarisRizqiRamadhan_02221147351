using UnityEngine;

public class NinjaAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float fireballDelay;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] FireBall;

    private Animator anim;
    private NinjaMovement ninjaMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        ninjaMovement = GetComponent<NinjaMovement>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && cooldownTimer > attackCooldown && ninjaMovement.CanAttack())
            Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        Invoke("SetFireballDirection", fireballDelay);
    }

    private void SetFireballDirection()
    {
        FireBall[FindFireball()].transform.position = firePoint.position;
        FireBall[FindFireball()].GetComponent<NinjaFire>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < FireBall.Length; i++)
        {
            if (!FireBall[i].activeInHierarchy)
                return i;
        }
        return 0;
    }   
}
