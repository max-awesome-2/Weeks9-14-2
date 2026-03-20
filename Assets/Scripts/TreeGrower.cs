using System.Collections;
using UnityEngine;

public class TreeGrower : MonoBehaviour
{

    public AnimationCurve growCurve;
    public float duration = 2f;
    private float progress = 0f;


    public GameObject applePrefab;
    public float appleGrowDuration;

    public Transform canopy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator TreeGrowUpdate()
    {
        float progress = 0;

        while (progress < duration)
        {
            progress += Time.deltaTime;

            transform.localScale = Vector3.one * (growCurve.Evaluate(progress / duration));

            yield return null;
        }

        while (true) {
            yield return StartCoroutine(GrowApple());
        }
    }

    private IEnumerator GrowApple()
    {
        GameObject spawnedApple = Instantiate(applePrefab, canopy.position, Quaternion.identity);
        spawnedApple.transform.localScale = Vector3.zero;
        spawnedApple.transform.position += (Vector3)Random.insideUnitCircle * 2f;
        float progress = 0f;

        while (progress < appleGrowDuration)
        {
            progress += Time.deltaTime;

            spawnedApple.transform.localScale = Vector3.one * (growCurve.Evaluate(progress / appleGrowDuration));

            yield return null;
        }
    }

    public void OnGrowPress()
    {
        StartCoroutine(TreeGrowUpdate());

    }
}
