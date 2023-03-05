using UnityEngine;

public class GeneratorHelper : MonoBehaviour
{
    public void GenerateGroup(GameObject objectToGenerate, float elementSize, float distanceFactor, float positionY, float screenCoveragePercentage)
    {
        GameObject element = Instantiate(objectToGenerate, transform);
        float spawnPositionX = CameraHelper.GetCameraBoundariesX().x + (elementSize);
        element.transform.SetPositionAndRotation(new Vector3(spawnPositionX, positionY), Quaternion.identity); // must use camera as reference for Y
        
        while (spawnPositionX < CameraHelper.CalculateScreenCoverageX(screenCoveragePercentage))
        {
            spawnPositionX += elementSize * distanceFactor;
            GameObject enemias = Instantiate(objectToGenerate, transform);
            enemias.transform.SetPositionAndRotation(new Vector3(spawnPositionX, positionY), Quaternion.identity);
        }
    }
}
