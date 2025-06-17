# PlaywrightFramework (C#)

This is a modular, scalable test automation framework using **Playwright for .NET**, targeting:
- ✅ Web UI Automation
- ✅ API Testing
- ✅ Mobile Emulation Testing

## 🔧 Technologies
- Microsoft.Playwright
- NUnit
- .NET 6
- Azure DevOps for CI/CD

## 🧱 Project Structure
```
PlaywrightFramework/
├── API/              # REST API test clients and test cases
├── Drivers/          # Playwright driver setup
├── Mobile/           # Mobile emulation tests
├── Pages/            # Page Object Models
├── Tests/            # Web UI tests
├── Utilities/        # Config and helpers
```

## 🚀 Getting Started

### 1. Clone and Install Dependencies
```bash
dotnet restore
playwright install
```

### 2. Run Tests
```bash
dotnet test
```

## 📦 Run in Azure DevOps
See the `azure-pipelines.yml` file for the build/test pipeline.

---

## 📄 License
MIT