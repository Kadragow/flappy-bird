using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float DelayTime;

    public GameObject obstacle;

    private List<GameObject> obj;
    private bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {
        isGamePaused = false;
        InvokeRepeating("RenderObstacle", 0.0f, DelayTime);
        obj = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isGamePaused)
            {
                Time.timeScale = 1f;
                isGamePaused = false;
            }
            else
            {
                Time.timeScale = 0;
                isGamePaused = true;
            }
        }
        List<GameObject> toRemove = new List<GameObject>();

        foreach (var item in obj)
        {
            if(item.transform.position.x < -30f)
            {
                toRemove.Add(item);
            }
        }

        foreach (var item in toRemove)
        {

            obj.Remove(item);
            Destroy(item);
        }
    }

    void RenderObstacle()
    {
        obj.Add(Instantiate(obstacle, new Vector3(30, Random.Range(-6, 6), 0), Quaternion.identity));
    }

    IEnumerator WaitForNext()
    {
        yield return new WaitForSeconds(DelayTime);
    }
}
