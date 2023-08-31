using UnityEngine;

public static class CameraHelper
{
    private static Camera camera = Camera.main;

    public static Vector2 GetCameraBoundariesX()
    {
        if (camera == null) camera = Camera.main;
        return new Vector2(camera.ViewportToWorldPoint(new Vector3(0, 0.5f, 0f)).x, camera.ViewportToWorldPoint(new Vector3(1, 0.5f, 0f)).x);
    }

    public static Vector2 GetCameraBoundariesY()
    {
        if (camera == null) camera = Camera.main;
        return new Vector2(camera.ViewportToWorldPoint(new Vector3(0, 0, 0f)).y, camera.ViewportToWorldPoint(new Vector3(1, 1, 0f)).y);
    }

    public static float CalculateScreenCoverageX(float percentage)
    {
        float value = (CameraHelper.GetCameraBoundariesX().y * 2 * percentage) / 100f;
        return value - CameraHelper.GetCameraBoundariesX().y;
    }

    public static float CalculateScreenCoverageY(float percentage)
    {
        float value =  (CameraHelper.GetCameraBoundariesY().y * 2 * percentage) / 100f;
        return value + CameraHelper.GetCameraBoundariesY().y;
    }
}
