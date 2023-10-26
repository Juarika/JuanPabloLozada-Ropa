# Clothing 🐶🐱⚕️
## Consultas

### Basicas
- Crear
```
[POST]localhost:5016/api/[Nombre de la entidad]
```
- Editar
```
[PUT]localhost:5016/api/[Nombre de la entidad]/{id}
```
- Eliminar
```
[DELETE]localhost:5016/api/[Nombre de la entidad]/[id]
```
- Listar v1.0
```
[GET]localhost:5016/api/[Nombre de la entidad]
```
- Listar v1.1
```
[GET]localhost:5016/api/[Nombre de la entidad]
```
```
X-Version : 1.1
```
### JWT
#### Registrar
- Endpoint
```
http://localhost:5016/api/User/Register/
```
#### Token
- Endpoint
```
http://localhost:5016/api/User/Token/
```
#### Añadri rol
- Endpoint
```
http://localhost:5016/api/User/addrole/
```
####  Refresh Token
```
http://localhost:5016/api/User/refresh-token/
```

### Listar los proveedores que sean persona [Tipo persona].
#### Endpoint
```
http://localhost:5016/api/Supplier/PersonType?Search=[Tipo Persona]
```
#### Respuesta
```
[
  {
    "nit": "456",
    "name": "Pedro",
    "personTypeId": 2,
    "cityId": 1,
    "inputs": []
  }
]
```
### Listar las prendas de una orden de producción cuyo estado sea en producción. El usuario debe ingresar el número de orden de producción.
#### Endpoint
```
http://localhost:5016/api/Orden/Status?Search=[Status]
```
```
X-Version : 1.1
```
#### Respuesta
```
[
  {
    "date": "2021-05-05",
    "employeeId": 2,
    "clientId": 2,
    "statusId": 2
  }
]
```
### Listar las prendas agrupadas por el tipo de protección.
#### Endpoint
```
http://localhost:5016/api/ProtectionType/ProtectionType
```
#### Respuesta
```
[
  {
    "description": "Inifugo",
    "dresses": [
      {
        "name": "Traje",
        "valueCop": 100000.00000000000000000000000,
        "valueUsd": 25.000000000000000000000000000,
        "statusId": 1,
        "protectionTypeId": 1,
        "genderId": 1
      }
    ]
  },
  {
    "description": "Antiagua",
    "dresses": [
      {
        "name": "Trajecito",
        "valueCop": 50000.000000000000000000000000,
        "valueUsd": 12.500000000000000000000000000,
        "statusId": 2,
        "protectionTypeId": 2,
        "genderId": 2
      }
    ]
  }
]
```
### Listar las ordenes de producción que pertenecen a un cliente especifico. El usuario debe ingresar el IdCliente y debe obtener la siguiente información:
#### Endpoint
```
http://localhost:5016/api/Orden/AllOrdens
```
```
X-Version : 1.1
```
#### Respuesta
```
[
  {
    "clientId": 1,
    "clientName": "Sandra",
    "clientCity": "Bucaramanga",
    "ordenId": 1,
    "ordenDate": "2023-02-02",
    "statusDescription": "Azul",
    "statusCode": "Produccion",
    "ordenValue": 1000000.0000000000000000000000,
    "dressName": "Traje",
    "dressCode": 1,
    "dressQuantity": 12,
    "dressValueCop": 100000.00000000000000000000000,
    "dressValueUsd": 25.000000000000000000000000000
  },
  {
    "clientId": 2,
    "clientName": "Felipe",
    "clientCity": "Bucaramanga",
    "ordenId": 2,
    "ordenDate": "2021-05-05",
    "statusDescription": "Verde",
    "statusCode": "Terminado",
    "ordenValue": 5000000.0000000000000000000000,
    "dressName": "Trajecito",
    "dressCode": 2,
    "dressQuantity": 21,
    "dressValueCop": 50000.000000000000000000000000,
    "dressValueUsd": 12.500000000000000000000000000
  }
]
```
### Listar los insumos que son vendidos por un determinado proveedor. El usuario debe ingresar el Nit de proveedor.
#### Endpoint
```
http://localhost:5016/api/Input/Supplier?Search=[Nit]
```
#### Respuesta
```
[
  {
    "name": "Nose",
    "value": 100.00000000000000000000000000,
    "minStock": 10,
    "maxStock": 11,
    "dresses": [],
    "dressInputs": null,
    "suppliers": [],
    "supplierInputs": null,
    "id": 1
  }
]
```

## Autor
- Juan Pablo Lozada