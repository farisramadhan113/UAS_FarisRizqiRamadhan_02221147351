using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFire : MonoBehaviour
{
    public float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) 
            DeactivateObject();
    }

    public void SetDirection(float _direction)
    {
        lifetime = -1;
        direction = _direction;
        gameObject.SetActive(true);

        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<BoxCollider2D>(out BoxCollider2D otherCollider))
        {
            // Memeriksa apakah objek yang bertumbukan adalah musuh
            if (collision.gameObject.CompareTag("Enemy"))
            {
                // Menonaktifkan fireball saat bertumbukan dengan musuh
                DeactivateObject();
            }
            else
            {
                // Jika bukan musuh, memainkan animasi dan menonaktifkan fireball setelah animasi selesai
                anim.SetTrigger("explode");
                float animationDuration = anim.GetCurrentAnimatorStateInfo(0).length;
                Invoke("DeactivateObject", animationDuration);
            }
        }
    }

    private void DeactivateObject()
    {
        gameObject.SetActive(false);
    }

        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))  // Ganti "Fireball" dengan tag yang sesuai
        {
            TakeDamage();  // Kurangi nyawa saat terkena fireball
        }
    }

    private void TakeDamage()
    {
        {
            // Memicu animasi "die" pada Animator
            if (anim != null)
            {
                anim.SetTrigger("explode");
            }

            // Menonaktifkan objek setelah selesai animasi (sesuaikan dengan durasi animasi)
            float animationDuration = anim.GetCurrentAnimatorStateInfo(0).length;
            Invoke("DeactivateObject", animationDuration);
        }
    }
}
