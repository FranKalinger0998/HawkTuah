using UnityEngine;

public class TouchAndHoldDetector
{
    private float touchDuration = 0.0f;
    private bool touchHeld = false;
    private const float holdThreshold = 1.0f; // 1 seconds
    private Vector2 touchStartPosition;

    public delegate void TouchAndHoldAction(Vector2 position);
    public event TouchAndHoldAction OnTouchAndHold;

    public void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    touchDuration = 0.0f;
                    touchHeld = true;
                    touchStartPosition = touch.position;
                    break;

                case TouchPhase.Stationary:
                case TouchPhase.Moved:
                    if (touchHeld)
                    {
                        touchDuration += Time.deltaTime;
                        if (touchDuration >= holdThreshold)
                        {
                            touchHeld = false; // Prevent continuous triggering
                            OnTouchAndHold?.Invoke(touchStartPosition);
                        }
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    touchHeld = false;
                    touchDuration = 0.0f;
                    break;
            }
        }
    }
}