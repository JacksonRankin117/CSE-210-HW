using System;

class BreathingActivity : Activity
{
    private int startTime = 0;
    private int _inhale = 5;
    private int _exhale = 10;
    
    public void BeginBreathing() 
    {
        Console.WriteLine("Prepare to begin by calming your mind. The activity will begin shortly");
        _timer.DisplayLoadingIcon(5);
        
        while (_duration >= startTime) {
            Console.WriteLine("Breathe in...");
            _timer.DisplayLoadingIcon(_inhale);

            Console.WriteLine("Breathe out...");
            _timer.DisplayLoadingIcon(_exhale);
            startTime += _inhale + _exhale;
        }
    }
}