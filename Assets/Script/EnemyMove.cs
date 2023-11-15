using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float movementDistance;
    [SerializeField] private bool moveUpAndDown; // Tambahkan variabel ini

    private bool movingLeft;
    private bool movingUp; // Tambahkan variabel ini
    private float leftEdge; // Ubah nama variabel ini
    private float rightEdge; // Ubah nama variabel ini
    private float topEdge; // Tambahkan variabel ini
    private float bottomEdge; // Tambahkan variabel ini
    private float originalY; // Tambahkan variabel ini

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;

        originalY = transform.position.y; // Simpan posisi Y awal
        topEdge = originalY + movementDistance; // Hitung batas atas
        bottomEdge = originalY - movementDistance; // Hitung batas bawah
    }

    private void Update()
    {
        if (moveUpAndDown)
        {
            MoveUpDown();
        }
        else
        {
            MoveLeftRight();
        }
    }

    private void MoveLeftRight()
    {
        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                movingLeft = true;
        }
    }

    private void MoveUpDown()
    {
        if (movingUp)
        {
            if (transform.position.y < topEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                movingUp = false;
        }
        else
        {
            if (transform.position.y > bottomEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
                movingUp = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HeartMainManager>().TakeDamage(damage);
        }
    }
}