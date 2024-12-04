# SOFT1Exam_MTOGO_Backend


## Table of Contents

- [SOFT1Exam\_MTOGO\_Backend](#soft1exam_mtogo_backend)
  - [Table of Contents](#table-of-contents)
  - [Introduction](#introduction)
  - [Build Status](#build-status)
  - [CI/CD Pipeline](#cicd-pipeline)
    - [Pipeline Steps](#pipeline-steps)
  - [Tech stack](#tech-stack)
  - [API Documentation](#api-documentation)
    - [REST](#rest)
      - [AgentApi](#agentapi)
      - [CustomerApi](#customerapi)
      - [FeedbackApi](#feedbackapi)
      - [OrderApi](#orderapi)
      - [PaymentApi](#paymentapi)
      - [RestaurantApi](#restaurantapi)
      - [UserApi](#userapi)
  - [Docker Compose](#docker-compose)
    - [Overview](#overview)
    - [Dockerhub](#dockerhub)
    - [Services / Containers](#services--containers)

## Introduction

Welcome to the **SOFT1Exam_MTOGO_Backend** repository! This is our backend service, which manages the independent microservices to the frontend. This endpoints in this service, is dependent on the whcich of the other microserveices are running. But to have the full functionlity, all of the microservices must be up and running.

## Build Status
Check out the lastest build status here: ![CI/CD](https://github.com/LucasHemm/SOFT1Exam_MTOGO_Backend/actions/workflows/dotnet-tests.yml/badge.svg)

## CI/CD Pipeline

Our CI/CD pipeline utilizes GitHub Actions to automate the testing and deployment of the application. This uses our whole suite of tests. To initate the pipeline a pull request has to be made to merge the code. After the request has been made the pipeline will run the tests, and deploy the image of the application to dockerhub if all the tests pass.

The pipeline consists of the following steps:

### Pipeline Steps

1. **Checkout Repository**
2. **Setup .NET**
3. **Restore Dependencies**
4. **Build**
5. **Test**
6. **Log in to Docker Hub**
7. **Build Docker Image**
8. **Push Docker Image** 

## Tech stack
The tech stack for this microservice is as follows:
- **C#**: The main programming language for the application.
- **ASP NET Core 8.0**: The main framework for the application.
- **Microsoft SQL Server**: The database for the application.
- **Promehteus**: The library used for metrics.
- **Grafana**: The library used for visualizing the metrics.
- **Docker**: The containerization tool used to deploy the application.
- **Docker Compose**: The tool used to deploy the application locally.
- **GitHub Actions**: The CI/CD tool used to automate the testing and deployment of the application.
- **Swagger**: The library used to document the API.
- **xunit**: The library used for unit and integration testing.
- **Testcontainers**: The library used to create testcontainers for the integration tests.
- **Coverlet**: The library used to create code coverage reports.

## API Documentation
### REST
#### AgentApi
| **Endpoint**                  | **Result**                                    | **Format**   |
|-------------------------------|-----------------------------------------------|--------------|
| `POST /api/AgentApi`          | Creates an agent                              | JSON         |
| `GET /api/AgentApi/{id}`      | Gets an agent by id                           | JSON         |

#### CustomerApi
| **Endpoint**                  | **Result**                                    | **Format**   |
|-------------------------------|-----------------------------------------------|--------------|
| `POST /api/Customer`          | Creates a customer                              | JSON         |
| `GET /api/Customer/{id}`      | Gets a customer by id                           | JSON         |


#### FeedbackApi
| **Endpoint**                  | **Result**                                    | **Format**   |
|-------------------------------|-----------------------------------------------|--------------|
| `POST /api/FeedbackApi`          | Creates a feedback                             | JSON         |


#### OrderApi
| **Endpoint**                  | **Result**                                    | **Format**   |
|-------------------------------|-----------------------------------------------|--------------|
| `POST /api/OrderApi`          | Creates an order                              | JSON         |
| `GET /api/OrderApi/{id}`      | Gets an order by id                           | JSON         |
| `GET /api/OrderApi/`      | Gets all orders                           | JSON         |
| `PUT /api/OrderApi/`      | Updates an order                           | JSON         |
| `GET /api/OrderApi/Staus/{status}`      | Gets all orders by status                           | JSON         |
| `GET /api/OrderApi/Agent/{id}`      | Gets all orders by agent id                           | JSON         |
| `GET /api/OrderApi/Customer/{id}`      | Gets all orders by customer id                           | JSON         |
| `PUT /api/OrderApi/UpdateIds`      | Updates an orders agent payment information                           | JSON         |


#### PaymentApi
| **Endpoint**                  | **Result**                                    | **Format**   |
|-------------------------------|-----------------------------------------------|--------------|
| `POST /api/PaymentApi`          | Creates a payment                              | JSON         |
| `GET /api/PaymentApi/{id}`      | Gets a payment by id                           | JSON         |

#### RestaurantApi
| **Endpoint**                  | **Result**                                    | **Format**   |
|-------------------------------|-----------------------------------------------|--------------|
| `POST /api/RestaurantApi`          | Creates a restaurant                              | JSON         |
| `GET /api/RestaurantApi/{id}`      | Gets a restaurant by id                           | JSON         |
| `GET /api/RestaurantApi/`      | Gets all restaurants                           | JSON         |
| `PUT /api/RestaurantApi/`      | Updates a restaurant                           | JSON         |
| `POST /api/RestaurantApi/MenuItem`          | Creates a menuitem                              | JSON         |
| `GET /api/RestaurantApi/MenuItem/{id}`      | Gets a menuitem by restaurantid                           | JSON         |
| `PUT /api/RestaurantApi/MenuItem`      | Updates a menuitem                           | JSON         |

#### UserApi
| **Endpoint**                  | **Result**                                    | **Format**   |
|-------------------------------|-----------------------------------------------|--------------|
| `POST /api/UserApi`          | Creates a user                              | JSON         |
| `POST /api/UserApi/Login`          | Login as a user                              | JSON         |





## Docker Compose

### Overview

To run this microservice, you can use Docker Compose to deploy the services locally. 

```yaml
docker-compose up --build
```
To access the Swagger UI and endpoints, navigate to the following URL:
```
http://localhost:8087/swagger/index.html
```

See performance metrics at:
```
http://localhost:8087/metrics
```
Or use the prometheus UI at:
```
http://localhost:9097
```
And the grafana UI at:
```
http://localhost:3007
```

Alternatively, you can run all the services from the MTOGO project by going to this repository and following the guide there.
```
https://github.com/LucasHemm/SOFTEXAM_Deployment
```

### Dockerhub
The docker-compose file uses the local dockerfile to build the image, and run the container. The image can also be found on Docker Hub at:
```
https://hub.docker.com/u/lucashemcph
```

### Services / Containers

- **App** / **Mtogobackendcontainer**: Runs the main application server.
- **DB** / **Database**: Runs the Microsoft SQL Server database.
- **Prometheus** / **Prometheus**: Runs the prometheus server.
- **Grafana** / **Grafana**: Runs the grafana server.