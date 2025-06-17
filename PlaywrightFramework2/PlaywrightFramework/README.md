# PlaywrightFramework (C#)

This is a modular, scalable test automation framework using **Playwright for .NET**, targeting:
- ✅ Web UI Automation
- ✅ API Testing
- ✅ Mobile Emulation Testing

## Getting Started

- Install dependencies:
```bash
dotnet restore
playwright install
```

- Run tests:
```bash
dotnet test
```

- Generate Allure Report:
```bash
allure generate ./TestResults -o ./AllureReport --clean
allure open ./AllureReport
```