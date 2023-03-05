using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public GameObject Building;

    private GeneratorHelper _helper;

    private float _height;
    private float _buildingSize;
    private float _buildingHeight;
    private float _distanceFactor;

    private const float PERCENTAGE = 80f;

    private void Awake()
    {
        _helper = GetComponent<GeneratorHelper>();
    }

    void Start()
    {
        _buildingSize = 1.65f;
        _buildingHeight = 1.15f;
        _distanceFactor = 1.6f;
        _height = CameraHelper.GetCameraBoundariesY().x + _buildingHeight * 2.2f;
        Generate();
    }

    public void Generate()
    {
        _helper.GenerateGroup(Building, _buildingSize, _distanceFactor, _height, PERCENTAGE);
    }
}
