# REST API

The Book Web API is described below.

## Get a specific Book ---------------------------------

 2: This value is default id value.

### Request

`GET api/Book/id` 

    curl -X GET "https://localhost:44392/api/Book/2" -H  "accept: */*"

    #### Request URL
    https://localhost:44392/api/Book/2 

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8

`GETBYID api/Book?id=` 

    curl -X GETBYID "https://localhost:44392/api/Book?id=2" -H  "accept: */*"

    #### Request URL
    https://localhost:44392/api/Book?id=2

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8

## Get Book List-------------------------------------------------------

### Request

`POST /Book/`

    curl -X POST "https://localhost:44392/api/Book/BookList" -H  "accept: */*" -d ""

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8


## Change a Book----------------------------------------------------------

### Request
`PUT /Book/id`

  curl -X PUT "https://localhost:44392/api/Book/2" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":0,\"bookSerialNo\":\"string\",\"bookName\":\"string\",\"author\":\"string\"}"
  
  #### Request URL
  https://localhost:44392/api/Book/2

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:31 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 74

    {"id":2,"bookSerialNo":"","bookName":"","author":""}


## Delete a Book -------------------------------------

### Request

`DELETE /Book/id`

    curl -i -H 'Accept: application/json' -X POST -d'_method=DELETE' http://localhost:7000/thing/2/
    
    #### Request URL
    https://localhost:44392/api/Book/2

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8


## Create a new Book----------------------------------------

### Request

`POST /Book/`

    curl -X POST "https://localhost:44392/api/Book" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"id\":0,\"bookSerialNo\":\"string\",\"bookName\":\"string\",\"author\":\"string\"}"

### Response

    HTTP/1.1 200 OK
    Date: Tue21 Dec 2021 09:40:56 GMT 
    Status: 200 OK
    Connection: close
    Content-Type: application/json; charset=utf-8
