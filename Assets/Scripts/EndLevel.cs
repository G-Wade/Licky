using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Interactions interactions;

    // Start is called before the first frame update
    void Start()
    {
        interactions = player.GetComponent<Interactions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other) {
        if(interactions.getHealth == 3) {
            AchievementData.setHealthAchievement(true);
        }
        SceneManager.LoadScene("Menu");
    }
}
