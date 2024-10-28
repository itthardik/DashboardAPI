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
- [Documentation](#documentation)
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

## Documentation

### Sequence Diagrams
- **Auth**
  - [Login](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/Eal5Z2DK0CpOryMJ0JQw7O0BZ4NIdmytcYD5FIX9x-eaQA?e=PV43pC)
  - [Logout](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EcW3ff3eFHRLmSzQOXJrcEYBx3Q0LRPaE85HT3-FyhhgaQ?e=UIdiCy)
  - [Refresh Token](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EeOjjqvlWIpPvvYyIEHGgJABCPH4RBCfc8cBBJf6HBlAGA?e=t07Ct1)
- **Customer Support**
  - [Get All Tickets](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/ERwNMc-8du9Eh8YwBP7mVNEBUIQuYUbChCzs0CMuzZf2DA?e=m5W8Gb)
  - [Get Tickets Overall Stats](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EQDjzLsupTRNkQ_vzG97I00Bp0cPGSR7CaBz7fn9Pn7hCA?e=lgED2C)
- **Inventory**
  - [Inventory Process](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/Ebyso_XnMjlNk5IFjwsiEskBOC45wls35NtQTXxBMtD-TA?e=9YCRVi)
- **Revenue**
  - [Cost Analysis](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EbpTpvc4IPlKmsL-8yQjCzABou8G2mDrWKk8A6ovvnevaQ?e=O6vkv9)
  - [Top Ranking Search Values](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/ERV2awzQYf9FpZ1JeqiDXLYBxOgRmI79BmFtyvFyXeYIDg?e=n0sKi9)
  - [Top Revenue by Categories](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EWEBJ4D6NSdCpCxZOygJorUBSbZ5SQGxiUgtuuEnjsdBpA?e=dw9Jw3)
- **Sales**
  - [Get Last 10 Min Sales](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EcDzsfn5JdJGkOm0vRWWUw8B1jps7EnkEsIEZFYc3cKXvg?e=4oqfUT)
  - [Get Overall Sales Stats Based on Days](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EfStMhkR5dpOnrQIksp7qiwBcZld4yt68j4nMvYEczRxuA?e=MhganD)
  - [Get Top Selling Categories by Pagination](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/ETUUrHscGoJIjs5VIqoX8JcBP8G2MP4xCIGEdBI4aDeqAg?e=wy9vuc)
  - [Get Top Selling Products by Pagination](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EavvlOZptT9Os3iONBWLa9IBGeYqDQeZS7eFanejApUbPg?e=BSbcju)
  - [Get Total Sales by Category](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EQljK-o_UqxArICr1R96L_sBHGg9yVz0HZ4CGOzrLeq4qQ?e=EPJCqo)

### System Architecture Diagrams
- [H&M Architecture Diagram](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EZV73l7VHoFGnjR-_A_8_hgBUIl6lxsGG5iNIha-5vtOkw?e=pttRFc)
- [MQTT Protocol Diagram](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EdnK3nXFak1PqO2onX6M9ZkBc7BmwSwev64QOK_xdlFAsQ?e=ASwrYz)

### Additional Documentation
- [ER Diagram](https://intimetecvisionsoft-my.sharepoint.com/:b:/g/personal/hardik_sharma_intimetec_com/EU15x6-R3C5NjJij2dF5e_sBnmek43Hne68v3aQgXJRiqg?e=CHTHB8)
- [Figma UI](https://intimetecvisionsoft-my.sharepoint.com/:i:/g/personal/hardik_sharma_intimetec_com/EYekBWmPEmNIuOkI6yvQYs8B68p84mD956suuZ4jS8G8AQ?e=LLv4KW)
- [Api Docs](https://intimetecvisionsoft-my.sharepoint.com/:u:/g/personal/hardik_sharma_intimetec_com/EX90mAVaEh9Cj2Lj16PZSnYBxcmiFmMGjkWFIb4yk6TYpA?e=cnrFfi)
- [Authentication Processes](https://intimetecvisionsoft-my.sharepoint.com/:b:/g/personal/hardik_sharma_intimetec_com/ETiIncovf1tKkrjsf9S0cSYB2y0Q0gOCzGEGfBuqZGaljw?e=fLV4JS)
- [User Manual](https://intimetecvisionsoft-my.sharepoint.com/:b:/g/personal/hardik_sharma_intimetec_com/EU1rw8MEsyFAr1jp_zPZSKYBHuiOxvMK06P5tF2caEDBbQ?e=Qb6dBe)
- [Software Requirements Specification (SRS)]([docs/SRS.pdf](https://intimetecvisionsoft-my.sharepoint.com/:f:/g/personal/hardik_sharma_intimetec_com/EgaXSMrYoppFnbXKdp-qB2UBv55cn3V3OmCzFWQVgi5x_A?e=ITifbw))

---

## License

This project is licensed under the MIT License.
