using UnityEngine;

public class EnemyDisappear : MonoBehaviour
{
    public int maxHealth;  // Jumlah maksimum nyawa
    private int currentHealth;   // Jumlah nyawa saat ini
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fireball"))  // Ganti "Fireball" dengan tag yang sesuai
        {
            TakeDamage();  // Kurangi nyawa saat terkena fireball
        }
    }
    
    private void TakeDamage(int damage = 1)
    {
        currentHealth -= damage;

        // Mengecek apakah nyawa habis
        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            // Trigger animasi terkena damage
            if (anim != null)
            {
                anim.SetTrigger("die");
            }
        }
    }

    private void Die()
    {
        // Memicu animasi "die" pada Animator
        if (anim != null)
        {
            anim.SetTrigger("die");
        }

        // Menonaktifkan objek setelah selesai animasi (sesuaikan dengan durasi animasi)
        float animationDuration = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke("DeactivateObject", animationDuration);
    }

    private void DeactivateObject()
    {
        // Menonaktifkan objek setelah animasi "die" selesai
        gameObject.SetActive(false);
    }
}