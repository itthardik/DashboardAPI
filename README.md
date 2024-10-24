# E-Commerce Sales Dashboard

[Frontend Repo](https://github.com/itthardik/Dashboard-Frontend)

[Backend Repo](https://github.com/itthardik/DashboardAPI)

## Overview

The **E-Commerce Sales Dashboard** is a comprehensive solution designed to provide real-time insights into sales performance, inventory management, revenue analysis, and customer support. The dashboard helps businesses make data-driven decisions, optimize operations, and streamline customer support processes.

This application features:
- **Sales Performance Monitoring**: Real-time sales visualization with comparison across time periods.
- **Inventory Management**: Real-time stock monitoring, shortage prediction, and automated reorder processes.
- **Revenue and Profit Analysis**: Detailed analysis of revenue, profit margins, and cost breakdowns.
- **Customer Support Dashboard**: Manage customer support tickets with priority-based sorting, search, and filter functionalities.
- **Role-Based Access Control**: Different levels of access based on user roles (Admin, Sales Manager, Inventory Manager, Revenue Manager, Customer Support Manager).
- **Third-Party API Integrations**: Integration with external platforms for enhanced customer support and background job automation.

---

## Table of Contents
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Installation](#installation)
- [Usage](#usage)
- [Database Schema](#database-schema)
- [Third-Party Integrations](#third-party-integrations)
- [Development Process](#development-process)
- [License](#license)

---

## Features

1. **User Authentication and Access Control**
   - Role-based access (Admin, Sales Manager, Inventory Manager, Revenue Manager, Customer Support Manager).
   
2. **Sales Performance Monitoring**
   - Real-time sales data visualization with bar and line graphs.
   - Sales comparison over different time periods (days, weeks, months).
   - Top 5 products and categories based on sales (optional).

3. **Inventory Management**
   - Monitor stock levels in real-time.
   - Predict stock shortages and automate reorder processes.
   - Highlight low-stock items.

4. **Revenue and Profit Analysis**
   - Visualize revenue and profit margins by category.
   - Cost breakdown with pie charts.
   - Forecast future sales based on past trends.

5. **Customer Support Dashboard**
   - Manage support tickets with search, filter, and priority-based sorting.
   - Track response and resolution times.

6. **Utility Features**
   - Background job for midnight restocking, recalculating data and live data updates.

---

## Technology Stack

- **Frontend**: React, Tailwind CSS, Chart.js
- **Backend**: .NET Core (API Development), Hangfire (for background jobs)
- **Database**: SQL Server
- **Real-Time Communication**: MQTT, WebSocket, Mosquitto broker
- **Authentication**: JSON Web Token (JWT), Session Token
- **Third-Party Integrations**: Freshdesk API for customer support

---

## Installation

### Prerequisites
Ensure you have the following installed on your system:
- .NET Core SDK (v8.0)
- Node.js
- NPM
- SQL Server
- Mosquitto Broker

### Steps

1. Clone the repository

2. Install the required dependencies

3. Set up the SQL Server database

4. Start the Mosquitto broker

5. Set up your environment variables

6. Start the application

---

## Usage

### Access Roles

- **Admin**: Full access to all features.
- **Sales Manager**: Access to Sales Performance Monitoring.
- **Inventory Manager**: Access to Inventory Management.
- **Revenue Manager**: Access to Revenue and Profit Analysis.
- **Customer Support Manager**: Access to the Customer Support Dashboard.

### Sales Performance
- View real-time sales data across categories.
- Compare sales over different time periods.
- Monitor top-performing products and categories.

### Inventory Management
- Track stock levels in real-time.
- Receive notifications for stock shortages.
- Automatically reorder items when thresholds are met.

### Revenue and Profit Analysis
- Analyze revenue, costs, and profits.
- Forecast future sales trends based on historical data.

### Customer Support Dashboard
- Manage and monitor customer support tickets.
- View ticket status, priorities, and resolution times.

---

## Database Schema

- **Users**: Stores user information and roles.
- **Orders**: Tracks order details including status and pricing.
- **Products**: Contains product details, cost, and stock levels.
- **Categories**: Product category details.
- **Suppliers**: Information on product suppliers.
- **Stock Alerts**: Tracks low-stock alerts.
- **Customer Searches**: Logs customer search history for sales forecasting.

---

## Third-Party Integrations

- **Freshdesk API**: For managing customer support tickets.
- **Mosquitto Broker**: Real-time communication using MQTT.
- **Hangfire**: For background job management and task scheduling.

---

## License

This project is licensed under the MIT License.

---

