using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject knife;
    public Vector2 pos;
    public Button restart;
    public SpriteRenderer[] sr = new SpriteRenderer[8];
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        knife.SetActive(true);
        pos = knife.transform.position;
        CreatingKnife();
        index = 0;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void CreatingKnife()
    {
        Instantiate(knife, pos, Quaternion.identity);        
    }

    public void onPressRestart()
    {
        knife.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void activateRestart()
    {
        knife.SetActive(false);
        restart.gameObject.SetActive(true);
    }

    public void knifeLeft()
    {
        sr[index].color = new Color32(255, 255, 255, 70);
        index++;
        if(index == 8)
        {
            activateRestart();
        }
    }
}
