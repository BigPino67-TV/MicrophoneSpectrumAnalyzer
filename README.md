# MicrophoneSpectrumAnalyzer
 A nice looking streaming tool to visualize your voice frequency.
 
![alt text](https://github.com/BigPino67-TV/MicrophoneSpectrumAnalyzer/blob/master/MicrophoneSpectrumAnalyzer.png)

# NAudio libraries
NAudio libraries are used to list all recording devices and the mincrophone audio for the animated spectrum.

# Accord libraries
Accord libraries are used to calculate the real FFT.

# AForge libraries
AForge libraries are used to show a video or your webcam as a background inside the circle.

# Inspiration
Strongly inspired by [ThinhVu/audioSpectrumAnalyzer](https://github.com/ThinhVu/audioSpectrumAnalyzer) for the drawing. Mainly remove BassNet to use NAudio instead.

# How to use with Streamlab OBS?
Add a new capture window, select "MicrophoneSpectrumAnalyzer.exe". Then add a Key Color filter with this hex : #00b140. All the green will become transparent for a sweet look in your stream!

# Do you like it?
You can follow or subscribe [my Twitch channel](https://www.twitch.tv/bigpino67).
