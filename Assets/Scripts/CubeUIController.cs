using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class CubeUIController : MonoBehaviour
{
    [SerializeField] private CubeController cube;

    private Button playButton;
    private Button stopButton;
    private Button colorButton;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        playButton = root.Q<Button>("play_button");
        stopButton = root.Q<Button>("stop_button");
        colorButton = root.Q<Button>("color_button");

        if (cube == null || playButton == null || stopButton == null || colorButton == null)
        {
            Debug.LogError("CubeUIController could not find the cube or one of the UI Toolkit buttons.", this);
            return;
        }

        playButton.clicked += OnPlayClicked;
        stopButton.clicked += OnStopClicked;
        colorButton.clicked += OnColorClicked;
    }

    private void OnDisable()
    {
        if (playButton != null)
        {
            playButton.clicked -= OnPlayClicked;
        }

        if (stopButton != null)
        {
            stopButton.clicked -= OnStopClicked;
        }

        if (colorButton != null)
        {
            colorButton.clicked -= OnColorClicked;
        }
    }

    private void OnPlayClicked() => cube.StartRotation();

    private void OnStopClicked() => cube.StopRotation();

    private void OnColorClicked() => cube.ChangeColor();
}
