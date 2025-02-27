using System;

class Timer{
    public void DisplayLoadingIcon(int duration)
    {   
        // List of loading icons
        List<string> loadingIcons = new List<string>{"|", "/", "-", "\\"};

        // Starts at zero seconds
        int _startTime = 0;

        // Ends when it reaches the duration
        int _endTime = duration;

        // Starts at the first index of the list
        int _index = 0;

        while (_startTime < _endTime)
        {
            foreach (string icon in loadingIcons)
            {
                // Display the loading icon
                Console.Write(icon);

                // Wait for 1 second
                System.Threading.Thread.Sleep(250);

                // Clear the last character
                Console.Write("\b \b");

                // Move to the next icon in the list
                _index = (_index + 1) % loadingIcons.Count;
            }
            // Increment the start time
            _startTime++;
        }
    }
}