# Counter Strike 2 Server Picker
A lightweight server picker for cs2. Previously developed for CS:GO but is now for CS2! All regions avaiable are included for freedom of selection.

## Download
### [Releases](https://github.com/FN-FAL113/csgo-server-picker/releases)

## Screenshot
![image](https://github.com/FN-FAL113/csgo-server-picker/assets/88238718/101e6b5b-b826-42a7-927a-316e7833d246)

## Requirements
- Windows 10 or Above
- Works on Windows 8.1 but requires [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer) to be installed separately

## FAQ
**1. Why it requires admin permission on execution?<br>**
  - This is due to how windows require elevated execution when adding the necessary firewall policies. If the app is running in normal mode it will not be able to do its operations and will throw errors.

**2. Windows smartscreen detected unrecognized app/publisher<br>**
  - The app requires a registered publisher which costs a lot of money. Rest assured the app is safe and has been tested by several users.

![image](https://github.com/FN-FAL113/csgo-server-picker/assets/88238718/fe0af8a8-4195-457e-bbbf-3a772e7f646c)

**3. I'm receiving frequent timeouts when a match is being confirmed<br>**
  - You may have blocked many servers, for optimal searching and relaying block only the necessary servers that you don't want to play on.

**4. ```status``` command tells incorrect server<br>**
  - Due to the fact that we can only access the relayed addresses rather than the game servers' IP addresses directly, its either your connection got relayed to the nearest available server.
  - you may checkout the light blue text from the console and see if the primary and backup router tells the exact servers that are not blocked from the app. Example: [paris-london-console-log.txt](https://github.com/FN-FAL113/csgo-server-picker/files/11701514/paris-london-console-log.txt)

**5. Why windows only<br>**
  - App is written using vb.net and windows platform still dominates the gaming scene due to better compatibility.

## To Do
- TBD

## Contributors
- @Mohamad82Bz (for testing out the app on EU Servers and providing necessary details)

## Support the Project
I develop stuffs for free with dedication and hardwork. Sharing this project or giving it a star are a huge sign of appreciation!
