# Audio Recognition -- File Scan Tool (C# Software)

## Overview
[ACRCloud](https://www.acrcloud.com/) provides [Automatic Content Recognition](https://www.acrcloud.com/docs/introduction/automatic-content-recognition/) services for [Audio Fingerprinting](https://www.acrcloud.com/docs/introduction/audio-fingerprinting/) based applications such as **[Audio Recognition](https://www.acrcloud.com/music-recognition)** (supports music, video, ads for both online and offline), **[Broadcast Monitoring](https://www.acrcloud.com/broadcast-monitoring)**, **[Second Screen](https://www.acrcloud.com/second-screen-synchronization)**, **[Copyright Protection](https://www.acrcloud.com/copyright-protection-de-duplication)** and etc.<br>

This tool can scan audio/video files and detect audios you want to recognize such as music, ads.

Supported format:

>>Audio: mp3, wav, m4a, flac, aac, amr, ape, ogg ...<br>
>>Video: mp4, mkv, wmv, flv, ts, avi ...

## Requirements
Follow one of the tutorials to create a project and get your host, access_key and access_secret.

* [How to identify songs by sound](https://www.acrcloud.com/docs/tutorials/identify-music-by-sound/)

* [How to detect custom audio content by sound](https://www.acrcloud.com/docs/tutorials/identify-audio-custom-content/)

## Windows Runtime Library 
**you must install this library.**<br>
X86: [download and install Library(windows/vcredist_x86.exe)](https://www.microsoft.com/en-us/download/details.aspx?id=5555)


## Usage

1.When you first run the program. Fill in the host, Access key, Access secret. 

2.Choose File(Files) you want to recognize.

3.Start to recognize.

4.Export the result.

<img src="https://github.com/acrcloud/acrcloud_scan_files_for_windows/raw/master/imgs/stepbystep.png" width="50%" height="50%">

<img src="https://github.com/acrcloud/acrcloud_scan_files_for_windows/raw/master/imgs/scan_example.png" width="50%" height="50%">

<img src="https://github.com/acrcloud/acrcloud_scan_files_for_windows/raw/master/imgs/export.png" width="50%" height="50%">

## Change Settings

- If you want to change scan interval, you can change the interval textbox.

<img src="https://github.com/acrcloud/acrcloud_scan_files_for_windows/raw/master/imgs/change_interval.png" width="50%" height="50%">

- If you want to change scan range, you can change the start textbox ande stop textbox.

<img src="https://github.com/acrcloud/acrcloud_scan_files_for_windows/raw/master/imgs/change_range.png" width="50%" height="50%">

- If you want to change host or key and secert, you can click change config button.