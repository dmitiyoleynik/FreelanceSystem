# FreelanceSystem

## Docker
To run backend application developer needs to have docker installed, do to FreelanceSystem project folder and run next:
```
$ docker build -t aspnetapp .
$ docker run -d -p 8080:80 --name myapp aspnetapp
```
To stop docker container:
```
$ docker stop myapp
$ docker rm myapp
```