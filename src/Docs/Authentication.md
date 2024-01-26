# Authentication

## Register Endpoint

```json
POST {{host}}/auth/register
Content-Type: application/json

{
    "firstName": "John",
    "lastName": "Doe",
    "email": "doeJohn@ms.net",
    "password": "doepass"
}
```

## Login Endpoint

```json
POST {{host}}/auth/login
Content-Type: application/json

{
    "email": "doeJohn@ms.net",
    "password": "doepass"
}
```