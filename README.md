```bash
dotnet test
```

```bash
docker build -t example-api -f ./Dockerfile .
docker run -p 8081:80 example-api
```

```bash
docker-compose up
```

GET http://localhost:8081/WeatherForecast