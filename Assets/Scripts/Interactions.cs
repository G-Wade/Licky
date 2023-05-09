using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactions : MonoBehaviour
{
    [SerializeField] private GameObject fish0;
    [SerializeField] private GameObject fish1;
    [SerializeField] private GameObject fish2;
    [SerializeField] private GameObject fish3;
    [SerializeField] private GameObject fish4;
    [SerializeField] private GameObject fish5;
    [SerializeField] private GameObject fish6;
    [SerializeField] private GameObject fish7;

    private bool fish0Collected = false;
    private bool fish1Collected = false;
    private bool fish2Collected = false;
    private bool fish3Collected = false;
    private bool fish4Collected = false;
    private bool fish5Collected = false;
    private bool fish6Collected = false;
    private bool fish7Collected = false;

    private int fish = 0;
    private int totalFish = 8;
    private int health;

    public Text fishText;
    public Text healthText;
    [SerializeField] public GameObject door;
    private BoxCollider2D doorCollider;

    // Start is called before the first frame update
    void Start()
    {
        fish = 0;
        health = 3;
        doorCollider = door.GetComponent<BoxCollider2D>();
        doorCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        fishText.text = "FISH : " + fish + "/" + totalFish;
        healthText.text = "HEALTH : " + health;
        if(fish == totalFish) {
            doorCollider.enabled = true;
        }
        if(health == 0) {
            SceneManager.LoadScene("Menu");
        }
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 8) {
            if(other.gameObject == fish0){
                fish0Collected = true;
            } else if(other.gameObject == fish1) {
                fish1Collected = true;
            } else if(other.gameObject == fish2) {
                fish2Collected = true;
            } else if(other.gameObject == fish3) {
                fish3Collected = true;
            } else if(other.gameObject == fish4) {
                fish4Collected = true;
            } else if(other.gameObject == fish5) {
                fish5Collected = true;
            } else if(other.gameObject == fish6) {
                fish6Collected = true;
            } else if(other.gameObject == fish7) {
                fish7Collected = true;
            }
            Debug.Log("Fish");
            other.gameObject.SetActive(false);
            fish += 1;
            fishText.text = "FISH : " + fish + "/" + totalFish;
        }
        if(other.gameObject.layer == 7) {
            Debug.Log("Spike");
            health -= 1;
            healthText.text = "HEALTH : " + health;
        }
    }

    public void load() {
        fish0.SetActive(!fish0Collected);
        fish1.SetActive(!fish1Collected);
        fish2.SetActive(!fish2Collected);
        fish3.SetActive(!fish3Collected);
        fish4.SetActive(!fish4Collected);
        fish5.SetActive(!fish5Collected);
        fish6.SetActive(!fish6Collected);
        fish7.SetActive(!fish7Collected);
    }

    public int getHealth {
        get { return health; }
        set { health = value; }
    }

    public int getFish {
        get { return fish; }
        set { fish = value; }
    }

    public bool getFish0Collected {
        get { return fish0Collected; }
        set { fish0Collected = value; }
    }

    public bool getFish1Collected {
        get { return fish1Collected; }
        set { fish1Collected = value; }
    }

    public bool getFish2Collected {
        get { return fish2Collected; }
        set { fish2Collected = value; }
    }

    public bool getFish3Collected {
        get { return fish3Collected; }
        set { fish3Collected = value; }
    }

    public bool getFish4Collected {
        get { return fish4Collected; }
        set { fish4Collected = value; }
    }

    public bool getFish5Collected {
        get { return fish5Collected; }
        set { fish5Collected = value; }
    }

    public bool getFish6Collected {
        get { return fish6Collected; }
        set { fish6Collected = value; }
    }

    public bool getFish7Collected {
        get { return fish7Collected; }
        set { fish7Collected = value; }
    }
}
