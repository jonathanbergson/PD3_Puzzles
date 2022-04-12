using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle : MonoBehaviour
{
    private const int DelayTime = 2;

    public static Puzzle Instance;
    private int _crateCount;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCrate()
    {
        _crateCount++;

        if (_crateCount == 3)
        {
            StartCoroutine(Delay());
            SceneManager.LoadScene(Constants.ScenePuzzle02);
        }
    }

    public void RemoveCrate()
    {
        _crateCount--;
    }

    IEnumerator Delay()
    {
        print(Time.time);
        yield return new WaitForSeconds(DelayTime);
        print(Time.time);
    }
}
