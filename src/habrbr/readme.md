### Создание локальной миграции

```bash
dotnet ef migrations add {Наименование миграции} --project ..\Infrastructure\habrbr.Infrastructure.Persistence\habrbr.Infrastructure.Persistence.csproj --startup-project .\habrbr.csproj
```

### Отправка на сервер

```bash
dotnet ef database update
```