# Bank Account Proxy Application

## Overview
This C# project demonstrates the implementation of the Proxy Design Pattern using a simple bank account application. The project includes a user interface built with WPF and unit tests to ensure correct functionality.

## Features
- **Proxy Design Pattern**: The project uses a proxy class to control access to a bank account, including withdrawal limits and validation checks.
- **WPF User Interface**: The application provides a basic user interface for depositing and withdrawing money from the account.
- **Unit Tests**: Comprehensive unit tests ensure that the proxy and bank account classes function as expected.

## Design

![UML Diagram](images/uml_proxyapp.jpg)

## Technologies Used
- **C#**
- **WPF** for the user interface
- **.NET 8.0**
- **MSTest** for unit testing

### Prerequisites
- Visual Studio 2022 (Community Edition or higher)
- .NET 8.0 SDK

## Usage
- **Deposit**: Enter an amount in the deposit field and click the "Deposit" button.
- **Withdraw**: Enter an amount in the withdraw field and click the "Withdraw" button. Ensure that the amount is within the allowed limit and that sufficient funds are available.
- **Balance**: The current balance is displayed in the interface and updates after each transaction.
