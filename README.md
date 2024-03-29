# NASA Astronomy Picture of The Day Changer
Thanks for checking out the APOD Changer! This program will set your desktop background to the Astronomy Picture of The Day and can be easily configured to automatically do so on startup. It also outputs an explanation of the image, along with the date and title.

![APOD Example](APODExample.PNG)

# Installation
- You ***need*** the [Microsoft Visual C++ Redistributable](https://support.microsoft.com/en-us/topic/the-latest-supported-visual-c-downloads-2647da03-1eea-4433-9aff-95f26a218cc0), and the [.NET Framework](https://dotnet.microsoft.com/download/dotnet-framework) for the program to run correctly if you're not compiling from source.
1. Navigate to the ![releases section](https://github.com/wmcnamara/apodchanger/releases), and find the most recent version.
2. Download the APODChanger.zip file, and extract it.
3. Navigate to the extracted files, and open the APODChanger folder.
4. Running the `WinAPODChanger.exe` file will run the program and update your desktop background, along with displaying the info.

## Adding To Startup:
1. Right-click the `WinAPODChanger.exe` file, and select "Create Shortcut".
2. Open the "Run" dialog prompt. You can do this by hitting Win + R on your keyboard, or typing "Run" into Cortana, and pressing enter.
3. Type `shell:startup`, and hit enter. This will open your startup folder.
4. Move the shortcut file into this folder. The shortcut file will likely be called "WinAPODChanger.exe - Shortcut", or something along those lines.

### Notes:
- This program works best when the desktop resolution is 1920x1080, and because of the variance in image size that the Astronomy Picture of the day is often uploaded in, will sometimes not fit correctly to the screen dimensions, especially for people who are not on 1920x1080.
- Sometimes the Astronomy Picture of The Day is actually a YouTube video, or some other media format that cant be set as a desktop background. When you notice an exception is thrown, or recieve an error, this is likely the case. Just check the actual APOD website for the picture on that day.

# Reporting Bugs
If you experience issues running the program or receive an error message when running the program, please open a Github issue on this repository with a description of the issue, and a picture of the error. ![You can do this here.](https://github.com/wmcnamara/apodchanger/issues)
