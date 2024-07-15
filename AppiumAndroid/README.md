**Extensões utilizadas no VS Code:**

C# Dev Kit
.Net Install Tool
C#
IntelliCode for C# Dev Kit

**Dependências a serem instaladas para o projeto:**

dotnet add package Appium.WebDriver --prerelease
dotnet add package Newtonsoft.Json --version 13.0.3
dotnet add package NUnit --version 4.1.0
dotnet add package FluentAssertions

**Exemplo de capability para utilizar o Appium Inspector:**
(Nota: editar o appium:app para o caminho de sua máquina onde está o apk)

{
  "platformName": "Android",
  "appium:appPackage": "a.foradacaixa.foradacaixaa",
  "appium:appActivity": "a.foradacaixa.foradacaixaa.MainActivity",
  "appium:automationName": "uiautomator2",
  "appium:app": "/Users/cristiano/Desktop/foradacaixa.apk",
  "appium:udid": "emulator-5554"
}

Dica: para descobrir os udid dos devices (fisicos ou emuladores) disponíveis, abra um prompt de comando e digite:
      adb devices