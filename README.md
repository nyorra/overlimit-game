# OVERLIMIT 🏎️

Аркадная гонка, вдохновленная золотой эрой стритрейтинга и эстетикой начала 2000-х.

## 🛠 Технологический стек

*   **Engine:** [Unity](https://unity.com) (URP)
*   **Language:** C# 9.0+
*   **Version Control:** Git + Git LFS
*   **Input System:** Unity New Input System
*   **Architecture:** Fluent Validation Framework & Modular Controller/View Pattern

---

## 📏 Правила разработки (Workflow)

Для поддержания чистоты репозитория и масштабируемости кода установлены следующие стандарты:

### 1. Стандарт коммитов
Формат: `<prefix>: <description>`
*   `feat`: Новый функционал.
*   `fix`: Исправление багов.
*   `refactor`: Улучшение структуры кода без смены логики.
*   `docs`: Обновление документации.
*   `clean`: Удаление мусора, неиспользуемых импортов.

### 2. Код и Архитектура
*   **Single Source of Truth:** Все текстовые данные и логи вынесены в `OVERLIMIT.Messages.AppMessages`.
*   **Fluent Validation:** Любой MonoBehaviour обязан проверять зависимости через цепочку `.BeginValidation().Require().LogAndCheck()`.
*   **Contextual Logging:** При вызове `OverLogger` обязательно передается `this` для обеспечения кликабельности контекста в консоли Unity.
*   **Namespaces:** Строгое соответствие пространств имен структуре папок (например, `OVERLIMIT.Features.Loading`).

---

## 📂 Структура проекта

### 📁 Scripts/Core/
Глобальная инфраструктура проекта:
*   `AppMessages.cs` — Единое хранилище всех строк (Single Source of Truth).
*   `GameState.cs` — Управление глобальным состоянием и сохранениями.
*   `SceneType.cs` — Перечисление игровых локаций (Enum).

### 📁 Scripts/Features/
Модульная реализация игровых зон. Каждый модуль автономен и следует паттерну Controller/View:
*   **Loading/** — Система загрузки (Controller, View, Processor).
*   **MainMenu/** — Главное меню и его подсистемы (Garage, Settings, Credits).
*   **City/** — Механики открытого мира.

### 📁 Scripts/Utility/
Инструментарий и системные расширения:
*   **Logging/** — Кастомная система `OverLogger` с поддержкой уровней и цветов.
*   **Validation/** — Фреймворк для автоматической проверки ссылок в инспекторе.

---

## 👤 Авторство и права

**Автор:** Влад «Nyorra»  
**Telegram:** [@nyorra](https://t.me)  
**Дата создания:** 31 марта 2026 г.

### ⚖️ Лицензия / Legal Info
© 2026 Влад Nyorra. **Все права защищены.**

Данный проект является частной собственностью. 
*   Запрещено копирование, распространение или использование исходного кода и ассетов без прямого письменного согласия автора.
*   Репозиторий предназначен для демонстрации навыков и не является Open Source.

---

## 🚀 Как запустить

1. Клонируйте репозиторий:
   ```bash
   git clone https://github.com/nyorra/Overlimit-Game.git
