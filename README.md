Create your own .env file based upon the example .env.example file and place it in the root directory next to the docker-compose.yml file.

```bash

```bash

```bash
dotnet test
```

```bash
docker build -t example-api -f ./Dockerfile .
docker run -p 8080:80 example-api
```

```bash
docker-compose up
```

GET http://localhost:8080/WeatherForecast