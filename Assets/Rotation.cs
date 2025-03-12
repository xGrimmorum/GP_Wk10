using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform Cube1;
    public Transform Cube2;
    public Transform Cube3;

    public float rotationSpeed = 180f;

    private void Start()
    {
        StartCoroutine(RotateCube(Cube1, 3f)); 
        StartCoroutine(RotateCube(Cube2, 5f)); 
        StartCoroutine(RotateCube(Cube3, 7f)); 

        RotateCubeTask(Cube1, 3f);
        RotateCubeTask(Cube2, 5f);
        RotateCubeTask(Cube3, 7f);
    }

    private IEnumerator RotateCube(Transform cube, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            cube.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

    }

    private async void RotateCubeTask(Transform cube, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            cube.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            await Task.Yield(); 
        }

    }
}