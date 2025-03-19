using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator animator;
    public GameObject melee;
    public Transform meleeTransform;
    public bool isAttacking = false;
    float attackDuration = 0.3f;
    float attackTimer = 0f;

    public Transform aim;
    public GameObject bullet;
    float fireForce = 10f;
    float shootCD = 1f;
    float shootTimer = 0.5f;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        // item held
        Item item = InventoryManager.instance.GetSelectedItem(false);

        CheckMeleeTimer();
        if (shootTimer < shootCD)
        {
            shootTimer += Time.deltaTime;
        }

        // if attack item held
        if (item != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (item.type == ItemType.Sword)
                {
                    OnAttack();
                }
                if (item.type == ItemType.Gun)
                {
                    OnShoot();
                }
            }
        }
    }

    // sword attack
    void OnAttack()
    {
        if (!isAttacking)
        {
            melee.SetActive(true);
            isAttacking = true;
            animator.SetTrigger("IsAttacking");

            if (Random.Range(1, 3) == 1)
                audioManager.PlaySFX(audioManager.swordFling1);
            else
                audioManager.PlaySFX(audioManager.swordFling2);
        }
    }
    // gun attack
    void OnShoot()
    {
        if (shootTimer >= shootCD)
        {
            shootTimer = 0f;
            animator.SetTrigger("IsAttacking");

            GameObject intBullet = Instantiate(bullet, meleeTransform.position, aim.rotation);

            if (Random.Range(1, 3) == 1)
                audioManager.PlaySFX(audioManager.gunShoot1);
            else
                audioManager.PlaySFX(audioManager.gunShoot2);

            intBullet.GetComponent<Rigidbody2D>().AddForce(-aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(intBullet, 3f);
        }
    }

    // melee timer
    void CheckMeleeTimer()
    {
        if (isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                attackTimer = 0;
                isAttacking = false;
                melee.SetActive(false);
            }
        }
    }
}
