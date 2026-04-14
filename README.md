<h1 align="center">🧩 CompilerInfocardsUI</h1>

<p align="center">
  GUI control panel for building and editing <b>Freelancer (2003)</b> / <b>Lizerium</b> <b>infocard DLL resources</b>
</p>

<p align="center">
  <img src="https://shields.dvurechensky.pro/badge/Platform-Windows-0078D6?style=for-the-badge&logo=windows&logoColor=white" />
  <img src="https://shields.dvurechensky.pro/badge/.NET-WinForms-512BD4?style=for-the-badge&logo=dotnet&logoColor=white" />
  <img src="https://shields.dvurechensky.pro/badge/Type-Internal%20Tool-3949AB?style=for-the-badge" />
  <img src="https://shields.dvurechensky.pro/badge/Game-Freelancer%202003-0E5CAD?style=for-the-badge" />
  <img src="https://shields.dvurechensky.pro/badge/Project-Lizerium-6A1B9A?style=for-the-badge" />
  <img src="https://shields.dvurechensky.pro/badge/Config-JSON-FF9800?style=for-the-badge&logo=json&logoColor=white" />
  <img src="https://shields.dvurechensky.pro/badge/Build-DLL%20Compiler-2E7D32?style=for-the-badge" />
  <img src="https://shields.dvurechensky.pro/badge/Status-Release-00C853?style=for-the-badge" />
</p>

<div align="center" style="margin: 20px 0; padding: 10px; background: #1c1917; border-radius: 10px;">
  <strong>🌐 Language: </strong>
  
  <a href="./README.ru.md" style="color: #F5F752; margin: 0 10px;">
    🇷🇺 Russian
  </a>
  | 
  <span style="color: #0891b2; margin: 0 10px;">
    ✅ 🇺🇸 English (current)
  </span>
</div>

---

> [!NOTE]
> This project is part of the **Lizerium** ecosystem and belongs to the following direction:
>
> - [`Lizerium.Tools.Structs`](https://github.com/Lizerium/Lizerium.Tools.Structs)
>
> If you are looking for related engineering and supporting tools, start there.

## 🌌 What is this

**CompilerInfocardsUI** is a **universal Windows GUI panel** that I built for centralized work with **Freelancer infocards**:

![alt text](Media/View.png)

- object names
- item descriptions
- text resources
- HTML representations of infocards
- game DLL libraries

In essence, this is a **HUB interface** on top of my internal utilities and build pipeline, allowing you to **quickly open required files**, **edit them**, and **compile final DLLs** using the external tool `frc.exe`.

---

## ❓ Why I built this

While developing and maintaining content for **Lizerium / Freelancer**, I accumulated a large file structure with:

- hundreds of text card variations
- multiple versions of names and descriptions
- duplicated files across different folders
- multiple DLL targets for different game scenarios

Over time, manual work with this became inefficient.

So I created a dedicated **control panel** that:

- brings all entry points into a single place
- opens required files without manual searching
- allows fast compilation of specific DLLs
- removes chaos from the file structure

---

## ⚙️ Features

### DLL Resource Compilation

The application can execute build commands for various game libraries:

#### `STRINGS`

- `SBM2`
- `RESOURCES`
- `NAMERESOURCES`
- `EQUIPRESOURCES`
- `OFFERBRIBERESOURCES`

#### `HTML`

- `SBM2`
- `MISCTEXT`
- `MISCTEXTINFO2`
- `EQUIPRESOURCES`
- `INFOCARDS`

#### `HTML + STRINGS`

- `SBM`
- `SBM3`

#### Full Build

- build **all DLL libraries at once**

---

## 🛠 Interface Capabilities

The application allows you to:

- open source files of a specific DLL library
- open the DLL folder
- open the project in **VS Code**
- edit specific files
- run compilation for selected libraries
- execute full batch compilation
- log all actions directly in the application UI

---

## 🧠 How it works

- All logic is driven by the configuration file:  
  [`configs.json`](CompilerInfocardsUI/CompilerInfocardsUI/configs.json)

  Example:

  ```json
  {
  	"SBM2_STRINGS": {
  		"ExePath": "frc.exe",
  		"Arguments": "SBM2\\STRINGS\\input.txt"
  	},
  	"VSCODE": {
  		"ExePath": "code",
  		"Arguments": "."
  	},
  	"RootDLLS": {
  		"ExePath": "explorer.exe",
  		"Arguments": "DLLS"
  	}
  }
  ```

```

* Configure your own paths to `frc.exe` (Adoxa) and generation files.

---

## Thx

> Thanks for the source code which helped me understand the infocard system.

* [http://adoxa.altervista.org/freelancer/tools.html#frc](http://adoxa.altervista.org/freelancer/tools.html#frc) — Adoxa

```
