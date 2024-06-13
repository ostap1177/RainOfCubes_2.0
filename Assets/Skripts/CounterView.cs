using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private ObjectCounter _counter;

    [SerializeField] private TextMeshProUGUI _textCountBomb;
    [SerializeField] private TextMeshProUGUI _textCountCubes;
    [SerializeField] private TextMeshProUGUI _textCountActiveObjext;

    private int _starCount = 0;

    private void Awake()
    {
        _textCountBomb.text = _starCount.ToString();
        _textCountCubes.text = _starCount.ToString();
        _textCountActiveObjext.text = _starCount.ToString();
    }

    private void FixedUpdate()
    {
        _textCountBomb.text = _counter.CountCreatedBomb.ToString();
        _textCountCubes.text = _counter.CountCreatedCubes.ToString();
        _textCountActiveObjext.text = _counter.CountActiveObject.ToString();
    }
}
