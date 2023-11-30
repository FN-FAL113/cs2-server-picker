# Counter Strike 2 Server Picker
<div align="center">
 
  ![image](https://img.shields.io/github/downloads/FN-FAL113/cs2-server-picker/total.svg)
  ![GitHub](https://img.shields.io/github/license/FN-FAL113/cs2-server-picker)
  ![GitHub release (with filter)](https://img.shields.io/github/v/release/FN-FAL113/cs2-server-picker)
  ![GitHub Repo stars](https://img.shields.io/github/stars/FN-FAL113/cs2-server-picker)

</div>

A lightweight server picker for CS2. Previously developed for CS:GO but is now for CS2! All regions available are included for freedom of selection. Still showing passion for the game since I started playing way back in 2013 despite the fact that my laptop cannot handle the game anymore with the new visual upgrades 😃.

## ⬇️ Download
### [Releases](https://github.com/FN-FAL113/csgo-server-picker/releases)

## 📷 Screenshot
![CS2ServerPicker](https://github.com/FN-FAL113/cs2-server-picker/assets/88238718/3e574931-f3f1-4b41-afdc-7dd33a6f87f8)
![Demo.gif](https://github.com/FN-FAL113/cs2-server-picker/assets/88238718/a46e515c-d591-49e2-ac98-f6f0088bf8eb)

## ⚙️ Requirements
- Windows 10 or Above
- Works on Windows 8.1 but requires [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer) to be installed separately

## ❔FAQ

**1. Not being routed to lowest ping server or not working on your location?**
  - Due to the fact that we can only access and block IP relay addresses from valve's network points around the world rather than the game's actual server IP addresses directly, which are not exposed publicly, either your connection got relayed to the nearest available server due to how Steam Datagram relay works or your location might be a factor. Re-routing can also happen anytime, even mid-game. One of the best ways to test it out is to block low-ping servers and leave out high-ping servers that are far from your current region. If your ping is high in-game, then you are being routed properly, and the blocked IP relays are not able to re-route you to a nearby server. I was able to test this out properly way back.

**2. Why it requires admin permission on execution?<br>**
  - This is due to how Windows requires elevated execution when adding the necessary firewall policies. If the app is running in normal mode, it will not be able to do its operations and will throw errors.

**3. Windows smartscreen detected unrecognized app/publisher<br>**
  - The app requires a registered publisher which costs a lot of money. Rest assured the app is safe and has been tested by several users.

![image](https://github.com/FN-FAL113/csgo-server-picker/assets/88238718/fe0af8a8-4195-457e-bbbf-3a772e7f646c)

**4. I'm receiving frequent timeouts when a match is being confirmed<br>**
  - You may have blocked many servers, for optimal searching and relaying block only the necessary server relays.

**5. Why windows only<br>**
  - The app is written using VB.NET, and the Windows platform still dominates the gaming scene due to better compatibility. Steam Charts has great statistics on this.

## 📔 To Do
= TBD

## 💡 Contributors
- @Mohamad82Bz (for testing out the app on EU Servers and providing necessary details)

## 💙 Donors
- Thanks to @rainbowjose for the donation.
- Thanks to @kulture for the donation.

## 💖 Support the Project/Dev
I develop stuff for free with dedication and hard work. Sharing this project with fellow gamers or giving it a star is a huge sign of appreciation!</br>
As requested by a few generous people, a donation button (currently using parent's paypal due to my pending account requirements). Donations go towards the goal of getting a PC:<br/>
<a href="https://www.paypal.com/paypalme/ameliaOrbeta" target=_blank>
  <img src="https://raw.githubusercontent.com/stefan-niedermann/paypal-donate-button/master/paypal-donate-button.png" alt="Donate with PayPal" width="40%" />
</a>
