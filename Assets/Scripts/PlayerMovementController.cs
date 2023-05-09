using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CommandProcessor))]

public class PlayerMovementController : MonoBehaviour, IEntity {
    [SerializeField] private float acceleration;
    [SerializeField] private float maxRunSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb2D;
    private PolygonCollider2D polyCollider;
    private SpriteRenderer spriteRenderer;
    private Vector2 velocity = new Vector2();
    private float currentSpeed = 0;
    private bool grounded = false;
    private IPlayerState currentState = new IdleState();
    private CommandProcessor commandProcessor;
    private Interactions interactions;
    public static bool fromLoad = false;
    public static bool fromSave = false;

    private void Awake() {
        Debug.Log("Awake Player");
        rb2D = GetComponent<Rigidbody2D>();
        polyCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        commandProcessor = GetComponent<CommandProcessor>();
        interactions = GetComponent<Interactions>();
    }

    private void Update() {
        UpdateState();
        if(Input.GetKeyDown(KeyCode.F)) {
            LoadGame();
        }
        if(Input.GetKeyDown(KeyCode.Q)) {
            SaveGame();
        }
        
        if(fromLoad) {
            LoadGame();
            fromLoad = false;
            Debug.Log("LoadFrom");
        }
        if(fromSave) {
            SaveGame();
            fromSave = false;
            Debug.Log("SaveFrom");
        }
    }

    private void UpdateState() {
        IPlayerState newState = currentState.Tick(this);

        if (newState != null) {
            currentState.Exit(this);
            currentState = newState;
            newState.Enter(this);
        }
    }

    private void SaveGame() {
        Debug.Log("Save");
        SaveSystem.SavePlayer(interactions, this);
        SaveSystem.SaveFish(interactions);
    }

    private void LoadGame() {
        Debug.Log("Load");
        PlayerData playerData = SaveSystem.LoadPlayer();

        interactions.getHealth = playerData.getHealth;
        interactions.getFish = playerData.getFish;

        Vector2 position;
        position.x = playerData.position[0];
        position.y = playerData.position[1];
        transform.position = position;

        FishData fishData = SaveSystem.LoadFish();

        interactions.getFish0Collected = fishData.getFish0Collected;
        interactions.getFish1Collected = fishData.getFish1Collected;
        interactions.getFish2Collected = fishData.getFish2Collected;
        interactions.getFish3Collected = fishData.getFish3Collected;
        interactions.getFish4Collected = fishData.getFish4Collected;
        interactions.getFish5Collected = fishData.getFish5Collected;
        interactions.getFish6Collected = fishData.getFish6Collected;
        interactions.getFish7Collected = fishData.getFish7Collected;
        interactions.load();
    }

    public void OnGroundedChange(bool onGround) {
        grounded = onGround;
        animator.SetBool("isJumping", !onGround);
    }

    public float getCurrentSpeed {
        get { return currentSpeed; }
        set { currentSpeed = value; }
    }

    public float getJumpSpeed {
        get { return jumpSpeed; }
        set { jumpSpeed = value; }
    }

    public bool getOnGround {
        get { return grounded; }
        set { grounded = value; }
    }

    public Rigidbody2D getRigidBody2D {
        get { return rb2D; }
        set { rb2D = value; }
    }

    public PolygonCollider2D getPolygonCollider2D {
        get { return polyCollider; }
        set { polyCollider = value; }
    }

    public float getYVelocity {
        get { return velocity.y; }
        set { velocity.y = value; }
    }

    public float getXVelocity {
        get { return velocity.x; }
        set { velocity.x = value; }
    }

    public Vector2 getVelocity {
        get { return velocity; }
        set { velocity = value; }
    }

    public Animator getAnimator {
        get { return animator; }
    }

    public float getMaxRunSpeed {
        get { return maxRunSpeed; }
        set { maxRunSpeed = value; }
    }

    public SpriteRenderer getSpriteRenderer {
        get { return spriteRenderer; }
        set { spriteRenderer = value; }
    }

    public float getAcceleration {
        get { return acceleration; }
        set { acceleration = value; }
    }
}
