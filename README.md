# BrickTracker

Brick Tracker is a demo app written with .NET 6, Blazor, Blazor Desktop, .NET MAUI, and ASP.NET Core.
It runs on the web and natively on Windows, macOS, iOS, and Android.

1. Download BrickSet CSV datasets and view them in the app.
1. For example, you can create a free account on https://brickset.com and then go to https://brickset.com/sets/year-2021/theme-Harry-Potter and download the query results as a CSV by clicking the download icon (available only on large screen devices, when logged in).
   * Alternatively, you can download sample CSV files from the root of this repo: [2021 Harry Potter sets](https://raw.githubusercontent.com/Eilon/dotnetConf-BrickTracker/main/HarryPotterSets.csv), [2021 Lord of the Rings sets](https://raw.githubusercontent.com/Eilon/dotnetConf-BrickTracker/main/LOTR.csv).
1. On Windows and macOS place the CSV file in a folder named `Downloads` in the user's profile directory and the app will detect them.
1. On iOS and Android you can select individual files in the app.
1. On the web you can upload multiple files in the browser.

Watch a recording of the session where I showed this app: [Build cross-platform native apps with .NET MAUI and Blazor](https://www.youtube.com/watch?v=Dr8L7zXxwLI)
