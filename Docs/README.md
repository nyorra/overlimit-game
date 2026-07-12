# OVERLIMIT 🏎️

An arcade racing game inspired by the golden era of street racing and the aesthetics of the early 2000s.

## 🛠 Tech Stack

- **Engine:** [Unity](https://unity.com) (URP)
- **Language:** C# 9.0+
- **Version Control:** Git + Git LFS
- **Input System:** Unity New Input System
- **Architecture:** Fluent Validation Framework & Modular Controller/View Pattern

---

## 📏 Development Guidelines (Workflow)

To maintain a clean repository and ensure code scalability, the following standards are enforced:

### 1. Commit Message Standard

Format: `<prefix>: <description>`

- `feat`: New features or functionality.
- `fix`: Bug fixes.
- `refactor`: Structural code improvements without changing behavior.
- `docs`: Documentation updates.
- `clean`: Code cleanup, removing dead code, or unused imports.

### 2. Code & Architecture

- **Single Source of Truth:** All text strings and logs must be localized within `OVERLIMIT.Messages.Messages`.
- **Fluent Validation:** Every MonoBehaviour must validate its dependencies using the chaining syntax: `.BeginValidation().Require().LogAndCheck()`.
- **Contextual Logging:** When calling `OverLogger`, always pass `this` as the context parameter to ensure clickable source routing in the Unity console.
- **Namespaces:** Strict adherence to the folder structure (e.g., `OVERLIMIT.Features.Loading`).

---

## 📂 Project Structure

### 📁 Scripts/Core/

Global project infrastructure:

- `Messages.cs` — Centralized string repository (Single Source of Truth).
- `GameState.cs` — Core state management and save system tracking.
- `SceneType.cs` — Enum definitions for game locations and levels.

### 📁 Scripts/Features/

Modular implementation of game zones. Each module is self-contained and follows the Controller/View pattern:

- **Loading/** — Loading screen systems (Controller, View, Processor).
- **MainMenu/** — Main menu and its sub-systems (Garage, Settings, Credits).
- **City/** — Open-world gameplay mechanics.

### 📁 Scripts/Utility/

Toolsets and system extensions:

- **Logging/** — Custom `OverLogger` system with log level filtering and rich text color formatting.
- **Validation/** — Validation framework for automated Inspector reference checks.

---

## 👤 Credits & Legal

**Author:** Vlad "Nyorra"  
**Telegram:** [@nyorra](https://t.me)  
**Created:** March 31, 2026

### ⚖️ License / Legal Info

© 2026 Vlad Nyorra. **All rights reserved.**

This project is private intellectual property.

- Unauthorized copying, distribution, or commercial use of the source code and assets without explicit written consent from the author is strictly prohibited.
- This repository is intended for portfolio demonstration purposes only and is not Open Source.

---

## 🚀 Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/nyorra/Overlimit-Game.git
   ```
