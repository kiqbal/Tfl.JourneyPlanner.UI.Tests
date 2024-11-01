
Here's a structured README file for your assignment:

---

# Test Automation Framework for TfL Journey Planner

## Introduction

As part of the selection process for the role of **Senior Test Analyst**, this repository contains a test automation framework built to automate tests based on the TfL website’s Journey Planner widget, available at [TfL Journey Planner](https://tfl.gov.uk/plan-a-journey).

## Table of Contents

- [Instructions](#instructions)
- [Development Decisions](#development-decisions)
- [Directory Structure](#directory-structure)
- [Testing Strategy](#testing-strategy)
- [Parallel Execution](#parallel-execution)
- [Reporting and Screenshots](#reporting-and-screenshots)
- [Installation and Usage](#installation-and-usage)
- [Conclusion](#conclusion)

## Instructions

1. **Write Tests in C#:** All tests have been implemented using the C# programming language within the Visual Studio environment.
   
2. **Gherkin Syntax:** The tests are written using the Gherkin syntax with the SpecFlow extension, allowing for a Behavior-Driven Development (BDD) approach.

3. **Automation Libraries:** The framework utilizes **Playwright** or **Selenium WebDriver** along with **ChromeDriver** and the .NET libraries for UI automation.

4. **Repository Submission:** The completed code has been submitted to a public Git repository for review.

5. **README Inclusion:** This README file outlines the development decisions made during the project.

## Development Decisions

- **Fluent Assertions:** Implemented Fluent Assertions for better readability and maintainability of test assertions.
  
- **SpecFlow Living Doc:** Used SpecFlow Living Doc for reporting and maintaining documentation of the test scenarios.

- **Page Object Model:** Employed the Page Object Model (POM) design pattern to encapsulate page-specific actions and elements, improving code organization and reusability.

- **Helper Class:** Created a helper class to maintain common functions utilized across different test scenarios, promoting code reuse.

- **Driver Class:** Developed a driver class to initialize the Playwright driver and respective browsers, allowing easy access to browser instances throughout the test framework.

## Directory Structure

```
/ProjectRoot
    ├── Driver
    ├── Features
    ├── Hooks
    ├── Log
    ├── Pages
    ├── StepDefinitions
    ├── TestData
    └── Utilities
```

### Description of Directories

- **Driver:** Contains the implementation for initializing the Playwright driver and managing browser instances.
- **Features:** Contains the Gherkin feature files that describe the test scenarios.
- **Hooks:** Implements hooks for setting up and tearing down test scenarios and supports parallel execution.
- **Log:** Contains log files for test execution details.
- **Pages:** Contains page object classes representing different pages of the TfL Journey Planner.
- **StepDefinitions:** Contains the Step Definitions with appropriate Given, When, and Then bindings.
- **TestData:** Holds any necessary test data used during test execution.
- **Utilities:** Contains helper functions and common utilities used throughout the framework.

## Testing Strategy

The testing strategy focuses on validating the functionality of the TfL Journey Planner by simulating user interactions and verifying expected outcomes.

### Parallel Execution

Tests are configured to run in parallel using SpecFlow hooks, which optimizes the testing process by leveraging multiple threads.

## Reporting and Screenshots

To enhance reporting capabilities, the framework captures screenshots on test failure or success. Below are examples of how to use the screenshot functionality in your tests:



  

1. **On Test Success:**
   - Screenshot to confirm successful execution.
![Feature Files Status] (https://ibb.co/bHnYcZG)
![Full Suit Status] (https://ibb.co/9cBQ6qX)
   

## Installation and Usage

To run the tests, follow these steps:

1. Clone the repository:
   ```bash
   git clone <https://github.com/kiqbal/Tfl.JourneyPlanner.UI.Tests.git>
   ```

2. Navigate to the project directory:
   ```bash
   cd <Tfl.JourneyPlanner.UI.Tests>
   ```

3. Install the required packages:
   ```bash
   dotnet restore
   ```

4. Clean the Project:
   ```bash
   dotnet clean
   ```

5. Build the Project:
   ```bash
   dotnet build
   ```


6. Run the tests:
   ```bash
   dotnet test
   ```

## Conclusion

This repository provides a comprehensive test automation framework for the TfL Journey Planner. The use of modern practices such as BDD with SpecFlow, Page Object Model design pattern, and automated reporting enhances the maintainability and effectiveness of the testing process. 
