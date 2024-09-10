# Event Sourcing with Outbox Pattern Example

This project demonstrates the implementation of Event Sourcing and the Outbox Pattern in a distributed system using C#. It includes in-memory implementations of repositories and an event bus to facilitate unit testing.

## Table of Contents

- [Introduction](#introduction)
- [Architecture](#architecture)
- [Project Structure](#project-structure)
- [Getting Started](#getting-started)

## Introduction

The purpose of this project is to showcase how Event Sourcing and the Outbox Pattern can be implemented together in a C# application. The project includes:
- **InMemoryOrderRepository**: An in-memory implementation of `IOrderRepository` for storing order aggregates.
- **InMemoryOutboxRepository**: An in-memory implementation of `IOutboxRepository` for storing outbox messages.
- **InMemoryEventBus**: A simple in-memory event bus implementation for publishing and retrieving events.

## Architecture

The project is structured to simulate a real-world distributed system with the following components:

- **OrderService**: Responsible for handling order-related operations and saving events to the outbox.
- **OutboxProcessor**: Processes the events stored in the outbox and publishes them to the event bus.
- **Repositories**: In-memory repositories for storing order aggregates and outbox messages.
- **Event Bus**: In-memory event bus for simulating event publication and consumption.



## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/yourusername/event-sourcing-outbox-pattern.git
    cd event-sourcing-outbox-pattern
    ```

2. Restore the dependencies:

    ```bash
    dotnet restore
    ```

3. Build the solution:

    ```bash
    dotnet build
    ```

### Running the Application

To run the application, use the following command:

```bash
dotnet run --project src/Program.cs
```