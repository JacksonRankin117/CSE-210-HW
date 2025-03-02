using System;
using System.Collections.Generic;

class Timer
{
    public void DisplayLoadingIcon(int duration)
    {   
        // List of loading icons
        List<string> loadingIcons = new List<string>{"|", "/", "-", "\\"};

        // Start time and end time
        int _startTime = 0;
        int _endTime = duration;

        // Progress bar elements
        int progressBarLength = 30;
        int progress = 0;

        // Starts at the first index of the list
        int _index = 0;

        while (_startTime < _endTime)
        {
            // Print loading icon with progress bar
            string progressBar = new string('#', progress) + new string('-', progressBarLength - progress);
            Console.Write("\r[{0}] {1} {2}s remaining", progressBar, loadingIcons[_index], (_endTime - _startTime));

            // Wait for 1 second
            System.Threading.Thread.Sleep(1000);

            // Increment start time
            _startTime++;

            // Update progress based on the elapsed time
            progress = (int)((_startTime / (float)_endTime) * progressBarLength);

            // Move to the next icon in the list
            _index = (_index + 1) % loadingIcons.Count;
        }

        // Ensure the progress bar is fully filled at the end
        string finalProgressBar = new string('#', progressBarLength);
        Console.WriteLine($"\r[{finalProgressBar}] {loadingIcons[_index]} 0s remaining\nTime's up!");
    }
}
