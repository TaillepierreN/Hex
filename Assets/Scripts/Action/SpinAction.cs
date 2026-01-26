using UnityEngine;

public class SpinAction : BaseAction
{

    private float _totalSpinAmount;

    private void Update()
    {
        if (!_isActive)
            return;

        float spinAddAmount = 360f * Time.deltaTime; ;
        transform.eulerAngles += new Vector3(0, spinAddAmount, 0);

        _totalSpinAmount += spinAddAmount;
        if (_totalSpinAmount >= 360f)
        {
            _isActive = false;
            _totalSpinAmount = 0f;
        }
    }

    public void Spin()
    {
        _isActive = true;
    }
}
