# Introduction 

This project tries to get the power of [blazor](https://blazor.net/) to the desktop cross platform.

Based on the excelent lightweight Chromium wrapper for .NET Core [Chromely](https://github.com/mattkol/Chromely) it's lean, super flexible and fast!

Have a quick question? Wanna chat? Connect on [![Join the chat at https://gitter.im/BlasterBlazor/Lobby](https://badges.gitter.im/BlasterBlazor/Lobby.svg)](https://gitter.im/BlasterBlazor/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# Getting Started
1. Install [.NET Core 2.1 SDK](https://www.microsoft.com/net/download/) or later.
2. Run `build run` and you are good to go!
<!-- 2.	Software dependencies
3.	Latest releases
4.	API references
-->

# Build and Test

The following build referes to `build.cmd` on windows, for macos/linux use `./build.sh` instead.

* `build`: Builds the project in `Debug` configuration.
* `build clean`: Cleans all build artifacts.
* `build restore`: Restores the `nuget` dependencies.
* `build run`: Builds and runs the project in `Debug` configuration

# Roadmap
[ ] Get dotnet standard working without [build script](https://github.com/biohazard999/Blaster/blob/master/build.cake) ([dotnet run](https://github.com/mattkol/Chromely/issues/30))
[ ] Get [Linux support running](https://github.com/mattkol/Chromely/issues/30)
[ ] Get [Mac support running](https://github.com/mattkol/Chromely/wiki/Roadmap-and-Help-Wanted)
[ ] Debug support
[ ] Call Server function from client with ease (Strongly typed) aka. `GetBackendService<T>()`.
[ ] Investigate multi process server.
[ ] Create a Logo.
[ ] Add Templates.
[ ] Hot reload.

# Contribute
Feel free to file an issue, send a PR, [grab a up for grabs](https://up-for-grabs.net/)
Have a quick question? Wanna chat? Connect on [![Join the chat at https://gitter.im/BlasterBlazor/Lobby](https://badges.gitter.im/BlasterBlazor/Lobby.svg)](https://gitter.im/BlasterBlazor/Lobby?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

- [Chromely](https://github.com/mattkol/Chromely)
- [Blazor](https://blazor.net/)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [.NET Core 2.1 SDK](https://www.microsoft.com/net/download/)
