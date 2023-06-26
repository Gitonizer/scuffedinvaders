using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUpdater : MonoBehaviour
{
    private Text _livesText;
    private Player _player;

    public Image[] LivesImages;

    private Color _noColor;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag(Tags.PLAYER).GetComponent<Player>();
        _livesText = GetComponent<Text>();
        _noColor = new Color(1, 1, 1, 0);
    }

    private void Update()
    {
        if (!_player.HealthChanged)
            return;

        UpdateShips(_player.CurrentHealth);
    }

    private void UpdateShips(int currentHealth)
    {
        LivesImages[(LivesImages.Length - 1) - Mathf.Clamp(currentHealth, 0, LivesImages.Length - 1)].color = _noColor;
    }
}
