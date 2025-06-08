# Counter Strike 2 Server Picker
<div align="center">

  <a href="https://api.github.com/repositories/649341649/releases"><img src="https://img.shields.io/github/downloads/FN-FAL113/cs2-server-picker/total.svg"/></a>
  <img src="https://img.shields.io/github/license/FN-FAL113/cs2-server-picker"/>
  <img src="https://img.shields.io/github/v/release/FN-FAL113/cs2-server-picker"/>
  <img src="https://img.shields.io/github/stars/FN-FAL113/cs2-server-picker"/>

</div>
A lightweight server picker for CS2. Previously developed for CS:GO and now for CS2! All regions available are included for freedom of selection. Still showing passion for the game since I started playing way back 2013.

## ⬇️ Download
### [Releases](https://github.com/FN-FAL113/csgo-server-picker/releases)

## 📷 Screenshot
![CS2ServerPicker](https://github.com/user-attachments/assets/e5c7c2a7-c560-4826-bcd5-9540d66abec6)
![Demo.gif](https://github.com/FN-FAL113/cs2-server-picker/assets/88238718/a46e515c-d591-49e2-ac98-f6f0088bf8eb)

## 🧪 Test Result
<details>
  <summary>Test 1</summary>

  ![Initial Setup](https://github.com/user-attachments/assets/3461718d-a33a-47f0-aef2-156ed76b5e1b)
  ![In-Game Result](https://github.com/user-attachments/assets/e26bd22f-bd0c-4c70-891d-a5ae6f091e40)
</details>

<details>
  <summary>Test 2</summary>
  
  ![Screenshot 2025-06-06 193216](https://github.com/user-attachments/assets/c15af912-d964-4461-b706-2a8bb0c2d00b)
  ![20250606193344_1](https://github.com/user-attachments/assets/57ae9c7f-afca-42fa-b88a-9e77bca83570)
  ![20250608195438_1](https://github.com/user-attachments/assets/d7ebd25f-6f17-414d-994f-f217b2d05864)
</details>

## ⚙️ Requirements
- Windows 10 or above
- Works on Windows 8.1 but requires [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer) to be installed separately.

## ❔FAQ
**1. How it works, will I get banned?!**
 - The app does not modify any game or system files, I can assure you are safe from being banned when using the app as long as you do not download from untrusted sources. It will add necessary firewall policies to block game server relay ip addresses from being accessed by your network thus skipping them in-game when finding a match.

**2. Not being routed to lowest ping server or not working on your location?**
  - Due to the fact that we can only access and block **_IP relay addresses_** from valve's network points around the world rather than the game's actual server IP addresses directly, which are **_not exposed_** publicly, either your connection got relayed to the nearest available server due to **_how Steam Datagram relay works_** or **_your location might be a factor_**. 
- Re-routing can also happen anytime, even mid-game. One of the best ways to test it out is to block low-ping servers and leave out high-ping servers that are far from your current region. If your ping is high in-game, then you are being routed properly, and the blocked IP relays are not able to re-route you to a nearby server. I was able to test this out properly way back.
- Some solutions that might help out but are not guaranteed: turning off any vpn, uninstalling third-party antivirus and let windefender manage the firewall.
- ISP-related issues, such as bad routing or high ping, are out of scope and control since the app only adds firewall entries. Please contact your ISP instead.

**3. Why it requires admin permission on execution?<br>**
  - This is due to how Windows requires elevated execution when adding the necessary firewall policies. If the app is running in normal mode, it will not be able to do its operations and will throw errors.

**4. Windows smartscreen detected unrecognized app/publisher<br>**
  - The app requires a registered publisher which costs a lot of money. Rest assured the app is safe and has been tested already with more than 10k downloads.

![image](https://github.com/FN-FAL113/csgo-server-picker/assets/88238718/fe0af8a8-4195-457e-bbbf-3a772e7f646c)

**5. I'm receiving frequent timeouts when a match is being confirmed<br>**
  - You may have blocked many servers, for optimal searching and relaying block only the necessary server relays.

**6. Why windows only?<br>**
  - The app is written using VB.NET, and Windows platform still dominates the gaming scene due to better compatibility. [Steam Charts](https://store.steampowered.com/hwsurvey/) has great statistics on this.

**7. Will this work for Deadlock?**
  - CS2 and Deadlock servers utilize same server relay addresses. Although I haven't tested it, there is a high chance it will work for deadlock and some reddit posts have recommended this app, give it a shot 😉.

## 📔 To Do
- TBD

## 💡 Contributors
- @Mohamad82Bz (for testing out the app on EU Servers and providing necessary details)
- contributors on pull requests and issue tracker
- donors for heart-warming donations

## 🔽 Disclaimer
- This project or its author are not affiliated, associated, authorized, endorsed by valve, its affiliates or subsidiaries. Images, names and other form of trademark are registered to their respective owners.

## 💖 Support the Project/Dev
- I develop stuff for free with dedication and hard work. Sharing this project with fellow gamers or giving it a star is a huge sign of appreciation!</br>
<a href="https://www.paypal.com/paypalme/fnfal113" target=_blank>
  <img src="https://raw.githubusercontent.com/stefan-niedermann/paypal-donate-button/master/paypal-donate-button.png" alt="Donate with PayPal" width="36%" />
</a>
