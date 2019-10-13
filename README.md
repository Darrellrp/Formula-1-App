# Formula 1 Application

Architecture & Design 2019-2020

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

### Prerequisites

Make sure you have docker installed and the ports 8080 & 44348 are available on your development machine.

Make sure you have installed all of the following prerequisites on your development machine:
* Git - [Download & Install Git](https://git-scm.com/downloads)
* Docker - [Download & Install Docker](https://www.docker.com/products/docker-desktop)

Also make sure that port 8080 & 44348 are available on your development machine.

### Installing

Once you've satisfied the prerequisites, run the following command to clone the repository:
```
git clone https://gitlab.fdmci.hva.nl/poleond001/formula-1-app.git
```

## Running the applications

Go into the application folder and run the following command to start the applications:
```
docker-compose up -d
```

Now that the applications are running, open your browser and go to the URLs below:

API
```
https://localhost:44348/api
```

Web
```
http://localhost:8080
```


