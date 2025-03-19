using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 movement;
    public Animator animator;
    public float lastDirX;
    public float lastDirY;
    public Attack attack;

    public float movementSpeed;
    public float movementSpeedDefault = 5f;

    public Transform aim;
    bool isWalking = false;

    private Vector3 aimUpPosition = new Vector3(0.367f, 0.3f, 0);
    private Vector3 aimLeftPosition = new Vector3(-0.35f, -0.044f, 0);
    private Vector3 aimRightPosition = new Vector3(0.39f, -0.078f, 0);
    private Vector3 aimDownPosition = new Vector3(-0.23f, -0.47f, 0);

    public Vector3 playerPosition;

    public PlayerHealth playerHealth;

    private void Awake()
    {
        Time.timeScale = 1;

        animator.SetInteger("WeaponHeld", 0);
        movementSpeed = movementSpeedDefault;

        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // animations based on object heald
        Item item = InventoryManager.instance.GetSelectedItem(false);

        if (item != null)
        {
            if (item.type == ItemType.Sword)
            {
                animator.SetInteger("WeaponHeld", 1);
            }
            else if (item.type == ItemType.Gun)
            {
                animator.SetInteger("WeaponHeld", 2);
            }
            else if (item.type == ItemType.HealthPot)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameObject.GetComponent<PlayerHealth>().UpdateHealth(5);
                    InventoryManager.instance.GetSelectedItem(true);
                }
            }
            else
            {
                animator.SetInteger("WeaponHeld", 0);
            }
        }
        else
        {
            animator.SetInteger("WeaponHeld", 0);
        }

        // movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // movement animations
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // if moving
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("LastHorizontal", movement.x);
            animator.SetFloat("LastVertical", movement.y);
            lastDirX = movement.x;
            lastDirY = movement.y;
            
            isWalking = true;
        }
        // if idle
        else if (movement.x == 0 && movement.y == 0)
        {
            isWalking = false;
            Vector3 vector3 = Vector3.left * lastDirX + Vector3.down * lastDirY;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    private void FixedUpdate()
    {
        // movement mechanics
        if (!attack.isAttacking)
        {
            rb.MovePosition(rb.position + movement * movementSpeed * Time.fixedDeltaTime);
        }
        
        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * movement.x + Vector3.down * movement.y;
            aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }

        string animationName = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (animationName.Contains("_Up")) aim.transform.localPosition = aimUpPosition;
        else if (animationName.Contains("_Left")) aim.transform.localPosition = aimLeftPosition;
        else if (animationName.Contains("_Right")) aim.transform.localPosition = aimRightPosition;
        else if (animationName.Contains("_Down")) aim.transform.localPosition = aimDownPosition;
    }

    //public void LoadData(GameData data)
    //{
    //    transform.position = data.playerPosition;
    //}

    //public void SaveData(ref GameData data)
    //{
    //    data.playerPosition = transform.position;
    //}

}
